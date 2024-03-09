using Microsoft.Data.SqlClient;
using Simple_Inventory_Managment_System.Repository_Pattern;
using System.Data;
using System.Data.Common;

namespace Simple_Inventory_Managment_System;

public class ProductRepository : IProductRepository
{
    private readonly SqlConnection _connection;

    public ProductRepository(SqlConnection connection)
    {
        _connection = connection;
    }
    public void AddProduct(Product product)
    {

        _connection.Open();

        string query = $"INSERT INTO Products VALUES(@Name, @Price, @Quantity)";

        using (SqlCommand command = new SqlCommand(query, _connection))
        {
            command.Parameters.AddWithValue("Name", product.Name);
            command.Parameters.AddWithValue("Price", product.Price);
            command.Parameters.AddWithValue("Quantity", product.Quantity);

            command.ExecuteNonQuery();
        }
        _connection.Close();


    }

    public List<Product> ViewAllProducts()
    {
        List<Product> products = new List<Product>();

        _connection.Open();

        string query = "SELECT * FROM Products";

        using (SqlCommand command = new SqlCommand(query, _connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    int productId = (int)reader["ProductID"];
                    string name = reader["Name"] != DBNull.Value ? (string)reader["Name"] : null;
                    decimal price = (decimal)reader["Price"];
                    int quantity = (int)reader["Quantity"];

                    Product product = new Product(productId, name, price, quantity);
                    products.Add(product);
                }
            }
        }
        _connection.Close();


        return products;
    }



    public void EditProduct(string productName)
    {
        Product productToUpdate = SearchProduct(productName);

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


                _connection.Open();

                string query = $"UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE ProductID = @ProductId";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("Name", productToUpdate.Name);
                    command.Parameters.AddWithValue("Price", productToUpdate.Price);
                    command.Parameters.AddWithValue("Quantity", productToUpdate.Quantity);
                    command.Parameters.AddWithValue("ProductId", productToUpdate.ProductId);

                    command.ExecuteNonQuery();
                }
                _connection.Close();


                Console.WriteLine($"Product updated to --> Name: {productToUpdate.Name}, Price: {productToUpdate.Price}, Quantity: {productToUpdate.Quantity}");
            }
            else Console.WriteLine("Invalid choice option");



        }
        else Console.WriteLine("Product not found");
    }

    public void DeleteProduct(string productName)
    {

        _connection.Open();

        string query = "DELETE FROM Products WHERE Name = @ProductName";

        using (SqlCommand command = new SqlCommand(query, _connection))
        {
            command.CommandText = query;

            command.Parameters.AddWithValue("ProductName", productName);

            command.ExecuteNonQuery();
        }
        _connection.Close();


    }

    public Product SearchProduct(string productName)
    {
        Product product = null;

        _connection.Open();

        string query = $"SELECT * FROM Products WHERE Products.Name = @productName";

        using (SqlCommand command = new SqlCommand(query, _connection))
        {
            command.Parameters.AddWithValue("@productName", productName);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    int productId = (int)reader["ProductID"];
                    string name = reader["Name"] != DBNull.Value ? (string)reader["Name"] : null;
                    decimal price = (decimal)reader["Price"];
                    int quantity = (int)reader["Quantity"];

                    product = new Product(productId, name, price, quantity);
                }
            }
        }
        _connection.Close();

        return product;
    }
}