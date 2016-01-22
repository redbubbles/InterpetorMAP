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
    class WhileStmt : IStmt
    {
        public Exp exp;
        public IStmt[] stmt;

        public WhileStmt(Exp e, params IStmt[] s)
        {
            stmt = s;
            exp = e;
        }

        public String ToStr()
        {
            String s = "WHILE(" + exp.ToStr() + " ){" ;
            foreach (IStmt i in stmt)
                s += i.ToStr() + ",";
            s += "}";
            return s;
        }

        public PrgState Execute(PrgState state)
        {
            MyIStack<IStmt> stk = state.GetStk();
            IStmt[] s = this.stmt;
            int k = exp.Eval(state.GetSymTable(), state.GetHeap());

            while (k > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    stk.Push(s[i]);
                }
                k--;
            }
            return null;
        }

    }
}
