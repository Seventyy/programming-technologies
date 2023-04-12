using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Events : IData<Event>
    {
        private List<Event> _events { get; set; }

        public Events() { 
            _events = new List<Event>();
        } 
        public void Add(Event instance)
        {
            _events.Add(instance);
        }

        public Event Get(int index)
        {
            if(index < _events.Count) 
            return _events[index];

            return null;
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
