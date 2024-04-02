using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Models;
using Shopping_cart.ViewModels;
using Shopping_cart.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Shopping_cart.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Shopping_cart.Roles;
using Shopping_cart.Services;
using System.Text.Encodings.Web;
using System.Security.Claims;

namespace Shopping_cart.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ISenderEmail _emailSender;

        public AccountController(
            UserManager<ApplicationUser> usermanager, 
            SignInManager<ApplicationUser> signinmanager, 
            RoleManager<IdentityRole> rolemanager,
            ISenderEmail emailSender)
        {
            _userManager = usermanager;
            _signInManager = signinmanager;
            _roleManager = rolemanager;
            _emailSender = emailSender;
        }

        private async Task SendConfirmationEmail(ApplicationUser user)
        {
            // Generate a token and send it to the user email.

            try
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { UserId = user.Id, Token = token }, Request.Scheme);

                await _emailSender.SendEmailAsync(
                    user.Email,
                    "Confirm Your Email",
                    $"Confirm your account using this link {confirmationLink}.");
            }
            catch (Exception ex)
            {
                throw new Exception("Email confirmation token failed.");
            }
        }

        private async Task SendPasswordResetToken(ApplicationUser user)
        {
            try
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                var resetLink = Url.Action("PasswordReset", "Account", new { UserId = user.Id, Token = resetToken }, Request.Scheme );

                await _emailSender.SendEmailAsync(
                        user.Email,
                        "Reset your password",
                        $"Reset your account password using this link {resetLink}"
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Password reset token failed.");
            }
        }

        [HttpGet("[action]")]
        [NotLoggedInFilter]
        [ServiceFilter(typeof(ConfirmEmailFilter))]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string UserId, [FromQuery] string Token)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            var result = await _userManager.ConfirmEmailAsync(user, Token);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Invalid token. You can request a new one.";

                return View("ResendEmailToken", user);
            }
        }

        [HttpGet("[action]")]
        [NotLoggedInFilter]
        public IActionResult Login([FromQuery] string? ReturnUrl)
        {
            if (ReturnUrl != null && Url.IsLocalUrl(ReturnUrl))
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
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: false);

            if (loginResult.Succeeded)
            {
                if (TempData.ContainsKey("ReturnUrl") && Url.IsLocalUrl(TempData["ReturnUrl"] as string))
                {
                    return Redirect(TempData["ReturnUrl"] as string);
                }
                return RedirectToAction("Index", "Home");
            }

            if (await _userManager.FindByEmailAsync(user.Email) != null && 
                await _userManager.CheckPasswordAsync(await _userManager.FindByEmailAsync(user.Email), user.Password) &&
                await _userManager.IsEmailConfirmedAsync(await _userManager.FindByEmailAsync(user.Email)) == false)
            {
                ViewBag.message = "Your email is still not verified/confirm. Please check your email for confirmation link to continue.";
                return View(
                    "ResendEmailToken",
                    await _userManager.FindByEmailAsync(user.Email));
            }

            ModelState.AddModelError(string.Empty, "Invalid login credentials. Try again.");
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
		public IActionResult Register([FromQuery] string? ReturnUrl)
        {
            if (ReturnUrl != null && Url.IsLocalUrl(ReturnUrl))
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

                    await SendConfirmationEmail(user);

                    return View("UserRegistrationSuccessPage");
                }

                foreach (var error in createUser.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        [NotLoggedInFilter]
        public async Task<IActionResult> ResendEmailToken([FromForm] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null && await _userManager.IsEmailConfirmedAsync(user))
            {
                return RedirectToAction("Login", "Account");
            }

            if (user != null)
            {
                await SendConfirmationEmail(user);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.message = "Email not found.";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.userEmail = User.FindFirstValue(ClaimTypes.Email);
                return View("AuthForgotPasswordConfirmation");
            }
            return View("ForgotPasswordForm");
        }

        [HttpPost("[action]")]
        [NotLoggedInFilter]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([FromForm] AccountEmailViewModel userEmail)
        {
            if (ModelState.IsValid && 
                await _userManager.FindByEmailAsync(userEmail.Email) is var user && 
                user != null &&
                await _userManager.IsEmailConfirmedAsync(user))
            {
                await SendPasswordResetToken(user);

                ViewBag.message = "Please check your email for reset link";
                return View("Login");
            }

            if (ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Email not found.");
            }

            return View("ForgotPasswordForm", userEmail);
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AuthForgotPassword()
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmail);
            await SendPasswordResetToken(user);

            ViewBag.message = "Please check your email for reset link.";
            return View("Profile");
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        [ServiceFilter(typeof(PasswordResetTokenFilter))]
        public IActionResult PasswordReset([FromQuery] string UserId, [FromQuery] string Token)
        {
            ViewBag.userid = UserId;
            ViewBag.token = Token;
            return View();
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PasswordReset([FromForm] AccountPasswordViewModel passwords, [FromForm] string userid, [FromForm] string token)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userid);

                if (user == null)
                {
                    //ModelState.AddModelError(string.Empty, "User no longer exist.");
                    return RedirectToAction("Index", "Home");
                }

                var result = await _userManager.ResetPasswordAsync(user, token, passwords.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(passwords);
                }

                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Profile", "Account");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(passwords);
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("[action]")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword([FromForm] AccountChangePasswordViewModel userpasswords)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var result = await _userManager.ChangePasswordAsync(user, userpasswords.OldPassword, userpasswords.Password);

                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);

                    ViewBag.message = "Password changed successfully.";

                    return View("Profile");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userpasswords);
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
