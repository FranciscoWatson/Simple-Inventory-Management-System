﻿using Microsoft.Data.SqlClient;
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
