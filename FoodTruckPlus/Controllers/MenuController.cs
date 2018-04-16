using FoodTruckPlus.Models;
using FoodTruckPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace FoodTruckPlus.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu

        private ApplicationDbContext _context;

        public MenuController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menus()
        {

            var menus = _context.FullMenus.ToList();
            var viewModel = new MenusViewModel()
            {
                FullMenus = menus
            };
            return View("Menus", viewModel);
        }

        public ActionResult CreateMenu(MenusViewModel viewModel)
        {
            _context.FullMenus.Add(viewModel.FullMenu);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Menus");
        }
        
        public ActionResult MenuForm(int id)
        {
            var fullMenu = _context.FullMenus.FirstOrDefault(m => m.Id == id);
          
            var ingredients = _context.Ingredients.ToList();
            List<int> ingredientMenuItemIds = new List<int>();
            
            foreach (var el in ingredients)
            {
                ingredientMenuItemIds.Add(el.MenuItemId);
            }
            var menuItems = _context.MenuItems.ToList();
            var viewModel = new MenuCreationViewModel()
            {
                FullMenu = fullMenu,
                Ingredients = ingredients,
                MenuItems = menuItems,
                IngredientMenuItemIds = ingredientMenuItemIds
            };

            return View("MenuForm", viewModel);

        }

     
        [HttpPost]
        public ActionResult SaveMenuItemDetails(MenuItemViewModel viewModel)
        {
            var menuItem = viewModel.MenuItem;
            
            var menuItemInDb = _context.MenuItems.FirstOrDefault(m => m.Id == menuItem.Id);
          
            if (menuItemInDb == null)
            {
                _context.MenuItems.Add(menuItem);
            }
            else
            {
                menuItemInDb.ItemName = menuItem.ItemName;
                menuItemInDb.Description = menuItem.Description;
                menuItemInDb.Price = Convert.ToDouble(menuItem.Price);
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("EditMenuItem", "Menu", new { id = menuItem.Id });
        }
      
        public ActionResult Menu(int id)
        {
            var fullMenu = _context.FullMenus.SingleOrDefault(m => m.Id == id);
            var menuItems = _context.MenuItems.Where(i => i.FullMenuId == fullMenu.Id).ToList();
            var ingredients = _context.Ingredients.ToList();
            var viewModel = new SingleMenuViewModel()
            {
                FullMenu = fullMenu,
                MenuItemsForFullMenu = menuItems,
                Ingredients = ingredients
            };

            return View("Menu", viewModel);
        }
        public ActionResult SaveMenuItem(MenuCreationViewModel viewModel)
        {
            //viewModel.MenuItem.FullMenuId = viewModel.FullMenu.Id;

            var fullMenuId = viewModel.FullMenu.Id;
           
            var menuItem = new MenuItem()
            {
                ItemName = viewModel.MenuItem.ItemName,
                Price = viewModel.MenuItem.Price,
                Description = viewModel.MenuItem.Description,
                FullMenuId = fullMenuId
                
            };

            var name = viewModel.Ingredient.IngredientItem;
            var ingredientToAdd = new Ingredient()
            {
                MenuItemId = menuItem.Id,
                IngredientItem = name
            };
            _context.MenuItems.Add(menuItem);
            _context.Ingredients.Add(ingredientToAdd);

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
      
            return RedirectToAction("MenuForm", "Menu", new { id = fullMenuId });
        }


        [HttpGet]
        public ActionResult EditMenuItem(int id)
        {
            var menuItem = _context.MenuItems.FirstOrDefault(m => m.Id == id);
            var ingredients = _context.Ingredients.Where(i => i.MenuItemId == menuItem.Id).ToList();
            //var temporaryIngredient = new Ingredient()
            //{
            //    IngredientItem = "temporary",
            //    MenuItemId = id
            //};
            var viewModel = new MenuItemViewModel()
            {
                MenuItem = menuItem,
                Ingredients = ingredients,
                //Ingredient = temporaryIngredient

            };

            return View("EditMenuItem", viewModel);
        }

        public ActionResult DeleteMenu(int id)
        {
            var menu = _context.FullMenus.SingleOrDefault(m => m.Id == id);
            _context.FullMenus.Remove(menu);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Menus");

        }


        public ActionResult AddIngredient(MenuItemViewModel viewModel)
        {

            var menuItemId = viewModel.MenuItem.Id;
            var name = viewModel.Ingredient.IngredientItem;
            var ingredientToAdd = new Ingredient()
            {
                MenuItemId = menuItemId,
                IngredientItem = name
            };

            _context.Ingredients.Add(ingredientToAdd);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            
  
            return RedirectToAction("EditMenuItem", "Menu", new { id = menuItemId});
        }
    }
}