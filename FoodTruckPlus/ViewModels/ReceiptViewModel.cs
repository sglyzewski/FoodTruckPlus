using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.ViewModels
{
    public class ReceiptViewModel
    {
        public List<MenuItem> Cart { get; set; }
        public double Total { get; set; }
        public string TotalString { get; set; }
    }
}