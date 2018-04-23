using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckPlus.Models
{
    public class FoodTruck
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("FullMenu")]
        public int FullMenuId { get; set; }
        public FullMenu FullMenu { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public string Email { get; set; }
       
    }
}