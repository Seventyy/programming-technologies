using Data.abstraction.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ApplicationLogic : LogicApi
    {
        private DataApi api;

        public ApplicationLogic(DataApi api)
        {
            this.api = api;
        }

        public void Buy(IProduct product, ICustomer customer, double quantity = 1)
        {
            api.updateState(product.ProductId, api.getStateQuantity(product.ProductId) - quantity);

            api.addEvent(0, customer.CustomerId, product.ProductId, "b");
        }

        public void Return(IProduct product, ICustomer customer)
        {
            api.updateState(product.ProductId, api.getStateQuantity(product.ProductId) + 1);

            api.addEvent(0, customer.CustomerId, product.ProductId, "r");
        }
    }
}
