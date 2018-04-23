using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Dtos;
using FoodTruckPlus.Models;
using System.Web.Mvc;

namespace FoodTruckPlus.ViewModels
{
    public class OrdersViewModel
    {
       

       
        public List<MenuItem> Cart { get; set; }
       
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public int TemporaryItemId { get; set; }

        public DateTime TimeDesiredRead { get; set; }
        public int UserInfoId { get; set; }

        public DateTime TimeDesiredReady { get; set; }
        

    }
}