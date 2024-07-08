using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Data;
using Shopping_cart.Models;
using Shopping_cart.ViewModels.Home;
using System.Diagnostics;

namespace Shopping_cart.Controllers
{
	[Route("")]
	[Route("[controller]")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IProductRepository? _productRepository;

		private readonly ApplicationDBcontext _dbcontext;

		public HomeController(ILogger<HomeController> logger, IProductRepository? productRepository, ApplicationDBcontext context)
		{
			_logger = logger;
			_productRepository = productRepository;
			_dbcontext = context;
		}

		[Route("")]
		[Route("[action]")]
		public IActionResult Index()
		{
			List<Product>? products = _productRepository?.GetAllItems();
			HomeIndexViewModel hm = new HomeIndexViewModel()
			{
				Products = _productRepository?.GetAllItems()
			};
			return View(hm);
        }
	}
}