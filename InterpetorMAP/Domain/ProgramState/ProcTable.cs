using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpetorMAP.Domain.ProgramState
{
    [Serializable]
    class ProcTable<Proc> : MyProcTable<Proc>
    {
        public List<Proc> items;


        

    }
}
