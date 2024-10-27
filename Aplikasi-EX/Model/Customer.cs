using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Login(string email, string password)
        {
            // Check email and password with stored data
            return (Email == email && Password == password);
        }

        public bool Register(string firstName, string lastName, string phone, string email, string password)
        {
            // Register a new customer
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Password = password;
            return true;
        }

        public void UpdateProfile(string firstName, string lastName, string phone)
        {
            // Update customer profile
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }

}
