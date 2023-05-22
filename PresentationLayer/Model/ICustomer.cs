using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
    internal interface ICustomer
    {
        int CustomerId { get; }
        string First_Name { get; set; }
        int Last_Name { get; set; }
        void Add(int cid, string fn, string ln);
        void Delete(int cid);
        void Update(int cid, int new_cid, string fn, string ln);
    }
}
