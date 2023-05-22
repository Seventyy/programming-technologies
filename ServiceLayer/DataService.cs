using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Data.abstraction.interfaces;
    using Data;
    public class DataService : IServiceApi
    {
        IDataApi _context { get; set; }
        public DataService()
        {
            _context = new DataRepository();
        }

        public void addCustomer(int cid, string fn, string ln)
        {
            _context.addCustomer(cid, fn, ln);
        }

        public void addEvent(int eid, int cid, int pid, string mode)
        {
            if (mode == "b")
            {
                _context.addEvent(eid, cid, pid, mode);
            }
            if (mode == "r")
            {
                _context.addEvent(eid, cid, pid, mode);
            }
        }

        public void addProduct(int pid, string n, double p, double s)
        {
            _context.addProduct(pid, n, p, s);
        }

        public void deleteCustomer(int id)
        {
            _context.deleteCustomer(id);
        }

        public void deleteProduct(int id)
        {
            _context.deleteProduct(id);
        }

        public void deleteEvent(int id)
        {
            _context.deleteEvent(id);
        }

        public string getCustomerFirstName(int id)
        {
            return _context.getCustomerFirstName(id);
        }

        public int getCustomerID(int id)
        {
            return _context.getCustomerID(id);
        }

        public string getCustomerLastName(int id)
        {
            return _context.getCustomerLastName(id);
        }

        public int getProductID(int id)
        {
            return _context.getProductID(id);
        }

        public string getProductName(int id)
        {
            return _context.getProductName(id);
        }

        public double getProductPrice(int id)
        {
            return _context.getProductPrice(id);
        }


        public int getEventCustomerId(int id)
        {
            return _context.getEventCustomerId(id);
        }

        public int getEventProductId(int id)
        {
            return _context.getEventProductId(id);
        }

        public int getEventId(int id)
        {
            return _context.getEventId(id);
        }

        public DateTime getEventDate(int id)
        {
            return _context.getEventDate(id);
        }


        public void updateProduct(int id, string m, double p, double s)
        {
            _context.updateProduct(id, m, p, s);
        }

        public void updateCustomer(int id, int cid, string first_name, string last_name)
        {
            _context.updateCustomer(id, cid, first_name, last_name);
        }

        public double getProductState(int id)
        {
            return _context.getProductState(id);
        }
        public List<IProduct> getProducts()
        {
            return _context.getProducts();
        }

        public List<ICustomer> getCustomers()
        {
            return _context.getCustomers();
        }

        public List<IEvent> getEvents()
        {
            return _context.getEvents();
        }
    }
}

