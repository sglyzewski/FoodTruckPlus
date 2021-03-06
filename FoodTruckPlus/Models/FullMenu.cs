﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckPlus.Models
{
    public class FullMenu
    {
        public int Id { get; set; }
        [Display(Name = "Menu Title")]
        public string MenuTitle { get; set; }

        public List<MenuItem> MenuItems { get; set; }

    }
}