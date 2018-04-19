using FoodTruckPlus.Models;
using FoodTruckPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using FoodTruckPlus.Dtos;
using FoodTruckPlus.Controllers.Api;
using AutoMapper;
using System.Net.Http;
using System.Web.Http;

using System.Web.Routing;

namespace FoodTruckPlus.Controllers
{
    public class OperationsController : Controller
    {

        private ApplicationDbContext _context;

        public OperationsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Operations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateNewFoodTruck()
        {

            var foodTruck = new FoodTruck();
            var address = new Address();
            
            var viewModel = new CreateFoodTruckViewModel()
            {
                FoodTruck = foodTruck,
                Address = address
            };

            return View("CreateNewFoodTruck", viewModel);
        }

        public ActionResult Orders()
        {
            var controller = new OrdersController();
            var viewmodel = controller.GetOrders().ToList();
            return View("Orders", viewmodel);
        }
        public ActionResult CreateFoodTruck(CreateFoodTruckViewModel viewModel)
        {
          
            
            _context.Addresses.Add(viewModel.Address);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            var addressInDb = _context.Addresses.SingleOrDefault(a => a.AddressLine1 == viewModel.Address.AddressLine1 && a.AddressLine2 == viewModel.Address.AddressLine2
            && a.City == viewModel.Address.City && a.State == viewModel.Address.State && a.Zipcode == viewModel.Address.Zipcode
            && a.Country == viewModel.Address.Country
         );
            viewModel.FoodTruck.AddressId = addressInDb.Id;
            viewModel.FoodTruck.FullMenuId = 1;
            _context.FoodTrucks.Add(viewModel.FoodTruck);
            

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return View("Index");
        }
    }
}