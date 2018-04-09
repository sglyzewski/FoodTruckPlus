using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckPlus.Models
{
    public class Order
    {public int Id { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public double Price { get; set; }
        public bool Paid { get; set; }
        public DateTime TimePurchased { get; set; }

        public DateTime TimeDesiredReady { get; set; }
    }
}