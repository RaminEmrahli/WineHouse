﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Configuration;
using WineHouse.Models;

namespace WineHouse.Controllers
{
    public class BasketController : Controller
    {
        private readonly ApplicationContext _context;
        public BasketController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult ShoppingCart()
        {
            if (HttpContext.Session.GetString("Cart") == null)
            {
                ShoppingCartVM vm = new ShoppingCartVM();
                return View(vm);
            }
            else
            {
                // Session'dan veri çekmek için GetString ve SetString metodlarını kullanın
                // Örneğin, sepet bilgilerini JSON olarak saklayıp çekebilirsiniz
                string cartJson = HttpContext.Session.GetString("Cart");
                ShoppingCartVM cart = JsonConvert.DeserializeObject<ShoppingCartVM>(cartJson);
                return View(cart);
            }
        }

        public IActionResult AddItemToShoppingCart(int id)
        {
            ShoppingCartVM vm = new();
            if (HttpContext.Session.GetString("Cart") == null)
            {
                vm = new ShoppingCartVM();
            }
            else
            {
                string cartJson = HttpContext.Session.GetString("Cart");
                vm = JsonConvert.DeserializeObject<ShoppingCartVM>(cartJson);
            }
            var wine = _context.Wines.Include(x=>x.Category).FirstOrDefault(n => n.Id == id);
            var shoppingCartItem = vm.CardItems.FirstOrDefault(n => n.Wine.Id == id);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new CardItem()
                {
                    Wine = wine,
                    Amount = 1
                };
                vm.CardItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            vm.Total = vm.CardItems.Select(n => n.Wine.Price * n.Amount).Sum();
            string json = JsonConvert.SerializeObject(vm, settings);
            HttpContext.Session.SetString("Cart", json);
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            ShoppingCartVM vm = new();
            if (HttpContext.Session.GetString("Cart") == null)
            {
                vm = new ShoppingCartVM();
            }
            else
            {
                string cartJson = HttpContext.Session.GetString("Cart");
                vm = JsonConvert.DeserializeObject<ShoppingCartVM>(cartJson);
            }
            var movie = _context.Wines.Include(x=>x.Category).FirstOrDefault(n => n.Id == id);
            var shoppingCartItem = vm.CardItems.FirstOrDefault(n => n.Wine.Id == id);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    vm.CardItems.Remove(shoppingCartItem);
                }
            }
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            vm.Total = vm.CardItems.Select(n => n.Wine.Price * n.Amount).Sum();
            string json = JsonConvert.SerializeObject(vm, settings);
            HttpContext.Session.SetString("Cart", json);
            return RedirectToAction(nameof(ShoppingCart));
        }

    }
}
