using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;
using System.Security.Claims;

namespace SarShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        IRepository<Members> repoMember;
        public LoginController(IRepository<Members> _repoMember)
        {
            repoMember= _repoMember;
        }
        [Route("/SarShopMemberAuth/login"), AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/uye-giris-Yap"), AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Route("SarShopMemberAuth/login")]
        public async Task<IActionResult> Login(string Username, string Password, string ReturnUrl)
        {

            Members members= repoMember.GetBy(x => x.UserName == Username && x.Password == Password) ?? null;
            List<Claim> claims = new List<Claim> {

                                new Claim(ClaimTypes.PrimarySid, signCustomer.Id.ToString()),
                                new Claim(ClaimTypes.Name, signCustomer.Name),
                                 };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "SarShopMemberAuth");
            await HttpContext.SignInAsync("SarShopMemberAuth", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
            return RedirectToAction("sepetim/tamamla");     



        }




        [Route("/uye/logout")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Redirect("/");
            }
            catch (Exception)
            {

                throw;
            }

        }
}
