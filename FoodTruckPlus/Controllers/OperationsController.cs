using FoodTruckPlus.Models;
using FoodTruckPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

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
            var viewModel = new CreateFoodTruckViewModel();

            return View("CreateNewFoodTruck", viewModel);
        }

        public ActionResult CreateFoodTruck(CreateFoodTruckViewModel viewModel)
        {
            viewModel.FoodTruck.AddressId = viewModel.Address.Id;
            _context.Addresses.Add(viewModel.Address);
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