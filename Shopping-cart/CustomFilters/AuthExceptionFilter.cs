using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shopping_cart.CustomFilters
{
    public class AuthExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult("Access denied.")
            {
                StatusCode = 403
            };
            context.ExceptionHandled = true;
        }
    }
}
