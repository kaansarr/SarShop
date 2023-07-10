﻿using Microsoft.AspNetCore.Mvc;
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
			return View();
		}
		[Route("/sepetim/ekle")]
		public string AddCart(int productid,int quantity)
		{
			Product product = repoProduct.GetAll(x => x.ID == productid).Include(x=>x.ProductPictures).FirstOrDefault() ?? null;
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
							break;
						}


					}
				}
				if(urunVarmi==false) carts.Add(cart);
				CookieOptions cookieOptions = new();
				cookieOptions.Expires = DateTime.Now.AddDays(3);
				Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions);
				return product.Name;
			}
			else return "";
			
		}
	}
}
