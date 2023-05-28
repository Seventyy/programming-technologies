using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Data.abstraction.interfaces;


namespace Data
{
    public class DataRepository : IDataApi
    {

        private string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jjani\\source\\repos\\Task2\\DataTest\\Database1.mdf;Integrated Security=True";

        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Customer, DataLayer.Customer>();
            cfg.CreateMap<Product, DataLayer.Product>();
            cfg.CreateMap<IEvent, DataLayer.Event>();
        });


        public List<ICustomer> Customers { get; set; }
        public List<IEvent> Events { get; set; }
        public List<IProduct> Catalog { get; set; }

        IMapper mapper;
    

        public DataRepository()
        {
            Customers = new List<ICustomer>();
            Events = new List<IEvent>();
            Catalog = new List<IProduct>();
            mapper = configuration.CreateMapper();
     
        }

        public void addCustomer(int cid, string fn, string ln)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                Customer c = new Customer(cid, fn, ln);
                DataLayer.Customer customer = mapper.Map<DataLayer.Customer>(c);
                Customers.Add(c);
                db.Customers.InsertOnSubmit(customer);
                db.SubmitChanges();
            }
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

        public void addProduct(int pid, string n, double p, double s)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                Product prod = new Product(pid, n, p, s);
                DataLayer.Product product = mapper.Map<DataLayer.Product>(prod);
                Catalog.Add(prod);
                db.Products.InsertOnSubmit(product);
                db.SubmitChanges();
            }
        }

        public void deleteCustomer(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Customer> customers = from cus in db.Customers
                                                    where cus.Id == id
                                                    select cus;

                foreach (DataLayer.Customer customer in customers)
                {
                    db.Customers.DeleteOnSubmit(customer);
                }
            }
        }

        public void deleteProduct(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Product> products = from prod in db.Products
                                                         where prod.Id == id
                                                           select prod ;

                foreach(DataLayer.Product prod in products)
                {
                    db.Products.DeleteOnSubmit(prod);
                }
            }
        }

        public void deleteEvent(int id)
        {
            Events.RemoveAt(id);
        }

        public string getCustomerFirstName(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Customer> customers = from cus in db.Customers
                                                           where cus.Id == id
                                                           select cus;

                foreach (DataLayer.Customer customer in customers)
                {
                    return customer.first_name;
                }
            }
            return null;
        }


        public string getCustomerLastName(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Customer> customers = from cus in db.Customers
                                                           where cus.Id == id
                                                           select cus;

                foreach (DataLayer.Customer customer in customers)
                {
                    return customer.last_name;
                }
            }
            return null;
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

        public List<ICustomer> getCustomers()
        {
            return Customers;
        }

        public List<IProduct> getProducts()
        {
            return Catalog;
        }

        public List<IEvent> getEvents()
        {
            return Events;
        }
    }
}
