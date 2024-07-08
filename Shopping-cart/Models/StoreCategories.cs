namespace Shopping_cart.Models
{
    public class StoreCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategories AppCategory { get; set; }
        public int StoreId { get; set; }
        public Stores Store { get; set; }
    }
}
