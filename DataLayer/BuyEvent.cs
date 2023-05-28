using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.abstraction.interfaces;

namespace Data
{
    internal class BuyEvent : IEvent
    {
        public int EventId { get; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public DateTime EventOccurenceTime { get; }

        public String EventType { get; set; }

        public BuyEvent(int eid, int cid, int pid, String t)
        {
            EventId = eid;
            CustomerId = cid;
            ProductId = pid;
            EventType = t;
            EventOccurenceTime = DateTime.Now;
        }
    }
}
