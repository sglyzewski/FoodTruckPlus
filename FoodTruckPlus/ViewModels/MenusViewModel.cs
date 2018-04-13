using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.ViewModels
{
    public class MenusViewModel
    {
        public FullMenu FullMenu { get; set; }
        public IEnumerable<FullMenu> FullMenus { get; set; }
    }
}