using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.abstraction.interfaces;
using Service;

namespace ServiceTests
{
    public class TestDataService : IServiceApi
    {
        public List<String> stringsC = new List<String>();
        public List<String> stringsE = new List<String>();
        public List<String> stringsP = new List<String>();

        public void addCustomer(int customer_id, string first_name, string last_name)
        {
            stringsC.Add(first_name);
        }

        public void addEvent(int id, int customer_id, int product_id, string mode)
        {
            stringsC.Add(mode);
        }

        public void addProduct(int pid, string name, double price, double state)
        {
            stringsP.Add(name);
        }

        public void deleteCustomer(int id)
        {
            stringsC.RemoveAt(id);
        }

        public void deleteEvent(int id)
        {
            stringsE.RemoveAt(id);
        }

        public void deleteProduct(int id)
        {
            stringsP.RemoveAt(id);
        }

        public string getCustomerFirstName(int id)
        {
            return stringsC[id];
        }

        public string getCustomerLastName(int id)
        {
            return stringsC[id];
        }

        public List<ICustomer> getCustomers()
        {
            throw new NotImplementedException();
        }

        public List<String> getCustomersAll()
        {
            return stringsC;
        }

        public int getEventCustomerId(int id)
        {
            return 0;
        }

        public DateTime getEventDate(int id)
        {
            throw new NotImplementedException();
        }

        public int getEventProductId(int id)
        {
            return 0;
        }

        public List<IEvent> getEvents()
        {
            throw new NotImplementedException();
        }

        public string getProductName(int id)
        {
            return stringsP[id];
        }

        public double getProductPrice(int id)
        {
            return 0;
        }

        public List<IProduct> getProducts()
        {
            throw new NotImplementedException();
        }

        public double getProductState(int id)
        {
            return 0;
        }

        public void updateCustomer(int id, int customer_id, string first_name, string last_name)
        {
            throw new NotImplementedException();
        }

        public void updateProduct(int id, string name, double price, double state)
        {
            throw new NotImplementedException();
        }
    }
}
