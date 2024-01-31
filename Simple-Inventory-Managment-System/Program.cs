// See https://aka.ms/new-console-template for more information

using Simple_Inventory_Managment_System;

Inventory inventory = new Inventory();

Console.Write("Enter product name: ");
string productName = Console.ReadLine();
Console.Write("Enter product price: ");
double productPrice = Convert.ToDouble(Console.ReadLine());
Console.Write("Enter product quantity: ");
int productQuantity = Convert.ToInt32(Console.ReadLine());

Product newProduct = new Product(productName, productPrice, productQuantity);

inventory.AddProduct(newProduct);
