using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Expression;
using InterpretorMap.Domain.Statement;
using InterpretorMap.Domain.ProgramState;

namespace InterpretorMap.Domain.Statement
{
    [Serializable]
    public class PrintStmt:IStmt
    {
        public Exp exp;
        public PrintStmt(Exp exp)
        {
            this.exp = exp;
        }

        public String ToStr()
        {
            return "print(" + exp.ToStr() + ")";
        }

        public PrgState Execute(PrgState state)
        {
            MyIList<int> list = state.GetPrintList();
            list.Add1(exp.Eval(state.GetSymTable(),state.GetHeap()));
            return null;
        }



    }
}
