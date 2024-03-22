using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Models;
using Shopping_cart.ViewModels;
using Shopping_cart.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Shopping_cart.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Shopping_cart.Roles;

namespace Shopping_cart.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanager, RoleManager<IdentityRole> rolemanager)
        {
            _userManager = usermanager;
            _signInManager = signinmanager;
            _roleManager = rolemanager;
        }

        [HttpGet("[action]")]
        [NotLoggedInFilter]
        public IActionResult Login([FromQuery] string? ReturnUrl = null)
        {
            if (ReturnUrl != null)
            {
                TempData["ReturnUrl"] = ReturnUrl;
                TempData.Keep("ReturnUrl");
            }

            return View();
		}

        [HttpPost("[action]")]
        [NotLoggedInFilter]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Login([FromForm] AccountLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: false);

                if (!loginResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login credentials. Try again.");
                    return View(user);
                }

                if (TempData.ContainsKey("ReturnUrl"))
                {
                    return Redirect(TempData["ReturnUrl"] as string);
                }

                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("[action]")]
        [NotLoggedInFilter]
		public IActionResult Register([FromQuery] string? ReturnUrl = null)
        {
            if (ReturnUrl != null)
            {
                TempData["ReturnUrl"] = ReturnUrl;
                TempData.Keep("ReturnUrl");
            }

            return View();
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        [NotLoggedInFilter]
        public async Task<IActionResult> Register([FromForm] AccountCreateViewModel model)
        {
            // Note: Make this method atomic transaction

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var createUser = await _userManager.CreateAsync(user, model.Password);

                if (createUser.Succeeded)
                {
                    bool buyerRoleExists = await _roleManager.RoleExistsAsync(ApplicationRoles.Buyer);

                    if (!buyerRoleExists)
                    {
                        IdentityRole buyerRole = new IdentityRole
                        {
                            Name = ApplicationRoles.Buyer
                        };

                        var createBuyerRole = await _roleManager.CreateAsync(buyerRole);

                        if (!createBuyerRole.Succeeded)
                        {
                            foreach (var error in createBuyerRole.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            return View(model);
                        }
                    }

                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Buyer);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (TempData.ContainsKey("ReturnUrl"))
                    {
                        string returnUrl = TempData["ReturnUrl"] as string;
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in createUser.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet("[action]")]
        public ActionResult Error()
        {
            return View();
        }
    }
}
