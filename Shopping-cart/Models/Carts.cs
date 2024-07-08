namespace Shopping_cart.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Dictionary<int, string> Items { get; } = new Dictionary<int, string>();
    }
}
