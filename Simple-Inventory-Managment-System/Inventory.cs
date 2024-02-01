using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simple_Inventory_Managment_System
{
    public class Inventory
    {
        public List<Product> products { get; set; }

        public Inventory() 
        {
            products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void ViewAllProducts()
        {
            Console.WriteLine("\n");
            foreach (Product product in products)
            {
                Console.WriteLine($"Name: {product.name}, Price: {product.price}, Quantity: {product.quantity}");
            }
        }
        public void EditProduct(string name)
        {
            Product productToUpdate = products.Find(product => product.name == name);
            if (productToUpdate != null)
            {
                Console.WriteLine("What field do you wish to change?");
                Console.WriteLine("1- Name\n2- Price\n3- Quantity \n");
                Console.Write("Enter an option (1-3): ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Write the new name for the product: ");
                        string newName = Console.ReadLine();
                        productToUpdate.name = newName;
                        break;
                    case "2":
                        Console.WriteLine("Write the new price for the product: ");
                        string newPrice = Console.ReadLine();
                        productToUpdate.price = double.Parse(newPrice, System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    case "3":
                        Console.WriteLine("Write the new quantity for the product: ");
                        string newQuantity = Console.ReadLine();
                        productToUpdate.quantity = int.Parse(newQuantity, System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    default:
                        Console.WriteLine("Invalid choice option");
                        break;
                }
                Console.WriteLine($"Product updated to --> Name: {productToUpdate.name}, Price: {productToUpdate.price}, Quantity: {productToUpdate.quantity}");
            }
            else Console.WriteLine("Product not found");
            
        }

        public void DeleteProduct(string productName)
        {
            Product productToDelete = products.Find(product => product.name == productName);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                Console.WriteLine("Product deleted");
            }
            else Console.WriteLine("Product not found");
        }

        public void SearchProduct(string productName)
        {
            Product product = products.Find(product => product.name == productName);
            if (product != null)
            {
                Console.WriteLine($"Name: {product.name}, Price: {product.price}, Quantity: {product.quantity}");
            }
            else Console.WriteLine("Product not found");
        }
    }
}
