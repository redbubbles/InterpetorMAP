using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Expression;
using InterpretorMap.Domain.ProgramState;

namespace InterpretorMap.Domain.Statement
{
    [Serializable]
    public class AssignStmt: IStmt
    {
        public String id;
        public Exp exp;

        public AssignStmt(String id, Exp exp)
        {
            this.id = id;
            this.exp = exp;
        }

        public String ToStr()
        {
            return id + " ->  " + exp.ToStr();
        }


        public PrgState Execute(PrgState state)
        {
            Exp exp = this.exp;
            Stack<MyIDictionary<MyMap>> symTbl = state.GetSymTable();
            String id = this.id;
            IHeap<HMap> h = state.GetHeap();
            int val = exp.Eval(symTbl, h);
            if (symTbl.ElementAt(0).IsDefined(id))
                symTbl.ElementAt(0).Update(id, val);
            else
            {
                MyMap m = new MyMap(id, val);
                symTbl.ElementAt(0).Add(m);
            }
            return null;
        }
    }
}
