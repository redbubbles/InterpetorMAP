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
    public class ArithExp:Exp
    {
        public Exp e1;
        public Exp e2;
        public int op; //1 stands for +, 2 for -, etc. 3-*, 4->/



        public ArithExp(Exp e1, Exp e2, int op)
        {
            this.e1 = e1;
            this.e2 = e2;
            this.op = op;
        }

        public override String ToStr()
        {
            switch (op)
            {
                case 1:
                    return e1.ToStr() + " + " + e2.ToStr();
                case 2:
                    return e1.ToStr() + " - " + e2.ToStr();
                case 3:
                    return e1.ToStr() + " * " + e2.ToStr();
                case 4:
                    return e1.ToStr() + " / " + e2.ToStr();
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }

            return " c ";

        }

        public override int Eval(Stack<MyIDictionary<MyMap>> tbl, IHeap<HMap> heap)
        {
            switch (op)
            {
                case 1:
                    return (e1.Eval(tbl,heap) + e2.Eval(tbl,heap));
                case 2:
                    return (e1.Eval(tbl,heap) - e2.Eval(tbl,heap));
                case 3:
                    return (e1.Eval(tbl,heap) * e2.Eval(tbl,heap));
                case 4:
                    return (e1.Eval(tbl,heap) / e2.Eval(tbl,heap));
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            return 0;
        }
    }
}
