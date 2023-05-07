using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IData<T>
    {
        public void Add(T instance);
        public T Get(int index);
        public void Remove(int index);
        public List<T> GetAll();
    }
}
