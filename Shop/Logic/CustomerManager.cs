using System;
using Data;

namespace Logic
{
    public class CustomerManager
    {
        Customers customers;
        CatalogManager catalogManager;
        public CustomerManager(Customers customers, CatalogManager catalogManager)
        {
            this.customers = customers;
            this.catalogManager = catalogManager;
        }
        public void BuyCart(Customer customer)
        {
            for (int i = 0; ; i++)
            {
                Item item = customer.GetCartItem(i);
                if (item is null) break;
                Event e = new Event(item, Event.states.active);
                catalogManager.HandleEvent(e);
            }
        }
/*
        void BuyCart(int customer_id)
        {
            BuyCart(customers.GetAll()[customer_id]);
        }
*/
    }
}
