using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Managment_System
{
    public class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        { 
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

    }
}
