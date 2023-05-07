using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.abstraction.interfaces
{
    public interface IState
    {
        int StateId { get; }

        int ProductId { get; }

        double ProductQuantity { get; set; }
    }
}
