using Microsoft.AspNetCore.Mvc;

namespace Shopping_cart.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {

        [Route("[action]")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
