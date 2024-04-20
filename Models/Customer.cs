using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Initialize an empty constructor
        public Customer()
        {
        }

        // Initialize the Customer object
        public Customer(string id, string name, string address, string phone, string email)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}
