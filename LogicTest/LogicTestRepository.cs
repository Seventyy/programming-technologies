using Data.abstraction.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTest
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

        public Product(int pid, string n, double p)
        {
            ProductId = pid;
            Name = n;
            Price = p;
        }
    }
    internal class State : IState
    {
        public State(int id, int pid, double pq)
        {
            this.StateId = id;
            this.ProductId = pid;
            this.ProductQuantity = pq;
        }

        public int StateId { get; }

        public int ProductId { get; }

        public double ProductQuantity { get; set; }
    }

    internal class DataRepository : DataApi
    {
        public List<Customer> Customers;
        public List<Event> Events;
        public List<Product> Catalog;
        public List<State> States;

        public DataRepository()
        {
            Customers = new List<Customer>();
            Events = new List<Event>();
            Catalog = new List<Product>();
            States = new List<State>();
        }

        public void addCustomer(int cid, string fn, string ln)
        {
            Customers.Add(new Customer(cid, fn, ln));
        }

        public void addEvent(int eid, int cid, int pid, string mode)
        {
            Events.Add(new Event(eid, cid, pid));
        }

        public void addProduct(int pid, string n, double p)
        {
            Catalog.Add(new Product(pid, n, p));
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

        public DateTime getEventDate(int id)
        {
            return Events[id].EventOccurenceTime;
        }

        public void addState(int id, int pid, double q)
        {
            States.Add(new State(id, pid, q));
        }

        public void deleteState(int id)
        {
            States.RemoveAt(id);
        }

        public int getStateId(int id)
        {
            return States[id].StateId;
        }

        public int getStateProductId(int id)
        {
            return States[id].ProductId;
        }

        public double getStateQuantity(int id)
        {
            return States[id].ProductQuantity;
        }

        public void updateProduct(int id, string m, double p)
        {
            Catalog[id] = new Product(id, m, p);
        }

        public void updateCustomer(int id, int cid, string first_name, string last_name)
        {
            Customers[id] = new Customer(cid, first_name, last_name);
        }

        public void updateState(int id, double quantity)
        {
            States[id].ProductQuantity = quantity;
        }

    }
}
