using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using FoodTruckPlus.Models;
using System.Web;

namespace FoodTruckPlus.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public bool Paid { get; set; }
        public DateTime TimePurchased { get; set; }
        public DateTime TimeDesiredReady { get; set; }
        public string MenuItems { get; set; }
        public int? MinutesUntilReady {get; set;}


    }
}