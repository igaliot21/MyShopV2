﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core;
using MyShop.Core.Models;

/* classes no longer in use, kept just for research purposes*/

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository() {
            products = cache["products"] as List<Product>;
            if (products == null) {
                products = new List<Product>();
            }
        }
        public void Commit() {
            cache["products"] = products;
        }
        public void Insert(Product product) {
            products.Add(product);
        }
        public void Update(Product product) {
            Product productToUpdate = products.Find(p=>p.Id==product.Id);
            if (productToUpdate != null) productToUpdate = product;
            else throw new Exception("Product not found");
        }
        public Product Find(string ID) {
            Product productToFind = products.Find(p => p.Id == ID);
            if (productToFind != null) return productToFind;
            else throw new Exception("Product not found");
        }
        public IQueryable<Product> Collection() {
            return products.AsQueryable();
        }
        public void Delete(string ID) { 
            Product productToDelete = products.Find(p => p.Id == ID);
            if (productToDelete != null) products.Remove(productToDelete);
            else throw new Exception("Product not found");
        }
    }
}
