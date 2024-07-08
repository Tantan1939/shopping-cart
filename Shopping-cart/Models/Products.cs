namespace Shopping_cart.Models
{
    public class Products
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public StoreCategories Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Quantity { get; set; } = 0;
        public Dictionary<string, float> VariantsPrices { get; } = new Dictionary<string, float>();
        public string UrlImage { get; set; }
        public int StoreId { get; set; }
        public Stores Store { get; set; }                                    
        public DateTime Created { get; set; }
        public bool IsHidden { get; set; } = false;
    }
}
