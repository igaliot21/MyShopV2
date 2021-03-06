﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop.Core.Intefaces;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.WebUI;
using MyShop.WebUI.Controllers;

namespace MyShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestClass]
        public class UniTest1 { 
            [TestMethod]
            public void IndexPageDoesReturnProducts() {

                IRepository<Product> productContext = new Mocks.MockContext<Product>();
                IRepository<ProductCategory> productCategories = new Mocks.MockContext<ProductCategory>();

                productContext.Insert(new Product());

                HomeController controller = new HomeController(productContext, productCategories);

                var result = controller.Index() as ViewResult;
                var viewModel = (ProductListViewModel)result.ViewData.Model;

                Assert.AreEqual(1, viewModel.Products.Count());

            }
        }
        //[TestMethod]
        //public void Index()
        //{
        //    //// Arrange
        //    HomeController controller = new HomeController();

        //    //// Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    //// Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
