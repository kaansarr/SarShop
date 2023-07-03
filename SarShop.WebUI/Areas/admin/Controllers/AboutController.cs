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


		[HttpPost]
		[Route("/admin/hakkimizda/yeni")]
		public async Task<IActionResult> New([Bind("Title, Content")] About model)
		{
			if (ModelState.IsValid)
			{
				await repoAbout.Add(model);
				return Redirect("/admin/hakkimizda");
			}

			return View(model);
		}

		[HttpGet]
		[Route("/admin/hakkimizda/duzenle")]
		public IActionResult Edit(int id)
		{
			About about = repoAbout.GetBy(x => x.ID == id);
			if (about == null)
			{
				return NotFound();
			}

			return View(about);
		}

		[HttpPost]
		[Route("/admin/hakkimizda/duzenle")]
		public async Task<IActionResult> Edit(int id, [Bind("ID, Title, Content")] About model)
		{
			if (id != model.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await repoAbout.Update(model);
				}
				catch (Exception ex)
				{
					// Hata işleme kodu
					return View(model);
				}

				return Redirect("/admin/hakkimizda");
			}

			return View(model);
		}







		[HttpPost]
		[Route("/admin/hakkimizda/sil")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				About about = repoAbout.GetBy(x => x.ID == id);
				if (about != null)
				{
					await repoAbout.Delete(about);
					return Ok("OK");
				}

				return NotFound();
			}
			catch (Exception ex)
			{
				// Hata işleme kodu
				return StatusCode(500, ex.Message);
			}
		}
	}
}
