using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterpretorMap.Domain.ProgramState;
using System.Threading.Tasks;

namespace InterpretorMap.Domain.ProgramState
{
    [Serializable]
    class Heap<T> : IHeap<T> 
    {

        public List<HMap> items;

        public Heap()
        {
            items = new List<HMap>();
        }

        public void Add1(int val) {
            int index = items.Capacity;
            HMap item= new HMap(index, val);
            items.Add(item);
        }

        public HMap Gett(int pos)
        {
            return items.ElementAt(pos);
        }

        public HMap Remove(int pos)
        {
            HMap x = (HMap)items.ElementAt(pos);
            items.RemoveAt(pos);
            return x;
        }

        public int GiveHeapLocation()
        {
            return items.Capacity;
        }

        public int Size() { return items.Count(); }

        public bool IsEmpty()
        {
            if (!items.Any())
                return false;

            return true;
        }
    }
}


