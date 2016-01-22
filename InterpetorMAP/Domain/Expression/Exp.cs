using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;
using InterpretorMap.Domain.ProgramState;

namespace InterpretorMap.Domain.Expression
{
    [Serializable]
    public abstract class Exp
    {
        public virtual int Eval(Stack<MyIDictionary<MyMap>> tbl, IHeap<HMap> heap)
        {
            return 0;
        }

        public abstract String ToStr();
    }

}
