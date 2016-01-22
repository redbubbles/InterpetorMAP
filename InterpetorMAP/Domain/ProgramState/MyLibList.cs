using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;
namespace InterpretorMap.Domain.ProgramState
{
    [Serializable]
    class MyLibList<T> :MyIList<int>
    {     
        private List<int> items;

        public MyLibList(){
            items = new List<int>();
        }

        public void Add1(int item) { items.Add(item); }

        public int Get(int pos) { return items.ElementAt(pos); }

        public int Remove(int pos)
        {
            int x = items.ElementAt(pos);
            items.RemoveAt(pos);
            return x;
        }

        public int Size() { return items.Count(); }

        public bool IsEmpty() {
            if (!items.Any())
                return false;

            return true;
        }
    }
}
