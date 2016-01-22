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
    public class ConstExp:Exp
    {
        public int number;

        public override int Eval(Stack<MyIDictionary<MyMap>> tbl, IHeap<HMap> heap)
        {
            return number;
        }

        public ConstExp(int nr)
        {
            number = nr;

        }

        public override String ToStr()
        {

            return " " + number;
        }
    }
}
