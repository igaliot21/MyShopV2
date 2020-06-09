using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Product : BaseEntity
    {
        private string name;
        private string description;
        private int price;
        private string category;
        private string image;
        public Product() {
            //this.id = Guid.NewGuid().ToString();
        }
        public Product(string Name, string Description, int Price, string Category)
        {
            //this.id = Guid.NewGuid().ToString();
            this.name = Name;
            this.description = Description;
            this.price = Price;
            this.category = Category;
            this.image = ""; // TODO poner una imagen por defecto
        }
        public Product(string Name, string Description, int Price, string Category, string Image)
        {
            //this.id = Guid.NewGuid().ToString();
            this.name = Name;
            if (Description == null || Description == "" || Description == " ") this.description = "No description";
            else this.description = Description;
            this.price = Price;
            this.category = Category;
            this.image = Image;
        }
        public Product(string Id, string Name, int Price)
        {
            this.Id = Id;
            this.name = Name;
            this.price = Price;
        }
        /*
        public string Id{
            get { return this.id; }
        }
        */
        [StringLength(50)]
        [DisplayName("Product Name")]
        [Required]
        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        [Range(1, 1000)]
        [Required]
        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        [Required]
        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
        public string Image
        {
            get { return this.image; }
            set { this.image = value; }
        }
    }
}
