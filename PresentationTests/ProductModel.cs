using PresentationLayer.Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests
{
    internal class ProductModel : IProcuctModel
    {
        public int ProductId { get; }

        public string Name { get; set; }
        public double Price { get; set; }
        public double State { get; set; }

        IServiceApi ServiceApi;

        public ProductModel(IServiceApi ServiceApi, int pid, string n, double p, double s)
        {
            this.ServiceApi = ServiceApi;

            ProductId = pid;
            Name = n;
            Price = p;
            State = s;
        }

        public void Add()
        {
            ServiceApi.addProduct(ProductId, Name, Price, State);
        }

        public void Edit(string n, double p, double s)
        {
            ServiceApi.updateProduct(ProductId, n, p, s);
        }

        public void Delete()
        {
            ServiceApi.deleteProduct(ProductId);
        }

    }
}
