using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace MyShop.Core.Models
{
    public class Order : BaseEntity
    {
        private string firstname;
        private string lastname;
        private string email;
        private string street;
        private string city;
        private string state;
        private string zipcode;
        private string orderstatus;

        public Order() {
            this.OrderItems = new List<OrderItem>();
        }
        public Order(string FirstName, string LastName, string Email, string Street, string City, string State, string Zipcode)
        {
            this.OrderItems = new List<OrderItem>();
            this.firstname = FirstName;
            this.lastname = LastName;
            this.email = Email;
            this.street = Street;
            this.city = City;
            this.state = State;
            this.zipcode = Zipcode;
        }
        public Order(string FirstName, string LastName, string Email, string Street, string City, string State, string Zipcode,List<OrderItem> OrderItems)
        {
            this.OrderItems = OrderItems;
            this.firstname = FirstName;
            this.lastname = LastName;
            this.email = Email;
            this.street = Street;
            this.city = City;
            this.state = State;
            this.zipcode = Zipcode;
        }
        [Required]
        [DisplayName("First Name")]
        public string FirstName{
            get { return this.firstname; }
            set { this.firstname = value; }
        }
        [Required]
        [DisplayName("Last Name")]
        public string Lastname{
            get { return this.lastname; }
            set { this.lastname = value; }
        }
        [Required]
        public string Email{
            get { return this.email; }
            set { this.email = value; }
        }
        [Required]
        public string Street{
            get { return this.street; }
            set { this.street = value; }
        }
        [Required]
        public string City{
            get { return this.city; }
            set { this.city = value; }
        }
        [Required]
        public string State{
            get { return this.state; }
            set { this.state = value; }
        }
        [Required]
        [DisplayName("Zip Code")]
        public string Zipcode{
            get { return this.zipcode; }
            set { this.zipcode = value; }
        }
        public string OrderStatus{
            get { return this.orderstatus; }
            set { this.orderstatus = value; }
        }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
