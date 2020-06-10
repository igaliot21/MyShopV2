using MyShop.Core.Intefaces;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> orderContext;
        public OrderService(IRepository<Order> orderContext) {
            this.orderContext = orderContext;
        }
        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems) {
                baseOrder.OrderItems.Add(new OrderItem(baseOrder.Id,item.Id, item.ProductName, item.Price, item.Image, item.Quantity));
            }
            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
    }
}
