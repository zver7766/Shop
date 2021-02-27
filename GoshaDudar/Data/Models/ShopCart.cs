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

        public  void AddToCart(Car car)
        {
            appDbContent.ShopCarItem.Add(new ShopCarItem
            {
                ShopCartId = ShopCartId,
                car = car,
                price = car.Price
            });

            appDbContent.SaveChanges();
        }

        public List<ShopCarItem> GetShopItems() => appDbContent.ShopCarItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        
    }
}
