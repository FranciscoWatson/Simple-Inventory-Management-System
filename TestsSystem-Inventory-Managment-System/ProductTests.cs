using Simple_Inventory_Managment_System;

namespace TestsSystem_Inventory_Managment_System
{
    public class ProductTests
    {
        [Fact]
        public void ProductConstructorTest()
        {
            string expectedName = "Iphone 15";
            decimal expectedPrice = 10.14m;
            int expectedQuantity = 2;


            Product product = new Product(expectedName, expectedPrice, expectedQuantity);


            Assert.Equal(expectedName, product.Name);
            Assert.Equal(expectedPrice, product.Price);
            Assert.Equal(expectedQuantity, product.Quantity);
        }
    }
}
