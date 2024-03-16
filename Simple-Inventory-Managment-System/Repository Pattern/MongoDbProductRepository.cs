using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Managment_System.Repository_Pattern
{
    public class MongoDBProductRepository : IProductRepository
    {

        private readonly IMongoCollection<Product> ProductsCollection;
        public MongoDBProductRepository(IMongoDatabase connection)
        {
            ProductsCollection = connection.GetCollection<Product>("Products");
        }

        public void AddProduct(Product product)
        {
            ProductsCollection.InsertOne(product);
        }

        public void DeleteProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(string productName)
        {

            Product productToUpdate = SearchProduct(productName);

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
                    ProductsCollection.UpdateOne(
                        Builders<Product>.Filter.Eq(p => p.Name, productName),
                        Builders<Product>.Update
                            .Set(p => p.Name, productToUpdate.Name)
                            .Set(p => p.Price, productToUpdate.Price)
                            .Set(p => p.Quantity, productToUpdate.Quantity)
                    );
                }


            }
        }

        public Product SearchProduct(string productName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);
            var product = ProductsCollection.Find(filter).FirstOrDefault();
            return product;

        }

        public List<Product> ViewAllProducts()
        {
            var filter = Builders<Product>.Filter.Empty;
            return ProductsCollection.Find(filter).ToList();
        }
    }
}
