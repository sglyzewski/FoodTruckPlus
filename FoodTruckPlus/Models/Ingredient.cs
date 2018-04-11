using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTruckPlus.Models
{
    public class Ingredient
    {
        public int Id { get; set;}

        public string IngredientItem { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }

        public MenuItem MenuItem { get; set; }

    }
}