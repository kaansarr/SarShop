using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SarShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/SarShopMemberAuth/login"), AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        //[Route("SarShopMemberAuth/login")]
        //public async Task <IActionResult> Login()
        //{

        //    List<Claim> claims = new List<Claim> {

        //    					new Claim(ClaimTypes.PrimarySid, signCustomer.Id.ToString()),
        //    					new Claim(ClaimTypes.Name, signCustomer.Name),
        //    					 };
        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "SarShopMemberAuth");
        //    await HttpContext.SignInAsync("SarShopMemberAuth", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
        //    return RedirectToAction("sepetim/tamamla");
        //}

    }
}
