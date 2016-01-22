using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.ProgramState;
using InterpretorMap.Domain.Statement;

namespace InterpretorMap.Domain.Expression
{
    [Serializable]
    class RH: Exp
    {
        public String var;

        public RH(String v)
        {
            var = v;
        }

        public override String ToStr()
        {
            return var;
        }

        public override int Eval(Stack<MyIDictionary<MyMap>> tbl, IHeap<HMap> heap)
        {
            int content = 0;
            int address = (int)tbl.ElementAt(0).Lookup(var);
            try
            {
                content = heap.Gett(address).content;
            }
            catch (MissingMemberException e)
            {
                return -1;
            };
            return content;
        }
    }


}

