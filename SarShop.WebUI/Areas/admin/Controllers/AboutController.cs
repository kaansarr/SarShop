using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;

namespace SarShop.WebUI.Areas.admin.Controllers
{
	[Area("admin"), Authorize]
	public class AboutController : Controller
	{
		IRepository<Aboutt> repoAbout;
		public AboutController(IRepository<Aboutt> _repoAbout)
		{
			repoAbout = _repoAbout;
		}

		[Route("/admin/footer")]
		public IActionResult Index()
		{
			return View(repoAbout.GetAll());
		}

		[Route("/admin/footer/yeni")]
		public IActionResult New()
		{
			return View();
		}
		[Route("admin/footer/yeni"), HttpPost]
		public async Task <IActionResult> New(Aboutt model)
		{
			
		     await repoAbout.Add(model);
			return Redirect("/admin/footer");
		}

		[Route("/admin/footer/duzenle")]
		public IActionResult Edit(int id)
		{
			return View(repoAbout.GetBy(x=>x.ID==id));
		}

		[Route("/admin/footer/duzenle"),HttpPost]
		public async Task<IActionResult> Edit(Aboutt model)
		{
			
		   await repoAbout.Update(model);
			return Redirect("/admin/footer");
		}

		[Route("/admin/footer/sil"), HttpPost]
        public async Task<string> Delete(int id)
        {
			try
			{
				Aboutt about = repoAbout.GetBy(x => x.ID == id) ?? null;
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
