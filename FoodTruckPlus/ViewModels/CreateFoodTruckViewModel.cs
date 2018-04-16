using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.ViewModels
{
    public class CreateFoodTruckViewModel
    {
        public FoodTruck FoodTruck { get; set; }
        public Address Address { get; set; }
    }
}