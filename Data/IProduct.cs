using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.abstraction.interfaces
{
    public interface IProduct
    {
        int ProductId { get; }
        string Name { get; set; }
        double Quantity { get; set; }
        double Price { get; set; }
    }
}
