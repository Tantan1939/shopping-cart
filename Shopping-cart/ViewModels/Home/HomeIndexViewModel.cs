using Shopping_cart.Models;

namespace Shopping_cart.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public List<Product>? Products { get; set; }

        private List<string> categoriesdescription = new List<string>();

        public List<string>? CategoriesDescription
        {
            get { return categoriesdescription; }
            private set { categoriesdescription = value; }
        }

        public HomeIndexViewModel()
        {
            var categories = Enum.GetValues(typeof(ProductCategories)).Cast<ProductCategories>().ToList();

            foreach (var category in categories)
            {
                CategoriesDescription.Add(category.GetDescription());
            }
        }
    }
}
