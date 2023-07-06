using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;

namespace SarShop.WebUI.ViewComponets
{
	public class FooterViewComponent : ViewComponent
	{
		IRepository<Aboutt> repoAbout;

		public FooterViewComponent(IRepository<Aboutt> _repoAbout)
		{
			repoAbout = _repoAbout;
		}
		public IViewComponentResult Invoke()
		{
			var response = repoAbout.GetAll().OrderBy(x => x.DisplayIndex).ToList();
			return View(response);
		}
	}
}
