using MongoDB.Driver;
using Simple_Inventory_Managment_System.Models;


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
            var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);
            ProductsCollection.DeleteOne(filter);
        }

        public void EditProduct(string productName, Product updatedProduct)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);
            ProductsCollection.UpdateOne(
                filter,               
                Builders<Product>.Update
                    .Set(p => p.Name, updatedProduct.Name)
                    .Set(p => p.Price, updatedProduct.Price)
                    .Set(p => p.Quantity, updatedProduct.Quantity));
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
