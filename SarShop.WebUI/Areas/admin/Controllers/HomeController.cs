using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;
using SarShop.WebUI.Tools;
using System.Security.Claims;

namespace SarShop.WebUI.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class HomeController : Controller
    {
        IRepository<Admin> repoAdmin;
        public HomeController(IRepository<Admin> _repoAdmin)
        {
            repoAdmin= _repoAdmin;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/admin/login"),AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [Route("/admin/login"), HttpPost,AllowAnonymous]
        public async Task< IActionResult> Login(string Username,string Password,string ReturnUrl)
        {
           
            string md5Password = GeneralTools.getMD5(Password);
            Admin admin=repoAdmin.GetBy(x=>x.UserName==Username&&x.Password== md5Password) ??null;
            if (admin != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid,admin.ID.ToString()),
                    new Claim(ClaimTypes.Name,admin.Name+" "+admin.Surname),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "DivisimaAuth");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
                if (string.IsNullOrEmpty(ReturnUrl)) return Redirect("/admin");
                else return Redirect(ReturnUrl);
            }
            else 
            {
                ViewBag.Error = "geçersiz kullanıcı adı veya şifre ";
            }
            return View();
            
        }
        [Route("/admin/cikis")]
        public async Task <IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
       
    }
}
