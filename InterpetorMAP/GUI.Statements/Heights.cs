using System.Collections.Generic;

namespace InterpetorMAP.GUI.Statements
{
    internal class Heights
    {
        private static readonly Dictionary<string, int> heights =
            new Dictionary<string, int>(10)
            {
                {"CompStmt", 10},
                {"AssignStmt", 140},
                {"ConstExp", 40},
                {"ArithExp", 70 },
                {"LogicalOp", 70 },
                {"VarExp", 40 },
                {"RelationalOp", 70},
                {"PrintStmt", 140 },
                {"NewStmt", 140 },
                {"IfStmt", 140 },
                {"WhileStmt", 140 },
                {"rH", 40 },
                {"WHStmt", 40},
                {"ForkStmt", 140 },
                {"SkipStmt", 100 }



            };

        public static int Get(string name)
        {
            return heights[name];
        }
    }
}