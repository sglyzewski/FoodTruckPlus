using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Dtos;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.ViewModels
{
    public class OrdersViewModel
    {
        public OrderDto Order { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<MenuItem> Cart { get; set; }
       
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public int TemporaryItemId { get; set; }

    }
}