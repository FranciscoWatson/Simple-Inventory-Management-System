using Simple_Inventory_Managment_System.Models;

namespace Simple_Inventory_Managment_System.Services
{
    public class ProductPrintingService
    {
        public void PrintProduct(Product product)
        {
            Console.WriteLine($"ProductId: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");

        }

        public void PrintProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                PrintProduct(product);
            }
        }
    }

}
