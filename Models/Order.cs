using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MenuItemId { get; set; }
        public string MenuItemType { get; set; }
        public string MenuItemDescription { get; set; }
        public string MenuItemSize { get; set; }
        public double MenuItemCost { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }


        // Initialize an empty constructor
        public Order()
        {
        }

        // Initialize the Order object
        public Order(string id, string type, string description, string size, double cost, string name, string email)
        {
            Id = id;
            Type = type;
            Description = description;
            Size = size;
            Cost = cost;
            Name = name;
            Email = email;
        }
    }
}
