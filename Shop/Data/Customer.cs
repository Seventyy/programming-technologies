using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.abstraction.interfaces;

namespace Data
{
    internal class Customer : ICustomer
    {
        public int CustomerId { get; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Customer(int cid, string fn, string ln)
        {
            CustomerId = cid;
            First_Name = fn;
            Last_Name = ln;
        }

    
    }
}
