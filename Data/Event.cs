using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Event 
    {
        public enum states {passive, active, finished};

        public states state
        {
            get; set;
        }
        public Event()
        {
            this.state = states.passive;
        }

        public void setState(states state)
        {
            this.state = state;
        }

    }
}
