using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_EX.Model
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public float Rating { get; set; }

        public bool Login(string email, string password)
        {
            // Check email and password
            return (Email == email && Password == password);
        }

        public bool Register(string firstName, string lastName, string phone, string email, string password)
        {
            // Register new seller
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Password = password;
            return true;
        }

        public void UpdateProfile(string firstName, string lastName, string phone)
        {
            // Update seller profile
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }

}
