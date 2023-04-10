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
        public Customer Get(int index)
        {
            return _customers[index];
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public void Remove(int index)
        {
            _customers.RemoveAt(index);
        }

        public void Add(Customer instance)
        { 
            _customers.Add(instance);
        }

        public (int id, List<Item> list) GetCartItemProperties(int index)
        {

            return _customers[index].GetCustomerProperties();

        }

        public void SetCartItemProperties(int index, int id, List<Item> cart)
        {
            _customers[index].SetCustomerProperties(id, cart);
        }

    }
}
