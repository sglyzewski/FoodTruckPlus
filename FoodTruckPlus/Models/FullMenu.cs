using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckPlus.Models
{
    public class FullMenu
    {
        public int Id { get; set; }
        public string MenuTitle { get; set; }

        public List<MenuItem> MenuItems { get; set; }

    }
}