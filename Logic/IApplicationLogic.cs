using Data.abstraction.interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IApplicationLogic
    {
        static IApplicationLogic CreateLogic(DataApi dataApi)
        {
            return new ApplicationLogic(dataApi);
        }

        void Buy(IProduct product, ICustomer user);

        void Return(IProduct product, ICustomer user);

    }
}
