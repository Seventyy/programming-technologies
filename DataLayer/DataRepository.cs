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
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
               
                if (mode == "b")
                {
                    IEvent e = new BuyEvent(eid, cid, pid, "Buy");
                    Events.Add(e);
                    DataLayer.Event eve = mapper.Map<DataLayer.Event>(e);
                    db.Events.InsertOnSubmit(eve);

                }
                if (mode == "r")
                {
                    IEvent e = new ReturnEvent(eid, cid, pid, "Return");
                    Events.Add(e);
                    DataLayer.Event eve = mapper.Map<DataLayer.Event>(e);
                    db.Events.InsertOnSubmit(eve);
                }
                db.SubmitChanges();
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
                db.SubmitChanges();
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
                db.SubmitChanges ();
            }
        }

        public void deleteEvent(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Event> events = from eve in db.Events
                                                         where eve.Id == id
                                                         select eve;

                foreach (DataLayer.Event eve in events)
                {
                    db.Events.DeleteOnSubmit(eve);
                }
                db.SubmitChanges();
            }
        }

        public string? getCustomerFirstName(int id)
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


        public string? getCustomerLastName(int id)
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

       
        public string? getProductName(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Product> products = from prod in db.Products
                                                         where prod.Id == id
                                                         select prod;

                foreach (DataLayer.Product prod in products)
                {
                    return prod.Name;
                }
            }
            return null;
        }

        public double getProductPrice(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Product> products = from prod in db.Products
                                                         where prod.Id == id
                                                         select prod;

                foreach (DataLayer.Product prod in products)
                {
                    return prod.Price;
                }
            }
            return 0;
        }


        public int getEventCustomerId(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Event> events = from eve in db.Events
                                                     where eve.Id == id
                                                     select eve;

                foreach (DataLayer.Event eve in events)
                {
                    return eve.CustomerId;
                }
            }
            return 0;
        }

        public int getEventProductId(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Event> events = from eve in db.Events
                                                     where eve.Id == id
                                                     select eve;

                foreach (DataLayer.Event eve in events)
                {
                    return eve.ProductId;
                }
            }
            return 0;
        }

      
        public DateTime? getEventDate(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Event> events = from eve in db.Events
                                                     where eve.Id == id
                                                     select eve;

                foreach (DataLayer.Event eve in events)
                {
                    return eve.EventOccurenceTime;
                }
            }
            return null;
        }


        public void updateProduct(int id, string n, double p, double s)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Product> products = from prod in db.Products
                                                         where prod.Id == id
                                                         select prod;

                foreach (DataLayer.Product prod in products)
                {
                   prod.Price = p;
                   prod.Name = n;
                   prod.State = s;
                }
                db.SubmitChanges();
            }
        
        }

        public void updateCustomer(int id, int cid, string first_name, string last_name)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Customer> customers = from cus in db.Customers
                                                           where cus.Id == id
                                                           select cus;

                foreach (DataLayer.Customer customer in customers)
                {
                    customer.first_name = first_name;
                    customer.last_name = last_name;
                }
                db.SubmitChanges();
            }
        }

        public double getProductState(int id)
        {
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Product> products = from prod in db.Products
                                                         where prod.Id == id
                                                         select prod;

                foreach (DataLayer.Product prod in products)
                {
                    return prod.State;
                }
            }
            return 0;
        }

        public List<ICustomer> getCustomers()
        {
            List <DataLayer.Customer> customes = new List<DataLayer.Customer>();
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Customer> customers = from cus in db.Customers
                                                           select cus;

                foreach (DataLayer.Customer customer in customers)
                {
                    customes.Add(customer);
                }
            }
            return Customers;
        }
        
        public List<IProduct> getProducts()
        {
            List<DataLayer.Product> cata = new List<DataLayer.Product> ();
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Product> products = from prod in db.Products
                                                         select prod;

                foreach (DataLayer.Product prod in products)
                {
                    cata.Add (prod);
                }
            }
            return Catalog;
        }

        public List<IEvent> getEvents()
        {
            List<DataLayer.Event> evens = new List<DataLayer.Event>();
            using (DataLayer.DataClasses1DataContext db = new DataLayer.DataClasses1DataContext(connection))
            {
                IQueryable<DataLayer.Event> events = from eve in db.Events
                                                     select eve;

                foreach (DataLayer.Event eve in events)
                {
                    evens.Add(eve);   
                }
            }
            return Events;
        }
    }
}
