using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Catalog : IData<Item>
    {

        private List<Item> _items;

        public Catalog()
        {
            _items = new List<Item>();
        }

        public void Add(Item instance)
        {
            _items.Add(instance);
        }

        public Item Get(int index)
        {
            if (index < _items.Count)
                return _items[index];

            return null;
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public void Remove(int index)
        {
            if (index < _items.Count)
                _items.RemoveAt(index);
        }

    }
}
