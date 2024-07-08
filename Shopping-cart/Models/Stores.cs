namespace Shopping_cart.Models
{
    public class Stores
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Address { get; set; }
        public string Tin { get; set; }
        public DateTime DateCreated { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
