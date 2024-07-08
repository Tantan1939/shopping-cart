using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Roles;

namespace Shopping_cart.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SellerController : Controller
    {
        [Authorize(Roles = ApplicationRoles.Seller)]
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Application()
        {
            return View();
        }
    }
}
