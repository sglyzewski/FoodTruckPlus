using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.ViewModels
{
    public class SingleMenuViewModel
    {
        public FullMenu FullMenu { get; set; }
        public IEnumerable<MenuItem> MenuItemsForFullMenu {get; set;}
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}