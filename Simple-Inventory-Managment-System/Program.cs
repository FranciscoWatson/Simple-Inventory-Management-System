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
                Console.WriteLine("1. Add a product");
                Console.WriteLine("0. Exit");
                Console.Write("Enter an option (1-1): ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddProduct(inventory);
                        break;
                    case "0":
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice option");
                        break;
                }
            }

            Console.WriteLine("Exiting Program...");
        }

        static void AddProduct(Inventory inventory) 
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

