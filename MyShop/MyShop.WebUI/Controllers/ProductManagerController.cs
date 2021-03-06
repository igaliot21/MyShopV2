﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Intefaces;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductManagerController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        //InMemoryRepository<Product> context;
        //InMemoryRepository<ProductCategory> productCategories;
        //ProductRepository context;
        //ProductCategoryRepository productCategories;
        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoriesContext)
        {
            this.context = productContext;
            this.productCategories = productCategoriesContext;
            //context = new ProductRepository();
            //productCategories = new ProductCategoryRepository();
            //context = new InMemoryRepository<Product>();
            //productCategories = new InMemoryRepository<ProductCategory>();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create() {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            //Product product = new Product(); // se pase el viewmodel en lugar el model normal, esto es para pasar varios models (un objeto que contiene varios objetos vamos)
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase imageFile) {
            if (!ModelState.IsValid) return View(product);
            else {
                if (imageFile != null)
                {
                    product.Image = product.Id + Path.GetExtension(imageFile.FileName);
                    imageFile.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                }
                else product.Image = "Default.jpg";

                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id) {
            Product product = context.Find(Id);
            if (product == null) return HttpNotFound();
            else {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);
                //return View(product); // se pase el viewmodel en lugar el model normal, esto es para pasar varios models (un objeto que contiene varios objetos vamos)
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, string Id, HttpPostedFileBase imageFile) {
            Product productToEdit = context.Find(Id);
            if (productToEdit == null) return HttpNotFound();
            else {
                if (!ModelState.IsValid) return View(product);
                else {
                    productToEdit.Name        = product.Name;
                    productToEdit.Description = product.Description;
                    productToEdit.Price       = product.Price;
                    productToEdit.Category    = product.Category;

                    if (imageFile != null)
                    {
                        productToEdit.Image = product.Id + Path.GetExtension(imageFile.FileName);
                        imageFile.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                    }

                    context.Commit();

                    return RedirectToAction("Index");
                }
            }
        }
        public ActionResult Delete(string Id) {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null) return HttpNotFound();
            else return View(productToDelete);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id) {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null) return HttpNotFound();
            else {
                context.Delete(productToDelete.Id);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}