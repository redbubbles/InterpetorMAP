using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.ProgramState;
using InterpretorMap.Domain.Statement;

namespace InterpretorMap.Domain.ProgramState
{
    [Serializable]
    class MyLibStack<T> : MyIStack<IStmt>
    {
        private Stack<IStmt> items;

        public MyLibStack()
        {
            items = new Stack<IStmt>();
        }

        public bool IsEmpty() {
            if (items.Count == 0)
                return true;
            return false;
        }

        public void Push(IStmt item) { items.Push(item); }

        public int GetLength() { return items.Count(); }

        public IStmt Get(int i)
        {
            return items.ElementAt(i);
        }

        public IStmt Pop() { return items.Pop(); }

        public String toStr()
        {
            String s = "{";
            IStmt k;
            for (int i = items.Count() - 1; i >= 0; i--)
            {
                k = items.ElementAt(i);
                s += k.ToStr() + ", ";
            }
            s += "}";
            return s;
        }



    }
}
