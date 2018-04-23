using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace FoodTruckPlus.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [ForeignKey("Address")]
        public int AddressId {get; set;}
        public Address Address { get; set; }
        public string UserId { get; set; }

        public bool ReceiveEmails { get; set; }
    }
}