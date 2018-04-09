using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoodTruckPlus.Models
{
    public class Menu
    {
        public int ID { get; set;}

         List <MenuItem> MenuItems { get; set; }

    }
}