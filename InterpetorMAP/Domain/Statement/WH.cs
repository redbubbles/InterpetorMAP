using InterpretorMap.Domain.Expression;
using InterpretorMap.Domain.ProgramState;
using InterpretorMap.Domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpretorMap.Domain.Statement
{
    [Serializable]
    public class WH : IStmt
    {
        public String var;
        public Exp exp;

        public WH(String var, Exp exp)
        {
            this.exp = exp;
            this.var = var;
        }

        public String ToStr()
        {
            return var + " -> " + exp.ToStr();
        }

        public PrgState Execute(PrgState state)
        {
            Stack<MyIDictionary<MyMap>> symTbl = state.GetSymTable();
            IHeap<HMap> heap = state.GetHeap();
            int address = symTbl.ElementAt(0).Lookup(this.var);
            try
            {
                HMap h = (HMap)heap.Gett(address);
                h.SetAddr(address);
                h.SetCont(exp.Eval(symTbl, heap));
            }
            catch (MissingMemberException e)
            {
            }
            return null;
        }
    }
}
