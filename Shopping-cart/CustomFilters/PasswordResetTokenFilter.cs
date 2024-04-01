using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shopping_cart.Models;

namespace Shopping_cart.CustomFilters
{
    public class PasswordResetTokenFilter : IAsyncAuthorizationFilter
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PasswordResetTokenFilter(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            string UserId = context.HttpContext.Request.Query["UserId"];
            string Token = context.HttpContext.Request.Query["Token"];

            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Token))
            {
                context.Result = new ForbidResult();
            }

            var user = await _userManager.FindByIdAsync(UserId);

            if (user == null)
            {
                context.Result = new ForbidResult();
            }

            if (await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, UserManager<ApplicationUser>.ResetPasswordTokenPurpose, Token) == false)
            {
                context.Result = new ForbidResult();
            }

        }
    }
}
