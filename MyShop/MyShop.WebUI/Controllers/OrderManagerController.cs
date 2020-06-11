using MyShop.Core.Intefaces;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        // GET: OrderManager
        IOrderService orderService;
        public OrderManagerController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();
            return View(orders);
        }
        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Payment Processed",
                "Order Shipped",
                "Order Complete"
            };
            Order order = orderService.GetOrder(Id);
            return View(order);
        }
        [HttpPost]
        public ActionResult UpdateOrder(Order UpdatedOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);
            if (order != null)
            {
                order.FirstName     = UpdatedOrder.FirstName;
                order.Lastname      = UpdatedOrder.FirstName;
                order.Street        = UpdatedOrder.FirstName;
                order.City          = UpdatedOrder.FirstName;
                order.State         = UpdatedOrder.FirstName;
                order.Zipcode       = UpdatedOrder.FirstName;
                order.OrderStatus   = UpdatedOrder.OrderStatus;
                orderService.UpdateOrder(order);
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Error");
        }
        public ActionResult DeleteOrder(string Id)
        {
            Order orderToDelete = orderService.GetOrder(Id);
            if (orderToDelete == null) return HttpNotFound();
            else return View(orderToDelete);
        }
        [HttpPost]
        [ActionName("DeleteOrder")]
        public ActionResult ConfirmDeleteOrder(string Id)
        {
            Order orderToDelete = orderService.GetOrder(Id);
            if (orderToDelete == null) return HttpNotFound();
            else
            {
                orderService.DeleteOrder(Id);
                return RedirectToAction("Index");
            }
        }
    }
}