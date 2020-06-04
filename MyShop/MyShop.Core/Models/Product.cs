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
    public class Product
    {
        private string id;
        private string name;
        private string description;
        private decimal price;
        private string category;
        private string image;
        public Product() {
            this.id = Guid.NewGuid().ToString();
        }
        public Product(string Name, string Description, decimal Price, string Category)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = Name;
            this.description = Description;
            this.price = Price;
            this.category = Category;
            this.image = ""; // TODO poner una imagen por defecto
        }
        public Product(string Name, string Description, decimal Price, string Category, string Image)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = Name;
            if (Description == null || Description == "" || Description == " ") this.description = "No description";
            else this.description = Description;
            this.price = Price;
            this.category = Category;
            this.image = Image;
        }
        public string Id{
            get { return this.id; }
        }
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
        [Range(0.10, 1000, ErrorMessage = "Price must be positive")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Price is required")]
        public decimal Price
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
