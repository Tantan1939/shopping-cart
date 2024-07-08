namespace Shopping_cart.Models
{
    public class SellerApplications
    {
        public int Id { get; set; }
        public string UrlPicture { get; set; }
        public string ShopAddress { get; set; }
        public string Tin { get; set; }
        public DateTime ApplicationDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
