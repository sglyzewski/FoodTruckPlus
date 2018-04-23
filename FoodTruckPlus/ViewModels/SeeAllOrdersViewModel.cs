using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTruckPlus.Dtos;
using FoodTruckPlus.Models;

namespace FoodTruckPlus.ViewModels
{
    public class SeeAllOrdersViewModel
    {
        public IEnumerable<OrderDto> Orders { get; set; }
        public IEnumerable<UserInfo> UserInfos { get; set; }
    }
}