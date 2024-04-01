using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shopping_cart.Models;

namespace Shopping_cart.CustomFilters
{
    public class ConfirmEmailFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmEmailFilter(UserManager<ApplicationUser> userManager)
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

            if (user == null || await _userManager.IsEmailConfirmedAsync(user))
            {
                context.Result = new ForbidResult();
            }

        }
    }
}
