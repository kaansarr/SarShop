using Microsoft.AspNetCore.Mvc;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;
using SarShop.DAL.Migrations;

namespace SarShop.WebUI.Controllers
{
	public class AboutController : Controller
	{
		IRepository<Aboutt> repoAbout;
		public AboutController(IRepository<Aboutt> _repoAbout)
		{
			repoAbout = _repoAbout;
		}
		[Route("/hakkimizda/{id}/{title}")]
		public IActionResult Index(int id , string title)
		{
			var response = repoAbout.GetBy(x => x.ID == id);
			return View(response);
		}
	}
}
