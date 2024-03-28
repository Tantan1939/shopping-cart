using Microsoft.AspNetCore.Mvc;

namespace Shopping_cart.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
