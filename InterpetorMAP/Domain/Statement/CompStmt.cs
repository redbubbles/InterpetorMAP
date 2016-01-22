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
    public class CompStmt :IStmt
    {
        public IStmt first;
        public IStmt snd;

        public CompStmt(IStmt first, IStmt second)
        {
            this.first = first;
            this.snd = second;
        }

        public String ToStr()
        {
            return "Comp: (" + first.ToStr() + "; "  + snd.ToStr() + ")";
        }

        public PrgState Execute(PrgState state)
        {
            MyIStack<IStmt> stk = state.GetStk();
            stk.Push(this.snd);
            stk.Push(this.first);
            
            
            return null;
        }



    }
}
