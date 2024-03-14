using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Models;

namespace Shopping_cart.Controllers
{
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        [Route("[action]")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Register(Registration model)
        {
            if (!ModelState.IsValid)
            {
                // Validation failed, return to the form with errors
                return View(model);
            }
            // Handle successful validation logic here
            return RedirectToAction("Success");
        }

        [Route("[action]")]
        public string Success()
        {
            return "Registration Successful";
        }
    }
}
