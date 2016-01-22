using InterpretorMap.Domain.ProgramState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpretorMap.Domain.Statement
{
    
    public interface IStmt
    {
         String ToStr();
         PrgState Execute(PrgState state);
    }
}
