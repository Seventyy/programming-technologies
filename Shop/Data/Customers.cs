using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Customers : IData<Customer>
    {
        private List<Customer> _customers;

        public Customers()
        {
            _customers = new List<Customer>();
        }
        public Customer Get(int index)
        {
            if(index < _customers.Count) 
                return _customers[index];

            return null;
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public void Remove(int index)
        {
            if(index < _customers.Count)
            _customers.RemoveAt(index);
        }

        public void Add(Customer instance)
        { 
            _customers.Add(instance);
        }


    }
}
