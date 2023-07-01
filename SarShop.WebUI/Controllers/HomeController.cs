using Microsoft.AspNetCore.Mvc;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;
using SarShop.WebUI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SarShop.WebUI.Controllers
{
	public class HomeController : Controller
	{
		IRepository<Slide> repoSlide;
		IRepository<Product> repoProduct;
		IRepository<Category> repoCate;
		public HomeController(IRepository<Slide> _repoSlide, IRepository<Category> repoCate, IRepository<Product> _repoProduct)
		{
			repoProduct = _repoProduct;
			repoSlide = _repoSlide;
			this.repoCate= repoCate;
		}
		public IActionResult Index()
		{
			IndexVM indexVM = new IndexVM
			{
				Slides = repoSlide.GetAll().OrderBy(o => o.DisplayIndex),
				Products= repoProduct.GetAll().Include(x => x.ProductPictures).OrderBy(x => Guid.NewGuid()).Take(9),

			};
			return View(indexVM);
		}
	}
}
