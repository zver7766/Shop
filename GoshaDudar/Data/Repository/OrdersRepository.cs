using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoshaDudar.Data;
using GoshaDudar.Data.Models;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDbContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }
        public  void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDbContent.Order.Add(order);
            appDbContent.SaveChanges();

            var items = shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.car.Id,
                    OrderId = order.Id,
                    Price = el.car.Price
                };
                appDbContent.OrderDetail.Add(orderDetail);
            } 
            
            appDbContent.SaveChanges();
        }
    }
}
