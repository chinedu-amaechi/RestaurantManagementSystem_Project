using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Services;


namespace RestaurantManagementSystem.Components.Pages
{
    public partial class MenuComponent : ComponentBase
    {
        // Properties for search criteria
        string selectedType;
        string selectedDescription;
        string selectedSize;

        // List to store menu items
        List<Menus> menuItems = new List<Menus>();

        // List to store unique types and sizes for dropdowns
        List<string> types = new List<string>();
        List<string> sizes = new List<string>();

        // Property to store filtered menu items
        List<Menus> filteredMenuItems => FilterMenuItems();

        // Property to store selected menu item for order
        Menus selectedMenuItem;

        // Properties for order creation
        string customerName;
        string customerEmail;

        // List to store orders
        List<string> orders = new List<string>();

        protected override void OnInitialized()
        {
            string resDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot/data");

            // Specify the filename you want to read
            string filename = "MenuList.txt";

            // Combine the directory and file name to get the full path
            string filepath = Path.Combine(resDirectory, filename);

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filepath);

                // Populate menuItems list and types/sizes lists
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    var menu = new Menus(data[0], data[1], data[2], data[3], double.Parse(data[4]));
                    menuItems.Add(menu);

                    if (!types.Contains(menu.Type))
                        types.Add(menu.Type);
                    if (!sizes.Contains(menu.Size))
                        sizes.Add(menu.Size);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            base.OnInitialized();
        }

        // Method to filter menu items based on search criteria
        List<Menus> FilterMenuItems()
        {
            var filteredItems = menuItems;

            if (!string.IsNullOrEmpty(selectedType))
                filteredItems = filteredItems.Where(item => item.Type == selectedType).ToList();
            if (!string.IsNullOrEmpty(selectedDescription))
                filteredItems = filteredItems.Where(item => item.Description.Contains(selectedDescription)).ToList();
            if (!string.IsNullOrEmpty(selectedSize))
                filteredItems = filteredItems.Where(item => item.Size == selectedSize).ToList();

            return filteredItems;
        }

        // Event handler for search button click
        void SearchMenu()
        {
            // Refresh UI
            StateHasChanged();
        }

        // Method to select a menu item for ordering
        void SelectMenuItem(Menus menuItem)
        {
            selectedMenuItem = menuItem;
        }

        // Event handler for Place Order button click
        void PlaceOrder()
        {
            if (selectedMenuItem != null && !string.IsNullOrEmpty(customerName) && !string.IsNullOrEmpty(customerEmail))
            {
                // Create a new order object
                var order = new Order
                {
                    MenuItemId = selectedMenuItem.Id,
                    MenuItemType = selectedMenuItem.Type,
                    MenuItemDescription = selectedMenuItem.Description,
                    MenuItemSize = selectedMenuItem.Size,
                    MenuItemCost = selectedMenuItem.Cost,
                    CustomerName = customerName,
                    CustomerEmail = customerEmail
                };

                // Add order to the database
                try
                {
                    var dbAccessor = new RestaurantDbAccessor(); // Initialize RestaurantDbAccessor
                    dbAccessor.AddOrder(order);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error placing order: {ex.Message}");
                    // Handle error as needed
                    return;
                }

                // Clear input fields
                customerName = "";
                customerEmail = "";

                // Refresh UI
                StateHasChanged();
            }
        }
    }
}