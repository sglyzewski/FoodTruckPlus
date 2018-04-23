using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using FoodTruckPlus.Secrets;

namespace FoodTruckPlus.ViewModels
{
    public class MapViewModel
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Address { get; set; }

        public string apiKey = Keys.googleApiKey;
    }
}