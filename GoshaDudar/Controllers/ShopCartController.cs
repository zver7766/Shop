using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoshaDudar.Data.Interfaces;
using GoshaDudar.Data.Models;
using GoshaDudar.Data.Repository;
using GoshaDudar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GoshaDudar.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep , ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            
            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            return View(obj);
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            var item = _carRep.GetAllCars.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.RemoveFromCart(item);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRep.GetAllCars.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
