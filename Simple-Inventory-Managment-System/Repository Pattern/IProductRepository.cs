using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Managment_System.Repository_Pattern
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(string productName);
        void EditProduct(string productName);
        Product SearchProduct(string productName);
        List<Product> ViewAllProducts();
    }
}
