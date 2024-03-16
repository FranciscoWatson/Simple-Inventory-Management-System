using Microsoft.Data.SqlClient;
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

        private readonly IMongoDatabase _connection;

        public MongoDBProductRepository(IMongoDatabase connection)
        {
            _connection = connection;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public Product SearchProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public List<Product> ViewAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
