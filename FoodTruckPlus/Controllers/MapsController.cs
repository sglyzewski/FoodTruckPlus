using FoodTruckPlus.Models;
using FoodTruckPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using FoodTruckPlus.Secrets;
using System.Net;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FoodTruckPlus.Controllers
{
    public class MapsController : Controller
    {
        // GET: Maps
        private ApplicationDbContext _context;

        public MapsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public MapViewModel GetMap(Address address)
        {
            string mapsKey = Keys.googleApiKey;
            string addressLine2;
            if (address.AddressLine2 ==null)
            {
                addressLine2 = "";
            }
            else
            {
                addressLine2 = address.AddressLine2 + "";
            }
          
            StringBuilder sb = new StringBuilder();
            sb.Append(address.AddressLine1 + " ");
            sb.Append(addressLine2);
            sb.Append(address.City + ", ");
            sb.Append(address.State + " ");
            sb.Append(address.Zipcode + " ");
            var addressString = sb.ToString();
            string url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key={1}", Uri.EscapeDataString(addressString), mapsKey);
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());
            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");
            string latitude = lat.ToString();
        
            latitude = Regex.Replace(latitude, "<.*?>", string.Empty);
            string longitude = lng.ToString();
            longitude = Regex.Replace(longitude, "<.*?>", string.Empty);
            var ViewModel = new MapViewModel()
            {
                Latitude = latitude,
                Longitude = longitude
            };

            return ViewModel;
        }

        public ActionResult Map(int id)
        {
            var address = _context.Addresses.SingleOrDefault(a => a.Id == id);
            var viewModel = GetMap(address);
            return View("Map", viewModel);
        }
    }
}