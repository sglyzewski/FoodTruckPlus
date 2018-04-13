using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.ViewModels
{
    public class MenuItemViewModel
    {
        //public MenuItemViewModel()
        //{
        //    MenuItem = new MenuItem();
        //    Ingredient = new Ingredient();
        //}

        public MenuItem MenuItem { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}