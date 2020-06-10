using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class OrderItem : BaseEntity
    {
        private string orderid;
        private string productid;
        private string productname;
        private int price;
        private string image;
        public int quantity;

        public OrderItem() { }
        public OrderItem(string ProductId, string ProductName, int Price, string Image, int Quantity)
        {
            this.productid = ProductId;
            this.productname = ProductName;
            this.price = Price;
            this.image = Image;
            this.quantity = Quantity;
        }
        public OrderItem(string OrderId, string ProductId, string ProductName, int Price, string Image, int Quantity) {
            this.orderid = OrderId;
            this.productid = ProductId;
            this.productname = ProductName;
            this.price = Price;
            this.image = Image;
            this.quantity = Quantity;
        }
        public string OrderId{
            get { return this.orderid; }
            set { this.orderid = value; }
        }
        public string ProductId{
            get { return this.productid; }
            set { this.productid = value; }
        }
        public string ProductName{
            get { return this.productname; }
            set { this.productname = value; }
        }
        public int Price{
            get { return this.price; }
            set { this.price = value; }
        }
        public string Image{
            get { return this.image; }
            set { this.image = value; }
        }
        public int Quantity{
            get { return this.quantity; }
            set { this.quantity = value; }
        }
    }
}
