using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Simple_Inventory_Managment_System.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product(string productName, decimal price, int quantityInStock)
        {
            Name = productName;
            Price = price;
            Quantity = quantityInStock;
        }
        public Product(string productId, string name, decimal price, int quantity)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Quantity = quantity;

        }

    }
}
