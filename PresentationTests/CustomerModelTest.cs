using PresentationLayer.Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests
{
    internal class CustomerModelTest : ICustomerModel
    {
        public int CustomerId { get; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        IServiceApi ServiceApi;

        public CustomerModelTest(IServiceApi ServiceApi, int id, string first_name, string last_name)
        {
            this.ServiceApi = ServiceApi;

            CustomerId = id;
            First_Name = first_name;
            Last_Name = last_name;
        }

        public void Add()
        {
            ServiceApi.addCustomer(CustomerId, First_Name, Last_Name);
        }
        public void Edit(int id, string first_name, string last_name)
        {
            ServiceApi.updateCustomer(CustomerId, id, first_name, last_name);
        }
        public void Delete()
        {
            ServiceApi.deleteCustomer(CustomerId);
        }
    }
}
