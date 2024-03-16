// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Simple_Inventory_Managment_System;
using Simple_Inventory_Managment_System.Repository_Pattern;
using Simple_Inventory_Managment_System.Simple_Factory;



namespace Simple_Inventory_Management_System
{
    public class Program
    {
        static void Main()
        {

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            IProductRepository productRepository = ProductRepositoryFactory.CreateProductRepository(configuration);

            ProductPrintingService productPrintingService = new ProductPrintingService();

            Inventory inventory = new Inventory(productRepository, productPrintingService);



            bool menu = true;

            while (menu)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add a Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Edit a product");
                Console.WriteLine("4. Delete a product");
                Console.WriteLine("5. Search a product");
                Console.WriteLine("0. Exit");
                Console.Write("Enter an option (1-5): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            AddProduct(inventory);
                            break;
                        case 2:
                            Console.WriteLine("\n");
                            ViewAllProducts(inventory);
                            break;
                        case 3:
                            EditProduct(inventory);
                            break;
                        case 4:
                            DeleteProduct(inventory);
                            break;
                        case 5:
                            SearchProduct(inventory);
                            break;
                        case 0:
                            menu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice option");
                            break;
                    }
                }
                else Console.WriteLine("Invalid choice option");


            }
            Console.WriteLine("Exiting Program...");
        }

        private static void SearchProduct(Inventory inventory)
        {
            string productName = GetProductNameFromUser();
            inventory.SearchProduct(productName);
        }

        private static void DeleteProduct(Inventory inventory)
        {
            Console.Write("Enter product name: ");
            string productName = GetProductNameFromUser();
            inventory.DeleteProduct(productName);
        }

        private static void EditProduct(Inventory inventory)
        {
            string productName = GetProductNameFromUser();
            inventory.EditProduct(productName);
        }
        private static string GetProductNameFromUser()
        {
            Console.Write("Enter product name: ");
            return Console.ReadLine();
        }

        private static void ViewAllProducts(Inventory inventory)
        {

            inventory.ViewAllProducts();
        }

        private static void AddProduct(Inventory inventory)
        {

            Product newProduct = GetProductFromUserInput();
            inventory.AddProduct(newProduct);
        }

        private static Product GetProductFromUserInput()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal productPrice;
            while (!decimal.TryParse(Console.ReadLine(), out productPrice))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal value for the price.");
            }

            Console.Write("Enter product quantity: ");
            int productQuantity;
            while (!int.TryParse(Console.ReadLine(), out productQuantity))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer value for the quantity.");
            }

            return new Product(productName, productPrice, productQuantity);
        }
    }
}

