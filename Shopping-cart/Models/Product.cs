using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.Models
{
	public class Product
	{

        [Key]
        public uint Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Item Description")]
        public string Description { get; set; }

        [Required]
        public ProductCategories Category { get; set; }

        private protected float price;

		[Required]
        public float Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be positive numbers. Decimals are allowed.");
                }
                else
                {
                    price = value;
                }
            }
        }

        public uint QuantityAvailable { get; set; } = 0;

        [Required]
        public string UrlImage { get; set; }

		public DateTime CreatedDateTime { get; set; } = DateTime.Now;
	}
}
