using SarShop.DAL.Entities;

namespace SarShop.WebUI.ViewModels
{
	public class ProductDetailVM
	{
		public Product Product { get; set; }
		public IEnumerable<Product> RelatedProducts { get; set; }
	}
}
