using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Models;

namespace Shopping_cart.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {

        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("[action]")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
