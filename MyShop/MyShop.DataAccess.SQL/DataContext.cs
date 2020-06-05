using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        private DbSet<Product> products;
        private DbSet<ProductCategory> productsCategories;
        public DataContext() : base("DefaultConnection") { 
        }
        public DbSet<Product> Products {
            get {return this.products ;}
            set {this.products = value; } 
        }
        public DbSet<ProductCategory> ProductsCategories
        {
            get { return this.ProductsCategories; }
            set { this.ProductsCategories = value; }
        }
    }
}
