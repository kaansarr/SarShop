using Microsoft.AspNetCore.Mvc;

namespace SarShop.WebUI.Controllers
{
	public class AboutController : Controller
	{
		[Route("/hakkimizda")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
