using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckPlus.Models
{
    public class Address

    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country {get; set;}

       
    }
}