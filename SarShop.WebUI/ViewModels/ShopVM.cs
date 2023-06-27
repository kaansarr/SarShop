using SarShop.DAL.Entities;

namespace SarShop.WebUI.ViewModels
{
	public class ShopVM
	{
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<Product> Products { get; set; }
	}
}
