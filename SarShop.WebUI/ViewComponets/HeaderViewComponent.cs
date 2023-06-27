using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SarShop.BL.Repositories;
using SarShop.DAL.Entities;

namespace SarShop.WebUI.ViewComponets
{
    public class HeaderViewComponent: ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
