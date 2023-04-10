using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Events : IData<Event>
    {
        private List<Event> _events;
        public void Add(Event instance)
        {
            _events.Add(instance);
        }

        public Event Get(int index)
        {
            return _events[index];
        }

        public List<Event> GetAll()
        {
            return _events;
        }

        public void Remove(int index)
        {
            _events.RemoveAt(index);
        }
    }
}
