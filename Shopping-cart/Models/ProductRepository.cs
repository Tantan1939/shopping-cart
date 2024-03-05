namespace Shopping_cart.Models
{
	public class ProductRepository : IProductRepository
	{
		private List<Product> DataSource()
		{
			return new List<Product>()
			{
				new Product()
				{
					Id = 1, 
					Name = "Basketball Short", 
					Description = "A basketball short for guys.", 
					Category = ProductCategories.mens_apparel, 
					Price = 150.0f, 
					QuantityAvailable = 5, 
					UrlImage = "~/images/Mens_apparel/basketball-shorts.jpg"
				},
				new Product()
				{
					Id = 2,
					Name = "Men Sock",
					Description = "A sock for guys.",
					Category = ProductCategories.mens_apparel,
					Price = 200.50f,
					QuantityAvailable = 10,
					UrlImage = "~/images/Mens_apparel/men-socks.jpg"
				},
				new Product()
				{
					Id = 3,
					Name = "Men Sock",
					Description = "Underwear for guys only.",
					Category = ProductCategories.mens_apparel,
					Price = 220.50f,
					QuantityAvailable = 10,
					UrlImage = "~/images/Mens_apparel/men-underwear.jpg"
				},
				new Product()
				{
					Id = 4,
					Name = "Samsung A10",
					Description = "The oldest budget smartphone for poor.",
					Category = ProductCategories.Mobiles_and_gadgets,
					Price = 10990f,
					QuantityAvailable = 500,
					UrlImage = "~/images/Mobiles_and_gadgets/samsung-a10.jpg"
				},
				new Product()
				{
					Id = 5,
					Name = "Samsung A20",
					Description = "The oldest budget smartphone for poor.",
					Category = ProductCategories.Mobiles_and_gadgets,
					Price = 11990f,
					QuantityAvailable = 500,
					UrlImage = "~/images/Mobiles_and_gadgets/samsung-a20.jpeg"
				},
				new Product()
				{
					Id = 6,
					Name = "Samsung A30",
					Description = "The oldest budget smartphone for poor.",
					Category = ProductCategories.Mobiles_and_gadgets,
					Price = 12990f,
					QuantityAvailable = 500,
					UrlImage = "~/images/Mobiles_and_gadgets/samsung-a30.jpg"
				},
				new Product()
				{
					Id = 7,
					Name = "Smart TV Remote",
					Description = "A replacement for your lost smart TV remote.",
					Category = ProductCategories.Home_entertainment,
					Price = 399f,
					QuantityAvailable = 199,
					UrlImage = "~/images/Home_entertainment/smart-tv-remote.jpg"
				},
				new Product()
				{
					Id = 8,
					Name = "ABS-CBN TV plus",
					Description = "A digital box to watch free tv.",
					Category = ProductCategories.Home_entertainment,
					Price = 1999f,
					QuantityAvailable = 500,
					UrlImage = "~/images/Home_entertainment/tv-plus.jpg"
				},
				new Product()
				{
					Id = 9,
					Name = "Cetaphil",
					Description = "For smooth and clear face.",
					Category = ProductCategories.Health_and_personal_care,
					Price = 250f,
					QuantityAvailable = 500,
					UrlImage = "~/images/Health_and_personal_care/cetaphil.jpg"
				},
				new Product()
				{
					Id = 10,
					Name = "Dove Skin Soap",
					Description = "For baby skin.",
					Category = ProductCategories.Health_and_personal_care,
					Price = 249f,
					QuantityAvailable = 10599,
					UrlImage = "~/images/Health_and_personal_care/dove-soap.jpg"
				},
			};
		}

		public List<Product> GetAllItems()
		{
			return DataSource();
		}

		public Product GetItemById(int id)
		{
			return DataSource().First(x => x.Id == id);
		}
	}
}
