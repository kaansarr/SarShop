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
			repoAbout= _repoAbout;
		}
		[Route("/hakkimizda")]
		public IActionResult Index(int id)
		{
			return View(repoAbout.GetAll(x=>x.ID==id));
		}
	}
}
