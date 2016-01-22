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
    public class rHExp: Exp
    {
        String id;

        public rHExp(String id)
        {
            this.id = id;

        }

        public override int Eval(Stack<MyIDictionary<MyMap>> tbl, IHeap<HMap> heap)
        {
            return tbl.ElementAt(0).Lookup(id);
        }


        public override String ToStr()
        {
            return id;

        }

    }
}
