// See https://aka.ms/new-console-template for more information

using Simple_Inventory_Managment_System;



namespace Simple_Inventory_Management_System
{
    public class Program
    {
        static void Main()
        {
            Inventory inventory = new Inventory();

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
                            inventory.ViewAllProducts();
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
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            inventory.SearchProduct(productName);
        }

        private static void DeleteProduct(Inventory inventory)
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            inventory.DeleteProduct(productName);
        }

        private static void EditProduct(Inventory inventory)
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            inventory.EditProduct(productName);
        }

        private static void AddProduct(Inventory inventory) 
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product price: ");
            double productPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter product quantity: ");
            int productQuantity = Convert.ToInt32(Console.ReadLine());
            Product newProduct = new Product(productName, productPrice, productQuantity);
            inventory.AddProduct(newProduct);
        }
    }
}

