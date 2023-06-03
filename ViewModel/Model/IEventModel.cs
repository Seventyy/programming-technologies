using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
    public interface IEventModel
    {
        int EventId { get; }
        int CustomerId { get; set; }
        int ProductId { get; set; }
        DateTime EventOccurenceTime { get; }

        void Add();
        void Delete();
    }
}
