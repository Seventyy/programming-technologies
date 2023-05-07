using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Customer
    {
        public int id
        {
            get; private set;
        }

        private List<Item> cart
        {
            get; set;
        }

        public Customer(int index)
        {
            if (index < 0)
                throw new ArgumentNullException("value");
            id = index;
            cart = new List<Item>();
        }

        public Item GetCartItem(int index)
        {
            if (index < cart.Count)
                return cart[index];

            return null;
        }

        public void AddCartItem(Item item)
        {
            cart.Add(item);
        }

        public void RemoveCartItem(int index)
        {
            if (index < cart.Count)
                cart.RemoveAt(index);
        }

        public (int id, List<Item> list) GetCustomerProperties()
        {
            return (this.id, this.cart);
        }

    }
}
