using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.ProgramState;
using InterpretorMap.Domain.Statement;

namespace InterpetorMAP.Domain.Statement
{
    [Serializable]
    class SkipStmt : IStmt
    {
        public PrgState Execute(PrgState state)
        {
            return null;
        }

        public string ToStr()
        {
            return "Skip";
        }
    }
}
