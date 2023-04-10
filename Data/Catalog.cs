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
        public void Add(Item instance)
        {
            _items.Add(instance);
        }

        public Item Get(int index)
        {
            return _items[index];
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public void Remove(int index)
        {
            _items.RemoveAt(index);
        }

        public (int, string, double) GetItemProperties(int index)
        {
            return _items[index].GetItemProperties();
        }

        public void SetItemProperties(int index, int id, string name, double quantity)
        {
            _items[index].SetItemProperties(id, name, quantity);
        }
    }
}
