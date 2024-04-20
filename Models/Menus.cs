using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models
{
    public class Menus
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public double Cost { get; set; }

        // Initialize an empty constructor
        public Menus()
        {
        }

        // Initialize the Order object
        public Menus(string id, string type, string description, string size, double cost)
        {
            Id = id;
            Type = type;
            Description = description;
            Size = size;
            Cost = cost;  
        }
    }
}
