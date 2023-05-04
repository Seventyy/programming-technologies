using Data.abstraction.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class TestDataRepository : DataApi
    {
        public List<ICustomer> Customers;
        public List<IEvent> Events;
        public List<IProduct> Catalog;
        public List<IState> States;

        public TestDataRepository()
        {
            Customers = new List<ICustomer>();
            Events = new List<IEvent>();
            Catalog = new List<IProduct>();
            States = new List<IState>();
        }
    }
}
