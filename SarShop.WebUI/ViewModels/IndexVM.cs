﻿using SarShop.DAL.Entities;

namespace SarShop.WebUI.ViewModels
{
    public class IndexVM
    {
      public  IEnumerable<Slide> Slides { get; set; }
      public  IEnumerable<Product> Products { get; set; }
      
        
    }
}
