using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core;
using MyShop.Core.Models;

/* classes no longer in use, kept just for research purposes*/

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository() {
            productCategories = cache["productsCategories"] as List<ProductCategory>;
            if (productCategories == null) {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Commit() {
            cache["productsCategories"] = productCategories;
        }
        public void Insert(ProductCategory productCategory) {
            productCategories.Add(productCategory);
        }
        public void Update(ProductCategory productCategory) {
            ProductCategory productCategoryToUpdate = productCategories.Find(pc=>pc.Id==productCategory.Id);
            if (productCategoryToUpdate != null) productCategoryToUpdate = productCategory;
            else throw new Exception("Product Category not found");
        }
        public ProductCategory Find(string ID) {
            ProductCategory productCategoryToFind = productCategories.Find(pc=>pc.Id==ID);
            if (productCategoryToFind != null) return productCategoryToFind;
            else throw new Exception("Product Category not found");
        }
        public IQueryable<ProductCategory> Collection() {
            return productCategories.AsQueryable();
        }
        public void Delete(string ID) {
            ProductCategory productCategoryToDelete = productCategories.Find(pc => pc.Id == ID);
            if (productCategoryToDelete != null) productCategories.Remove(productCategoryToDelete);
            else throw new Exception("Product Category not found");
        }
    }
}
