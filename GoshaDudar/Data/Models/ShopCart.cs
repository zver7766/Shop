using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GoshaDudar.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDbContent;

        public ShopCart(AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }

        public List<ShopCarItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        private static int id;
        public  void AddToCart(Car car)
        {
            ShopCarItem item = new ShopCarItem
            {
                ShopCartId = this.ShopCartId,
                car = car,
                price = car.Price
            };
            appDbContent.ShopCarItem.Add(item);

            appDbContent.SaveChanges();
             id = item.Id;
        }

        public void RemoveFromCart(Car car)
        {
           
            ShopCarItem item = new ShopCarItem
            {
                Id = id,
                ShopCartId = ShopCartId,
                car = car,
                price = car.Price
            };
           
            //appDbContent.ShopCarItem.Find(item);
            appDbContent.ShopCarItem.Remove(item);
            appDbContent.SaveChanges();
        }

        public List<ShopCarItem> GetShopItems() => appDbContent.ShopCarItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        
    }
}
