using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Customer : BaseEntity
    {
        private string userid;
        private string firstname;
        private string lastname;
        private string email;
        private string street;
        private string city;
        private string state;
        private string zipcode;

        public Customer() { }
        public Customer(string UserId, string FirstName, string LastName, string Email)
        {
            this.userid = UserId;
            this.firstname = FirstName;
            this.lastname = LastName;
            this.email = Email;
            this.street = String.Empty;
            this.city = String.Empty;
            this.state = String.Empty;
            this.zipcode = String.Empty;
        }
        public Customer(string UserId, string FirstName, string LastName, string Email, string Street, string City, string State, string Zipcode) {
            this.userid = UserId;
            this.firstname = FirstName;
            this.lastname = LastName;
            this.email = Email;
            this.street = Street;
            this.city = City;
            this.state = State;
            this.zipcode = Zipcode;
        }
        public string UserId{
            get { return this.userid; }
            set { this.userid = value; }
        }
        public string FirstName{
            get { return this.firstname; }
            set { this.firstname = value; }
        }
        public string Lastname{
            get { return this.lastname; }
            set { this.lastname = value; }
        }
        public string Email{
            get { return this.email; }
            set { this.email = value; }
        }
        public string Street{
            get { return this.street; }
            set { this.street = value; }
        }
        public string City{
            get { return this.city; }
            set { this.city = value; }
        }
        public string State{
            get { return this.state; }
            set { this.state = value; }
        }
        public string Zipcode{
            get { return this.zipcode; }
            set { this.zipcode = value; }
        }
    }
}
