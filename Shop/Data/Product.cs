using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.abstraction.interfaces;

namespace Data
{
    internal class Product : IProduct
    {
        public int ProductId { get; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int pid, string n, double p) {  
            ProductId = pid;
            Name = n;
            Price = p;  
        }


    }
}
