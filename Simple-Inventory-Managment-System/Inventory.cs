using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Managment_System
{
    public class Inventory
    {
        public List<Product> products { get; set; }

        public Inventory() 
        {
            products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
