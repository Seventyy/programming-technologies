using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
    internal class EventModel : IEventModel
    {
        public int EventId { get; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime EventOccurenceTime { get; }

        IServiceApi ServiceApi;

        public EventModel(IServiceApi ServiceApi, int eid, int cid, int pid, DateTime dt)
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
