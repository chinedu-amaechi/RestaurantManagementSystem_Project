using System;
using MySqlConnector;
using RestaurantManagementSystem.Models;
using System.Collections.Generic;

namespace RestaurantManagementSystem.Services
{
    public class RestaurantDbAccessor
    {
        private readonly string _connectionString;

        public RestaurantDbAccessor()
        {
            // Get environment variables for database connection
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            

            // Create MySqlConnectionStringBuilder instance and set connection parameters
            var builder = new MySqlConnectionStringBuilder
            {
                Server = dbHost,
                UserID = dbUser,
                Password = dbPassword,
                Database = "lukachi_restaurant" // Database already exist in Marian Db on the localhost
            };

            _connectionString = builder.ConnectionString;
        }
        
        // Methods for Menu table
        public List<Menus> GetMenuItems()
        {
            List<Menus> menuItems = new List<Menus>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Menus";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var menu = new Menus
                            {
                                Id = reader.GetString("Id"),
                                Type = reader.GetString("Type"),
                                Description = reader.GetString("Description"),
                                Size = reader.GetString("Size"),
                                Cost = reader.GetDouble("Cost")
                            };
                            menuItems.Add(menu);
                        }
                    }
                }
            }

            return menuItems;
        }

        public void AddMenuItem(Menus menuItem)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Menus (Type, Description, Size, Cost) VALUES (@Type, @Description, @Size, @Cost)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", menuItem.Id);
                    command.Parameters.AddWithValue("@Type", menuItem.Type);
                    command.Parameters.AddWithValue("@Description", menuItem.Description);
                    command.Parameters.AddWithValue("@Size", menuItem.Size);
                    command.Parameters.AddWithValue("@Cost", menuItem.Cost);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMenuItem(Menus menuItem)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "UPDATE Menus SET Type = @Type, Description = @Description, Size = @Size, Cost = @Cost WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", menuItem.Id);
                    command.Parameters.AddWithValue("@Type", menuItem.Type);
                    command.Parameters.AddWithValue("@Description", menuItem.Description);
                    command.Parameters.AddWithValue("@Size", menuItem.Size);
                    command.Parameters.AddWithValue("@Cost", menuItem.Cost);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMenuItem(string menuItemId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "DELETE FROM Menus WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@Id", menuItemId);
                    // will come back to this

                    command.ExecuteNonQuery();
                }
            }
        }

        // Methods for Orders table
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Orders";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                Id = reader.GetString("Id"),
                                // will come back to this
                            };
                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }

        public void AddOrder(Order order)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Orders (MenuItemId, MenuItemType, MenuItemDescription, MenuItemSize, MenuItemCost, CustomerName, CustomerEmail) " +
                            "VALUES (@MenuItemId, @MenuItemType, @MenuItemDescription, @MenuItemSize, @MenuItemCost, @CustomerName, @CustomerEmail)";
                using (var command = new MySqlCommand(query, connection))
                {
                    // Add parameters and set their values
                    command.Parameters.AddWithValue("@MenuItemId", order.MenuItemId);
                    command.Parameters.AddWithValue("@MenuItemType", order.MenuItemType);
                    command.Parameters.AddWithValue("@MenuItemDescription", order.MenuItemDescription);
                    command.Parameters.AddWithValue("@MenuItemSize", order.MenuItemSize);
                    command.Parameters.AddWithValue("@MenuItemCost", order.MenuItemCost);
                    command.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    command.Parameters.AddWithValue("@CustomerEmail", order.CustomerEmail);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "UPDATE Orders SET /* Update columns */ WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    // Set parameters and execute command
                    // command.Parameters.AddWithValue("@ParameterName", value);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(string orderId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "DELETE FROM Orders WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@Id", orderId);
                    // will come back to this

                    command.ExecuteNonQuery();
                }
            }
        }

        // Methods for Customers table
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Customers";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customer = new Customer
                            {
                                Id = reader.GetString("Id"),
                                // will come back to this
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Customers (/* Insert column names */) VALUES (/* Insert parameter placeholders */)";
                using (var command = new MySqlCommand(query, connection))
                {
                    // Add parameters and set their values
                    // command.Parameters.AddWithValue("@ParameterName", value);
                    // will come back to this

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "UPDATE Customers SET /* Update columns */ WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    // Set parameters and execute command
                    // command.Parameters.AddWithValue("@ParameterName", value);
                    // will come back to this

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(string customerId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "DELETE FROM Customers WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    // command.Parameters.AddWithValue("@Id", customerId);
                    // will come back to this

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}