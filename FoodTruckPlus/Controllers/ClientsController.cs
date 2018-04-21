using FoodTruckPlus.Models;
using FoodTruckPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;
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

        public ActionResult PlaceOrder(int menuId)
        {
            var userid = User.Identity.GetUserId();
            var currentUser = _context.UserInfoes.FirstOrDefault(u => u.UserId == userid);
            var dto = new OrderDto();
            var menuItems = _context.MenuItems.Where(i => i.FullMenuId == menuId).ToList();
            var viewModel = new OrdersViewModel() {
                Order = dto,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                MenuItems = menuItems
            };
            return View("PlaceOrder", viewModel);
        }

        public ActionResult PlaceOrder()
        {
            
            return View("OrderConfirmation");
        }
    }
}