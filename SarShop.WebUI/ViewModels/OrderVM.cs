using SarShop.DAL.Entities;
using SarShop.WebUI.Models;

namespace SarShop.WebUI.ViewModels
{
	public class OrderVM
	{
		public List<Cart> Carts { get; set; }
		public Order Order { get; set; }
		public IEnumerable<City> Cities { get; set; }
	}
}
