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
    public class LogicalOp :Exp
    {
        public Exp e1;
        public Exp e2;
        public int op;

        public LogicalOp(Exp e1, Exp e2, int op)
        {
            this.e1 = e1;
            this.e2 = e2;
            this.op = op;
        }

        public LogicalOp(Exp e1, int op)
        {
            this.e1 = e1;
            this.op = op;
        }
        public override String ToStr()
        {
            switch (op)
            {
                case 1:
                    return "( " + e1.ToStr() + " && " + e2.ToStr() + " )";
                case 2:
                    return "( " + e1.ToStr() + " || " + e2.ToStr() + " )";
                case 3:
                    return " !( " + e1.ToStr() + " )";
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            return "  ";

        }

        public override int Eval(Stack<MyIDictionary<MyMap>> tbl, IHeap<HMap> heap)
        {
            switch (op)
            {
                case 1:
                    if (e1.Eval(tbl,heap) > 0 && e2.Eval(tbl,heap) > 0)
                        return 1;
                    else
                        return 0;
                case 2:
                    if (e1.Eval(tbl,heap) > 0 || e2.Eval(tbl,heap) > 0)
                        return 1;
                    else
                        return 0;
                case 3:
                    if (!(e1.Eval(tbl,heap) == 0))
                        return 1;
                    else
                        return 0;

                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            return 0;
        }

    }
}
