using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        //private string id;
        private string name;
        public ProductCategory()
        {
            // this.id = Guid.NewGuid().ToString();
        }
        public ProductCategory(string Name)
        {
            //this.id = Guid.NewGuid().ToString();
            this.name = Name;
        }
        /*
        public string Id
        {
            get { return this.id; }
        }
        */
        [StringLength(50)]
        [DisplayName("Product Category Name")]
        [Required]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
