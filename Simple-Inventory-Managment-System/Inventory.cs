using Simple_Inventory_Managment_System.Repository_Pattern;
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
        private readonly IProductRepository _productRepository;
        public ProductPrintingService ProductPrintingService { get; set; }


        public Inventory(IProductRepository productRepository, ProductPrintingService productPrintingService)
        {
            _productRepository = productRepository;
            ProductPrintingService = productPrintingService;

        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        public void ViewAllProducts()
        {
            var products = _productRepository.ViewAllProducts();
            ProductPrintingService.PrintProducts(products);
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
            var product = _productRepository.SearchProduct(productName);
            ProductPrintingService.PrintProduct(product);
        }
    }
}
