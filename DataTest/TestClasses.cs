using Data.abstraction.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTestClasses
{
    internal class Customer
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

    public class Product
    {
        public int ProductId { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double State { get; set; }

        public Product(int pid, string n, double p, double s)
        {
            ProductId = pid;
            Name = n;
            Price = p;
            State = s;
        }

    }

    internal class Event 
    {
        public int EventId { get; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public DateTime EventOccurenceTime { get; }

        public Event(int eid, int cid, int pid)
        {
            EventId = eid;
            CustomerId = cid;
            ProductId = pid;
            EventOccurenceTime = DateTime.Now;
        }
    }
}
