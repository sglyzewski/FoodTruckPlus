﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckPlus.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}