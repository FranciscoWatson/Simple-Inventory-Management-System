using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simple_Inventory_Managment_System
{
    public class Inventory
    {
        private readonly ProductRepository _productRepository;

        public Inventory(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        public void ViewAllProducts()
        {
            _productRepository.ViewAllProducts();
            
        }
        public void EditProduct(string name)
        {
            _productRepository.EditProduct(name);
        }

        public void DeleteProduct(string productName)
        {
            _productRepository.DeleteProduct(productName);
        }

        public void SearchProduct(string productName)
        {
            _productRepository.SearchProduct(productName);
        }
    }
}
