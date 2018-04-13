using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using FoodTruckPlus.Models;
using System.Threading;
using System.Threading.Tasks;



namespace FoodTruckPlus.ViewModels
{
    public class MenuCreationViewModel
    {
        public FullMenu FullMenu { get; set; }

        public MenuItem MenuItem { get; set; }

        public Ingredient Ingredient { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<int> IngredientMenuItemIds { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }
}