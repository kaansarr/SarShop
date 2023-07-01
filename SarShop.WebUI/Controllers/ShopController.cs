using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;
using SarShop.WebUI.ViewModels;

namespace SarShop.WebUI.Controllers
{
	public class ShopController : Controller
	{
		IRepository<Category> repoCate;
		IRepository<Product> repoProduct;
		public ShopController(IRepository<Category> _repoCate, IRepository<Product> _repoProduct)
		{
			repoCate = _repoCate;
			repoProduct = _repoProduct;
		}
		public IActionResult Index()
		{
			var categories = repoCate.GetAll().Include(x => x.SubCategories).OrderBy(x => x.DisplayIndex).ThenBy(x => x.Name);
			var products = repoProduct.GetAll().Include(x => x.ProductPictures).OrderBy(x => Guid.NewGuid()).Take(50);
			ShopVM shopVM = new ShopVM
			{
				Categories = categories,
				Products = products,
			};
			return View(shopVM);
		}

		[Route("detay/{name}-{id}")]
		public IActionResult ProductDetail(int id,string name)
		{

			Product product= repoProduct.GetAll().Include(x => x.ProductPictures).FirstOrDefault(x => x.ID == id);
			ProductDetailVM vm = new ProductDetailVM
			{
				Product = product,
				RelatedProducts = repoProduct.GetAll(x => x.BrandID == product.BrandID && x.ID != id).Include(i=>i.ProductPictures).OrderBy(x=>Guid.NewGuid()).Take(3) 
		};
			return View(vm);	
		}
	}
}
