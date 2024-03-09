
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

            Assert.Equal(1, inventory.Products.Count);
            Assert.Equal("Iphone 15", inventory.Products[0].Name);
            Assert.Equal(10.14m, inventory.Products[0].Price);
            Assert.Equal(2, inventory.Products[0].Quantity);
        }

        [Fact]
        public void AddMultipleProductShouldMakeTheProductsListBiggerTest()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("Iphone 15", 1000, 2);
            Product product2 = new Product("Iphone 16", 500, 7);

            inventory.AddProduct(product);
            inventory.AddProduct(product2);

            Assert.Equal(2, inventory.Products.Count);
        }

        [Fact]
        public void ViewAllProductsTest()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("Iphone 15", 1000, 2);
            Product product2 = new Product("Iphone 16", 500, 7);
            inventory.AddProduct(product);
            inventory.AddProduct(product2);



            
            string expectedOutput = $"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}\r\n" +
                                    $"Name: {product2.Name}, Price: {product2.Price}, Quantity: {product2.Quantity}\r\n";
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


            Assert.Equal(0, inventory.Products.Count);
        }

    }
}