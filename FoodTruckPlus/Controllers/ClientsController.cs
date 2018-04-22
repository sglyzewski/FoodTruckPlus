using FoodTruckPlus.Models;
using FoodTruckPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
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
  
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditUserInfo()
        {
            return View();
        }

        public ActionResult PlaceOrder()
        {
            int menuId = 1;
            var userid = User.Identity.GetUserId();
            var currentUser = _context.UserInfoes.FirstOrDefault(u => u.UserId == userid);
            var dto = new OrderDto();
            var menuItems = _context.MenuItems.Where(i => i.FullMenuId == menuId).ToList();
            var cart = new List<MenuItem>();
            var viewModel = new OrdersViewModel() {
                Order = dto,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                MenuItems = menuItems,
                Cart = cart
            };
            return View("PlaceOrder", viewModel);
        }

        public ActionResult SaveUserInfo(EditUserInfoViewModel viewModel)
        {
            var userid = User.Identity.GetUserId();
            _context.Addresses.Add(viewModel.Address);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            var addressInDb = _context.Addresses.SingleOrDefault(a => a.AddressLine1 == viewModel.Address.AddressLine1 && a.AddressLine2 == viewModel.Address.AddressLine2 && a.City == viewModel.Address.City);
            var userInfo = new UserInfo()
            {
                FirstName = viewModel.User.FirstName,
                LastName = viewModel.User.LastName,
                UserId = userid,
                AddressId = addressInDb.Id


            };
            _context.UserInfoes.Add(userInfo);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return View("MyFoodTrucks");
        }

        public ActionResult AddToCart(OrdersViewModel viewModel)
        {
            
            var menuItemInDb = _context.MenuItems.SingleOrDefault(m => m.Id == viewModel.TemporaryItemId);
            viewModel.Cart.Add(menuItemInDb);
            return View("PlaceOrder", viewModel);
        }

        //public ActionResult PlaceOrder()
        //{
            
        //    return View("OrderConfirmation");
        //}
    }
}