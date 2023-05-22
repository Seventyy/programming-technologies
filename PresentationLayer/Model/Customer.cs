using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace PresentationLayer.Model
{
    internal class Customer : ICustomer
    {
        public int CustomerId { get; }
        public string First_Name { get; set; }
        public int Last_Name { get; set; }
        public IServiceApi ServiceApi { get; }

        internal Customer(IServiceApi service)
        {
            ServiceApi = service;
        }

        public void Add(int cid, string fn, string ln)
        {
            ServiceApi.addCustomer(cid, fn, ln);
        }

        public void Delete(int cid)
        {
            ServiceApi.deleteCustomer(cid);
        }

        public void Update(int cid, int new_cid, string fn, string ln)
        {
            ServiceApi.updateCustomer(cid, new_cid, fn, ln);
        }
    }
}
