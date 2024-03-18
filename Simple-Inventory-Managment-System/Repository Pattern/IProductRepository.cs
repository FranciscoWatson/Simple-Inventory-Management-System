using Simple_Inventory_Managment_System.Models;

namespace Simple_Inventory_Managment_System.Repository_Pattern
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(string productName);
        void EditProduct(string productName, Product updatedProduct);
        Product SearchProduct(string productName);
        List<Product> ViewAllProducts();
    }
}
