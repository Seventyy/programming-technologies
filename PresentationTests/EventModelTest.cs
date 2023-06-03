using Data.abstraction.interfaces;
using PresentationLayer.Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests
{
    internal class EventModelTest : IEventModel
    {
        public int EventId { get; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime EventOccurenceTime { get; }

        IServiceApi ServiceApi;

        public EventModelTest(IServiceApi ServiceApi, int eid, int cid, int pid, DateTime dt)
        {
            this.ServiceApi = ServiceApi;

            EventId = eid;
            CustomerId = cid;
            ProductId = pid;
            EventOccurenceTime = dt;
        }

        public void Add()
        {
            ServiceApi.addEvent(EventId, CustomerId, ProductId, "b");
        }

        public void Delete()
        {
            ServiceApi.deleteEvent(EventId);
        }
    }
}
