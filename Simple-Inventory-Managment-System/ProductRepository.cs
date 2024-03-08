namespace Simple_Inventory_Managment_System;

public class ProductRepository
{
    public List<Product> Products = new List<Product>();
    private readonly string ConnectionString;

    public ProductRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void ViewAllProducts()
    {
        foreach (Product product in Products)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
        }
    }

    public void EditProduct(string name)
    {
        Product productToUpdate = Products.Find(product => product.Name == name);
            if (productToUpdate != null)
            {
                Console.WriteLine("What field do you wish to change?");
                Console.WriteLine("1- Name\n2- Price\n3- Quantity \n");
                Console.Write("Enter an option (1-3): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int option))
                {
                  
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Write the new name for the product: ");
                            string newName = Console.ReadLine();
                            productToUpdate.Name = newName;                           
                            break;
                        case 2:
                            Console.WriteLine("Write the new price for the product: ");
                            string newPrice = Console.ReadLine();
                            productToUpdate.Price = decimal.Parse(newPrice, System.Globalization.CultureInfo.InvariantCulture);                          
                            break;
                        case 3:
                            Console.WriteLine("Write the new quantity for the product: ");
                            string newQuantity = Console.ReadLine();
                            productToUpdate.Quantity = int.Parse(newQuantity, System.Globalization.CultureInfo.InvariantCulture);                            
                            break;
                        default:
                            Console.WriteLine("Invalid choice option");
                            return;
                    }
                    Console.WriteLine($"Product updated to --> Name: {productToUpdate.Name}, Price: {productToUpdate.Price}, Quantity: {productToUpdate.Quantity}");
                }
                else Console.WriteLine("Invalid choice option");


                
            }
            else Console.WriteLine("Product not found");
    }

    public void DeleteProduct(string productName)
    {
        Product productToDelete = Products.Find(product => product.Name == productName);
        if (productToDelete != null)
        {
            Products.Remove(productToDelete);
            Console.WriteLine("Product deleted");
        }
        else Console.WriteLine("Product not found");
    }

    public void SearchProduct(string productName)
    {
        Product product = Products.Find(product => product.Name == productName);
        if (product != null)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
        }
        else Console.WriteLine("Product not found");
    }
}