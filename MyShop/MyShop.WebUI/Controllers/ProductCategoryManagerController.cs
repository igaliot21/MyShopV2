using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        //ProductCategoryRepository context;
        InMemoryRepository<ProductCategory> context;
        public ProductCategoryManagerController() {
            //context = new ProductCategoryRepository();
            context = new InMemoryRepository<ProductCategory>();

        }
        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }
        public ActionResult Create() {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory) {
            if (!ModelState.IsValid) return View(productCategory);
            else {
                context.Insert(productCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string ID) {
            ProductCategory productCategory = context.Find(ID);
            if (productCategory == null) return HttpNotFound();
            else return View(productCategory);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string ID) {
            ProductCategory productCategoryToEdit = context.Find(ID);
            if (productCategoryToEdit == null) return HttpNotFound();
            else {
                if (!ModelState.IsValid) return View(productCategory);
                else {
                    productCategoryToEdit.Name = productCategory.Name;
                    context.Commit();

                    return RedirectToAction("Index");
                }
            }
        }
        public ActionResult Delete(string ID) {
            ProductCategory productCategory = context.Find(ID);
            if (productCategory == null) return HttpNotFound();
            else return View(productCategory);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID) {
            ProductCategory productCategoryToDelete = context.Find(ID);
            if (productCategoryToDelete == null) return HttpNotFound();
            else {
                context.Delete(productCategoryToDelete.Id);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}