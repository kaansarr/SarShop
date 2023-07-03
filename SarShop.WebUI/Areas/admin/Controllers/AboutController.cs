using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;
using SarShop.DAL.Migrations;

namespace SarShop.WebUI.Areas.admin.Controllers
{
	[Area("admin"), Authorize]
	public class AboutController : Controller
	{
		IRepository<About> repoAbout;
		public AboutController(IRepository<About> _repoAbout)
		{
			repoAbout = _repoAbout;
		}

		[Route("/admin/hakkimizda")]
		public IActionResult Index()
		{
			return View(repoAbout.GetAll());
		}

		[Route("/admin/hakkimizda/yeni")]
		public IActionResult New()
		{
			return View();
		}


		[Route("admin/hakkimizda/yeni"), HttpPost]
		public async Task<IActionResult> New(About model)
		{
			
			await repoAbout.Add(model);
			return Redirect("/admin/hakkimizda");
		}

		[Route("/admin/hakkimizda/duzenle"), HttpPost]
		public async Task<IActionResult> Edit(About model)
		{

			await repoAbout.Update(model);
			return Redirect("/admin/hakkimizda");
		}


		[Route("/admin/hakkimizda/duzenle")]
		public IActionResult Edit(int id)
		{
			return View(repoAbout.GetBy(x=>x.ID==id));
		}





	

		[Route("/admin/hakkimizda/sil"), HttpPost]
        public async Task<string> Delete(int id)
        {
			try
			{
				About about = repoAbout.GetBy(x => x.ID == id) ?? null;
				if (about != null) await repoAbout.Delete(about);
				return "OK";
			}
			catch (Exception ex)
			{

				return ex.Message;
			}
		}
	}
}
