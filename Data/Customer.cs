using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Customer
    {
        private int id
        {
            get; set;
        }

        private List<Item> cart
        {
            get; set;
        }

        

        public Item GetCartItem(int index)
        {

            return cart[index];
        }

        public (int id, List<Item> list) GetCustomerProperties()
        {

            return (this.id, this.cart);
        }

        public void SetCustomerProperties(int id, List<Item> cart)
        {

            this.id = id;
            this.cart = cart;
        }

    }
}
