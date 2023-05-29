using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
    public interface ICustomerModel
    {
        int CustomerId { get; }
        string First_Name { get; set; }
        string Last_Name { get; set; }

        void Add();
        void Edit(int cid, string fn, string ln); 
        void Delete();
    } 
}
