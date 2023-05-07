using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.abstraction.interfaces;

namespace Data
{
    internal class ReturnEvent : IEvent
    {
        public int EventId { get; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public DateTime EventOccurenceTime { get; }

        public ReturnEvent(int eid, int cid, int pid)
        {
            EventId = eid;
            CustomerId = cid;
            ProductId = pid;
            EventOccurenceTime = DateTime.Now;
        }
    }
}
