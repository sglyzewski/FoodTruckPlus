using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckPlus.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public bool Paid { get; set; }
        public DateTime TimePurchased { get; set; }
        [Display(Name = "Time Desired Ready")]
        public DateTime TimeDesiredReady { get; set; }
        [Display(Name = "Menu Items")]
        public string MenuItems { get; set; }



        [ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }

        public UserInfo UserInfo { get; set; }


    }
}