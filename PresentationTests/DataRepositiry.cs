using Data.abstraction.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace PresentationTests
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

    internal class Event : IEvent
    {
        public int EventId { get; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime EventOccurenceTime { get; }
        public string EventType { get; set; }

        public Event(int eid, int cid, int pid)
        {
            EventId = eid;
            CustomerId = cid;
            ProductId = pid;
            EventOccurenceTime = DateTime.Now;
        }
    }

    internal class Product : IProduct
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

    internal class DataRepository : IDataApi
    {
        public List<Customer> Customers;
        public List<Event> Events;
        public List<Product> Catalog;

        public DataRepository()
        {
            Customers = new List<Customer>();
            Events = new List<Event>();
            Catalog = new List<Product>();
        }

        public void addCustomer(int cid, string fn, string ln)
        {
            Customers.Add(new Customer(cid, fn, ln));
        }

        public void addEvent(int eid, int cid, int pid, string mode)
        {
            Events.Add(new Event(eid, cid, pid));
        }

        public void addProduct(int pid, string n, double p, double s)
        {
            Catalog.Add(new Product(pid, n, p, s));
        }

        public void deleteCustomer(int id)
        {
            Customers.RemoveAt(id);
        }

        public void deleteProduct(int id)
        {
            Catalog.RemoveAt(id);
        }

        public void deleteEvent(int id)
        {
            Events.RemoveAt(id);
        }

        public string getCustomerFirstName(int id)
        {
            return Customers.Find(item => item.CustomerId == id).First_Name;
        }

        public int getCustomerID(int id)
        {
            return Customers[id].CustomerId;
        }

        public string getCustomerLastName(int id)
        {
            return Customers.Find(item => item.CustomerId == id).Last_Name;
        }

        public int getProductID(int id)
        {
            return Catalog[id].ProductId;
        }

        public string getProductName(int id)
        {
            return Catalog[id].Name;
        }

        public double getProductPrice(int id)
        {
            return Catalog[id].Price;
        }


        public int getEventCustomerId(int id)
        {
            return Events[id].CustomerId;
        }

        public int getEventProductId(int id)
        {
            return Events[id].ProductId;
        }

        public int getEventId(int id)
        {
            return Events[id].EventId;
        }

        public void updateProduct(int id, string m, double p, double s)
        {
            Catalog[id] = new Product(id, m, p, s);
        }

        public void updateCustomer(int id, int cid, string first_name, string last_name)
        {
            Customers[id] = new Customer(cid, first_name, last_name);
        }

        public double getProductState(int id)
        {
            return Catalog[id].State;
        }

        DateTime? IDataApi.getEventDate(int id)
        {
            return Events[id].EventOccurenceTime;
        }

        public List<ICustomer> getCustomers()
        {
            throw new NotImplementedException();
        }

        public List<IProduct> getProducts()
        {
            throw new NotImplementedException();
        }

        public List<IEvent> getEvents()
        {
            throw new NotImplementedException();
        }
    }
}
