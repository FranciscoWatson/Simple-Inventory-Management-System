
using Simple_Inventory_Managment_System;

namespace TestsSystem_Inventory_Managment_System
{
    public class InventoryTests
    {
        [Fact]
        public void AddProductShouldAddProductsToListTest()
        {
            Inventory inventory = new Inventory();
           
            Product product = new Product("Iphone 15", 10.14m, 2);
  

            inventory.AddProduct(product);

            Assert.Equal(1, inventory.products.Count);
            Assert.Equal("Iphone 15", inventory.products[0].name);
            Assert.Equal(10.14m, inventory.products[0].price);
            Assert.Equal(2, inventory.products[0].quantity);
        }

        [Fact]
        public void AddMultipleProductShouldMakeTheProductsListBiggerTest()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("Iphone 15", 1000, 2);
            Product product2 = new Product("Iphone 16", 500, 7);

            inventory.AddProduct(product);
            inventory.AddProduct(product2);

            Assert.Equal(2, inventory.products.Count);
        }

        [Fact]
        public void ViewAllProductsTest()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("Iphone 15", 1000, 2);
            Product product2 = new Product("Iphone 16", 500, 7);
            inventory.AddProduct(product);
            inventory.AddProduct(product2);



            
            string expectedOutput = $"Name: {product.name}, Price: {product.price}, Quantity: {product.quantity}\r\n" +
                                    $"Name: {product2.name}, Price: {product2.price}, Quantity: {product2.quantity}\r\n";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            inventory.ViewAllProducts();
            string actualOutput = sw.ToString();

            Assert.Equal(expectedOutput, actualOutput);
            
        }

        [Fact]
        public void DeleteProductTest()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("Iphone 15", 1000, 2);
            inventory.AddProduct(product);

    
            inventory.DeleteProduct("Iphone 15");


            Assert.Equal(0, inventory.products.Count);
        }

    }
}