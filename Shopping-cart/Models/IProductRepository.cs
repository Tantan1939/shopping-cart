namespace Shopping_cart.Models
{
	public interface IProductRepository
	{
		List<Product> GetAllItems();
		Product GetItemById(int id);
	}
}
