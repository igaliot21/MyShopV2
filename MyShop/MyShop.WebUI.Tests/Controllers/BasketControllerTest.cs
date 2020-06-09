using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop.Core.Intefaces;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.Services;
using MyShop.WebUI.Controllers;
using MyShop.WebUI.Tests.Mocks;

namespace MyShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class BasketControllerTest
    {
        [TestMethod]
        public void CanAddBasketServiceItem()
        {
            //Setup
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Product> products = new MockContext<Product>();

            var httpContext = new HttpMockContext();

            IBasketService basketService = new BasketService(products, baskets);

            //Act
            basketService.AddToBasket(httpContext,"1");

            Basket basket = baskets.Collection().FirstOrDefault();

            //Assert
            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count);
            Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);
        }
        [TestMethod]
        public void CanAddBasketControllerItem()
        {
            //Setup
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Product> products = new MockContext<Product>();

            var httpContext = new HttpMockContext();

            IBasketService basketService = new BasketService(products, baskets);
            var controller = new BasketController(basketService);
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            //Act
            controller.AddToBasket("1");

            Basket basket = baskets.Collection().FirstOrDefault();

            //Assert
            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count);
            Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);
        }
        [TestMethod]
        public void CanGetSummaryViewModel() {
            //Setup
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Product> products = new MockContext<Product>();

            //Act
            products.Insert(new Product("1", "Cosa1", 5));
            products.Insert(new Product("2", "Cosa2", 10));
            products.Insert(new Product("3", "Cosa3", 15));

            Basket basket = new Basket();
            basket.BasketItems.Add(new BasketItem("1", "1", 2));
            basket.BasketItems.Add(new BasketItem("1", "2", 1));
            baskets.Insert(basket);
            IBasketService basketService = new BasketService(products, baskets);
            
            var controller = new BasketController(basketService);
            var httpContext = new HttpMockContext();
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id });
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            var result = controller.BasketSummary() as PartialViewResult;
            var basketSummary = (BasketSummaryViewModel) result.ViewData.Model;

            //Assert
            Assert.AreEqual(3, basketSummary.BasketCount);
            Assert.AreEqual(20, basketSummary.BasketTotal);
        }
    }
}
