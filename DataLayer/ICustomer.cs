using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.abstraction.interfaces
{
    public interface ICustomer
    {
        int CustomerId { get; }
        string First_Name { get; set; }
        string Last_Name { get; set; }

    }
}