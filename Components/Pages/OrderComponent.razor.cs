using Microsoft.AspNetCore.Components;
using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RestaurantManagementSystem.Pages
{
    public partial class OrderComponent : ComponentBase
    {
        public List<Order> Orders { get; set; }
        public List<Order> FilteredOrders { get; set; }
        public string Name { get; set; }

        protected override void OnInitialized()
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            Orders = new List<Order>();

            try
            {
                string resDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot/data");
                string filename = "OrderList.txt";
                string filepath = Path.Combine(resDirectory, filename);

                string[] lines = File.ReadAllLines(filepath);
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    var order = new Order
                    (
                        id: data[0],
                        type: data[1],
                        description: data[2],
                        size: data[3],
                        cost: double.Parse(data[4]),
                        name: data[5],
                        email: data[6]
                    );
                    Orders.Add(order);
                }

                FilteredOrders = Orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FilterOrders(ChangeEventArgs e)
        {
            if (e != null)
            {
                Name = e.Value.ToString();
                if (!string.IsNullOrWhiteSpace(Name))
                {
                    FilteredOrders = Orders.Where(o => o.Name.Contains(Name)).ToList();
                }
                else
                {
                    FilteredOrders = Orders;
                }
            }
        }
    }
}