﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckPlus.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        [ForeignKey("FullMenu")]
        public int FullMenuId { get; set; }

        public FullMenu FullMenu { get; set; }
     
    }
}