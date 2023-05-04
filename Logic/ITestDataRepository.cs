using Data.abstraction.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ITestDataRepository
    {
        public List<ICustomer> Customers { get; set; }
        public List<IEvent> Events { get; set; }
        public List<IProduct> Catalog { get; set; }
        public List<IState> States { get; set; }
    }
}
