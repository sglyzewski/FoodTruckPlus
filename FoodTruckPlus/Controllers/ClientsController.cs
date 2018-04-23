using FoodTruckPlus.Models;
using FoodTruckPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using FoodTruckPlus.Dtos;
using FoodTruckPlus.Controllers.Api;
using AutoMapper;
using System.Net.Http;


using System.Web.Routing;

namespace FoodTruckPlus.Controllers
{
  
    [Authorize]
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

        public ActionResult AddFirstItemToCart()
        {
            int menuId = 1;
            var userid = User.Identity.GetUserId();
            var currentUser = _context.UserInfoes.FirstOrDefault(u => u.UserId == userid);
           
            var menuItems = _context.MenuItems.Where(i => i.FullMenuId == menuId).ToList();
            var cart = new List<MenuItem>();
            var viewModel = new OrdersViewModel()
            {
               
                UserInfoId = currentUser.Id,
                Cart = cart,
                MenuItems = menuItems,
               
            };
            return View("AddFirstItemToCart", viewModel);
        }


        public ActionResult PlaceOrder()
        {
            return View("PlaceOrder");
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
                AddressId = addressInDb.Id,
                ReceiveEmails = viewModel.User.ReceiveEmails


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

        public ActionResult Receipt()
        {
            var cart = _context.Carts.ToList();
            var menuItems = new List<MenuItem>();
            double price = 0;
           
            foreach(var el in cart)
            {
                var item = _context.MenuItems.SingleOrDefault(x => x.Id == el.MenuItemId);
                menuItems.Add(item);
                price += item.Price;
            }
            string pricestring = String.Format("{0:C}", price);



           var viewModel = new ReceiptViewModel()
            {
                Cart =  menuItems,
                Total = price,
                TotalString = pricestring

            };
            return View("Receipt", viewModel);
        }

        public ActionResult SubmitAndEmail()
        {
            var cartItemsToDelete = _context.Carts.Where(x => x.CurrentCart == 0).ToList();
            foreach (var el in cartItemsToDelete)
            {
                _context.Carts.Remove(el);
            }

            _context.SaveChanges();
            return View("Index");
        }

        public ActionResult AddToCart(OrdersViewModel viewModel)
        {
            int menuId = 1;
            var menuItemInDb = _context.MenuItems.SingleOrDefault(m => m.Id == viewModel.TemporaryItemId);
            var menuItems = _context.MenuItems.Where(i => i.FullMenuId == menuId).ToList();
            viewModel.MenuItems = menuItems;
            var cart = new Cart()
            {
                MenuItemId = menuItemInDb.Id,
                CurrentCart = 0
            };

            _context.Carts.Add(cart);
           
            _context.SaveChanges();
            var carts = _context.Carts.ToList();
            foreach(var el in carts)
            {
                var menuItem = _context.MenuItems.SingleOrDefault(m => m.Id == el.MenuItemId);
                viewModel.Cart.Add(menuItem);
            }
           
            return View("PlaceOrder", viewModel);
        }



     
        public ActionResult SubmitCart()
        {
            var replacementList = new List<MenuItem>();
            var controller = new OrdersController();
            double price = 0;
            List<MenuItem> tempList = new List<MenuItem>();
            string menuItems = "";
            var cart = _context.Carts.ToList();
            foreach(var el in cart)
            {
                var food = _context.MenuItems.SingleOrDefault(x => x.Id == el.MenuItemId);
                tempList.Add(food);
            }
            foreach (var el in tempList) {

                price += el.Price;
                menuItems += (el.ItemName + ",");
            }

            var userid = User.Identity.GetUserId();
            var userInfoId = _context.UserInfoes.SingleOrDefault(x => x.UserId == userid).Id;
            var order = new Order()
            {
                Price = price,
                MenuItems = menuItems,
                TimePurchased = DateTime.Now,
                TimeDesiredReady = DateTime.Now,
                UserInfoId = userInfoId
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        
            return RedirectToAction("Receipt");
        }

      
        //public ActionResult PlaceOrder()
        //{
            
        //    return View("OrderConfirmation");
        //}
    }
}