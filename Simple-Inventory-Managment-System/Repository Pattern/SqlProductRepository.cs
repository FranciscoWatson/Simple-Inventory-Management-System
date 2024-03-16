using Microsoft.Data.SqlClient;
using Simple_Inventory_Managment_System.Models;
using Simple_Inventory_Managment_System.Repository_Pattern;


namespace Simple_Inventory_Managment_System;

public class SqlProductRepository : IProductRepository
{
    private readonly SqlConnection _connection;

    public SqlProductRepository(SqlConnection connection)
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

                    string productId = reader["ProductID"].ToString();
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



    public void EditProduct(string productName, Product updatedProduct)
    {
        _connection.Open();

        string query = $"UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE ProductID = @ProductId";

        using (SqlCommand command = new SqlCommand(query, _connection))
        {
            command.Parameters.AddWithValue("Name", updatedProduct.Name);
            command.Parameters.AddWithValue("Price", updatedProduct.Price);
            command.Parameters.AddWithValue("Quantity", updatedProduct.Quantity);
            command.Parameters.AddWithValue("ProductId", updatedProduct.ProductId);

            command.ExecuteNonQuery();
        }
        _connection.Close();

        Console.WriteLine($"Product updated to --> Name: {updatedProduct.Name}, Price: {updatedProduct.Price}, Quantity: {updatedProduct.Quantity}");
            
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

                    string productId = reader["ProductID"].ToString();
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