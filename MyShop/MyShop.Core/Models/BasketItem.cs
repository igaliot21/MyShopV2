using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public BasketItem() { }
        public BasketItem(string BasketId, string ProductId, int Quantity) {
            this.BasketId = BasketId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
        }
    }
}
