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
        public List<Order> GetOrderList() {
            return orderContext.Collection().ToList();
        }
        public Order GetOrder(string Id) {
            return orderContext.Find(Id);
        }
        public void UpdateOrder(Order UpdatedOrder) {
            orderContext.Update(UpdatedOrder);
            orderContext.Commit();
        }
        public void DeleteOrder(string Id) {
            orderContext.Delete(Id);
            orderContext.Commit();
        }
    }
}
