using Microsoft.AspNetCore.Mvc;

namespace SarShop.WebUI.Controllers
{
	public class CardController : Controller
	{
		[Route("/sepetim")]
		public IActionResult Index()
		{
			return View();
		}
		[Route("/sepetim/ekle")]
		public string AddCart(int productid,int quantity)
		{
			return "X";
		}
	}
}
