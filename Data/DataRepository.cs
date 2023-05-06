using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

using Data.abstraction.interfaces;

namespace Data
{
    public class DataRepository : DataApi
    {
        public List<ICustomer> Customers;
        public List<IEvent> Events;
        public List<IProduct> Catalog;
        public List<IState> States;

        public DataRepository() { 
            Customers = new List<ICustomer>();
            Events = new List<IEvent>();
            Catalog = new List<IProduct>();
            States = new List<IState>();
        }   

        public void addCustomer(int cid, string fn, string ln)
        {
           Customers.Add(new Customer(cid, fn, ln));
        }

        public void addEvent(int eid, int cid, int pid, string mode)
        {
            if (mode == "b")
            {
                Events.Add(new BuyEvent(eid, cid, pid));
            }
            if (mode == "r")
            {
                Events.Add(new ReturnEvent(eid, cid, pid));
            }
        }

        public void addProduct(int pid, string n, double p)
        {
            Catalog.Add(new  Product(pid, n, p));
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
            return Customers.Find(item => item.CustomerId==id).Last_Name;
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
            Catalog[id] = new Product(id ,m, p);
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
