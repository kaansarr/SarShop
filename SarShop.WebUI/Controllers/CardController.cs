using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;
using SarShop.WebUI.Models;

namespace SarShop.WebUI.Controllers
{
	public class CardController : Controller
	{

		IRepository<Product> repoProduct;
		public CardController(IRepository<Product> _repoProduct)
		{
			repoProduct = _repoProduct;
		}

		[Route("/sepetim")]
		public IActionResult Index()
		{
			if (Request.Cookies["MyCart"] != null)
			{
				return View(JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]));
			}
			else return Redirect("/");

		}

		[Route("/sepetim/sayiver")]
		public int GetCartCount()
		{
			if (Request.Cookies["MyCart"] != null)
			{
				return JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]).Sum(x => x.Quantity);
			}
			else return 0;
		}

		[Route("/sepetim/sil")]
		public string RemoveCart(int productid)
		{
			if (Request.Cookies["MyCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
				carts.Remove(carts.FirstOrDefault(x => x.ID == productid));
				CookieOptions cookieOptions = new();
				cookieOptions.Expires = DateTime.Now.AddDays(3);
				Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions);
				return "OK";
			}
			else return "";
		}


		[Route("/sepetim/ekle")]
		public string AddCart(int productid, int quantity)
		{
			Product product = repoProduct.GetAll(x => x.ID == productid).Include(x => x.ProductPictures).FirstOrDefault() ?? null;
			if (product != null)
			{
				Cart cart = new Cart
				{
					ID = product.ID,
					Name = product.Name,
					Picture = product.ProductPictures.Any() ?
					product.ProductPictures.FirstOrDefault().Picture : "/img/urunhazirlaniyor.jpg",
					Price = product.Price,
					Quantity = quantity
				};
				List<Cart> carts = new List<Cart>();
				bool urunVarmi = false;
				if (Request.Cookies["MyCart"] != null)
				{
					carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);

					foreach (Cart _cart in carts)
					{
						if (_cart.ID == productid)
						{
							urunVarmi = true;
							_cart.Quantity += quantity;
							if (product.Stock < _cart.Quantity) _cart.Quantity = product.Stock;
							break;

						}


					}
				}
				if (urunVarmi == false) carts.Add(cart);
				CookieOptions cookieOptions = new();
				cookieOptions.Expires = DateTime.Now.AddDays(3);
				Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions);
				return product.Name;
			}
			else return "";

		}
	}
}
