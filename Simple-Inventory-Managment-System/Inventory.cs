using MongoDB.Driver;
using Simple_Inventory_Managment_System.Repository_Pattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace Simple_Inventory_Managment_System
{
    public class Inventory
    {
        private readonly IProductRepository _productRepository;
        public ProductPrintingService ProductPrintingService { get; set; }


        public Inventory(IProductRepository productRepository, ProductPrintingService productPrintingService)
        {
            _productRepository = productRepository;
            ProductPrintingService = productPrintingService;

        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        public void ViewAllProducts()
        {
            var products = _productRepository.ViewAllProducts();
            ProductPrintingService.PrintProducts(products);
        }
        public void EditProduct(string name)
        {
            Product productToUpdate = _productRepository.SearchProduct(name);
            EditProductFields(productToUpdate);
            _productRepository.EditProduct(name, productToUpdate);
        }

        private void EditProductFields(Product productToUpdate)
        {
            if (productToUpdate != null)
            {
                Console.WriteLine("What field do you wish to change?");
                Console.WriteLine("1- Name\n2- Price\n3- Quantity \n");
                Console.Write("Enter an option (1-3): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int option))
                {

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Write the new name for the product: ");
                            string newName = Console.ReadLine();
                            productToUpdate.Name = newName;
                            break;
                        case 2:
                            Console.WriteLine("Write the new price for the product: ");
                            string newPrice = Console.ReadLine();
                            productToUpdate.Price = decimal.Parse(newPrice, System.Globalization.CultureInfo.InvariantCulture);
                            break;
                        case 3:
                            Console.WriteLine("Write the new quantity for the product: ");
                            string newQuantity = Console.ReadLine();
                            productToUpdate.Quantity = int.Parse(newQuantity, System.Globalization.CultureInfo.InvariantCulture);
                            break;
                        default:
                            Console.WriteLine("Invalid choice option");
                            return;
                    }
                }
            }
        }

        public void DeleteProduct(string productName)
        {
            _productRepository.DeleteProduct(productName);
        }

        public void SearchProduct(string productName)
        {
            var product = _productRepository.SearchProduct(productName);
            ProductPrintingService.PrintProduct(product);
        }
    }
}
