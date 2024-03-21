using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Models;
using Shopping_cart.ViewModels;
using Shopping_cart.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Shopping_cart.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace Shopping_cart.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanager, RoleManager<IdentityRole> rolemanager)
        {
            userManager = usermanager;
            signInManager = signinmanager;
            roleManager = rolemanager;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult Login()
        {
			return View();
		}

        [HttpPost("[action]")]
		[AllowAnonymous]
		public IActionResult Login([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("[action]")]
		[AllowAnonymous]
		public IActionResult Register()
        {
            return View();
        }

        [HttpPost("[action]")]
		[AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] AccountCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet("[action]")]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }
    }
}
