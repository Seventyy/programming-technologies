using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.abstraction.interfaces
{
    public interface IEvent
    {
        int EventId { get; }
        int CustomerId { get; set; }
        int ProductId { get; set; }
        DateTime EventOccurenceTime { get; }

        String EventType { get; set; }

    }
}
