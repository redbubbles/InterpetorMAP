using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Expression;
using InterpretorMap.Domain.Statement;
using InterpretorMap.Domain.ProgramState;

namespace InterpretorMap.Statement
{
    [Serializable]
    class IfStmt:IStmt
    {
        public Exp exp;
        public IStmt thenS;
        public IStmt elseS;

        public IfStmt(Exp e, IStmt t, IStmt el)
        {
            exp = e;
            thenS = t;
            elseS = el;
        }
        public String ToStr()
        {
            return "IF(" + exp.ToStr() + ") THEN(" + thenS.ToStr()
                    + ")ELSE(" + elseS.ToStr() + ")";
        }

        public PrgState Execute(PrgState state)
        {
            MyIStack<IStmt> stk = state.GetStk();
            IStmt thenStmt = this.thenS;
            IStmt elseStmt = this.elseS;
            if (exp.Eval(state.GetSymTable(), state.GetHeap()) != 0)
                stk.Push(thenStmt);
            else
                stk.Push(elseStmt);
            return null;
        }
    }
}
