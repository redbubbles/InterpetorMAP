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
    public class New :IStmt
    {
        public String var;
        public Exp exp;

        public New(String var,Exp exp){
            this.var = var;
            this.exp = exp;
        }

        public String ToStr(){

            return "new(" + var + " , "  + exp.ToStr() + ")";
        }

        public PrgState Execute(PrgState state) {

            Stack<MyIDictionary<MyMap>> symTbl = state.GetSymTable();
            IHeap<HMap> heap = state.GetHeap();
            String v = this.var;
            int index = heap.GiveHeapLocation();

            int val = exp.Eval(symTbl, heap);
            
            if (symTbl.ElementAt(0).IsDefined(v))
                symTbl.ElementAt(0).Update(v, index);

            else
            {
                MyMap m = new MyMap(v, index);
                symTbl.ElementAt(0).Add(m);
            }
            
            heap.Add1(val);

            return null;
        }
    }

}
