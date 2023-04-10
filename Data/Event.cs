using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Event 
    {
        private enum states {passive, active, finished};
        private states state
        {
            get; set;
        }

    }
}
