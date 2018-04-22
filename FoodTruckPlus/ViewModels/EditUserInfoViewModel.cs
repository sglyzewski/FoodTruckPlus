using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.ViewModels
{
    public class EditUserInfoViewModel
    {
        public UserInfo User { get; set; }

        public Address Address { get; set; }
    }
}