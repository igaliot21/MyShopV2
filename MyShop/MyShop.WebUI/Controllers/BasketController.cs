using MyShop.Core.Intefaces;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IRepository<Customer> customers;
        IBasketService basketService;
        IOrderService orderService;
        public BasketController(IBasketService BasketService, IOrderService OrderService, IRepository<Customer> Customers) {
            this.basketService = BasketService;
            this.orderService = OrderService;
            this.customers = Customers;
        }
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }
        public ActionResult AddToBasket(string ProductId) {
            basketService.AddToBasket(this.HttpContext, ProductId);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary() {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);
            return PartialView(basketSummary);
        }
        [Authorize]  // with this decorator we'll ensure the customer is logged in, if not... the mvc automatically redirects him/her/it to the login page.... magically it would seem
        public ActionResult Checkout() {
            Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);
            if (customer != null){
                Order order = new Order(customer.FirstName, customer.Lastname, customer.Email, customer.Street, customer.City, customer.State, customer.Zipcode);
                return View(order);
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order)
        {
            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";
            order.Email = User.Identity.Name;

            // code por process payment

            order.OrderStatus = "Payment Process Completed";
            orderService.CreateOrder(order, basketItems);
            basketService.ClearBasket(this.HttpContext);

            return RedirectToAction("Thankyou", new { OrderId = order.Id});
        }
        public ActionResult Thankyou(string OrderId) {
            ViewBag.OrderId = OrderId;
            return View();
        }

    }
}