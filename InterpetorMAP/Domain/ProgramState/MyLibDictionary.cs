using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;

namespace InterpretorMap.Domain.ProgramState
{



    [Serializable]
    class MyLibDictionary<T> : MyIDictionary<MyMap>
    {
        private Stack<Dictionary<String, int>> item; 
        private Dictionary<String, int> items; 

        public MyLibDictionary()
        {
            item = new Stack<Dictionary<string, int>>();
            items = item.ElementAt(0);
        }

        public bool IsEmpty()
        {
            return (items == null || items.Count < 1);
        }

        

        public int Lookup(String id)
        {
            int x;
            if (items.ContainsKey(id))
            {
                if (items.TryGetValue(id, out x))
                    return x;
            }
            return 0;
        }

        public bool IsDefined(String id)
        {
            return items.ContainsKey(id);
        }

        public void Update(String id, int val)
        {
            String x = id;
            if (items.ContainsKey(id)) {
                items.Remove(id);
                items.Add(x, val);
            }
        }

        public void Add(MyMap m)
        {
            items.Add(m.id, m.val);
        }

        public int GetLength()
        {
            return items.Count();
        }

        public MyMap Get(int i)
        {
            String k="";
            int Val = items[items.Keys.ToList()[i]];
            foreach(KeyValuePair < string, int > entry in items)
{               if (entry.Value == Val)
                    k = entry.Key;
            }
            MyMap x = new MyMap(k, Val);
            return x;
        }

        public String ToStr()
        {
            String s = "{";
            MyMap x = null;
            foreach (KeyValuePair<string, int> entry in items) {            
                x = new MyMap(entry.Key,entry.Value);
                s += x.ToStr() + " ,";
            }
            s += "}";
            return s;
        }

       
    }
}
