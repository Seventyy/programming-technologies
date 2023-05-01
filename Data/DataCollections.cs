using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.abstraction.interfaces;

namespace Data
{
    public class DataCollections : DataApi
    {
        public List<ICustomer> Customers;
        public List<IEvent> Events;
        public List<IProduct> Catalog;

        public DataCollections() { 
            Customers = new List<ICustomer>();
            Events = new List<IEvent>();
            Catalog = new List<IProduct>();
        }   

        public void addCustomer(int cid, string fn, string ln)
        {
           Customers.Add(new Customer(cid, fn, ln));
        }

        public void addProduct(int pid, string n, double q, int p)
        {
            Catalog.Add(new  Product(pid, n, q, p));
        }

        public void deleteCustomer(int id)
        {
            Customers.RemoveAt(id);
        }

        public void deleteProduct(int id)
        {
            Catalog.RemoveAt(id);
        }

        public string getCustomerFirstName(int id)
        {
            return Customers[id].First_Name;
        }

        public int getCustomerID(int id)
        {
            return Customers[id].CustomerId;
        }

        public string getCustomerLastName(int id)
        {
            return Customers[id].Last_Name;
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

        public double getProductQuantity(int id)
        {
            return Catalog[id].Quantity;
        }
    }
}
