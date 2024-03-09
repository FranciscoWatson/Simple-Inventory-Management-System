using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Managment_System
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
