
using Simple_Inventory_Managment_System;

namespace TestsSystem_Inventory_Managment_System
{
    public class InventoryTests
    {
        [Fact]
        public void AddProductShouldAddProductsToList()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("Iphone 15", 1000, 2);

            inventory.AddProduct(product);

            Assert.Equal(1, inventory.products.Count);
            Assert.Equal("Iphone 15", inventory.products[0].name);

        }
        [Fact]
        public void AddMultipleProductShouldMakeTheProductsListBigger()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("Iphone 15", 1000, 2);
            Product product2 = new Product("Iphone 16", 500, 7);

            inventory.AddProduct(product);
            inventory.AddProduct(product2);

            Assert.Equal(2, inventory.products.Count);
        }

    }
}