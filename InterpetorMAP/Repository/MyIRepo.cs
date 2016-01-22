using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;
using InterpretorMap.Domain.ProgramState;

namespace InterpretorMap.Repository
{
    public interface MyIRepo
    {
        PrgState GetCrtPrg();
       
        List<PrgState> GetPrgList();

        void SetPrgList(List<PrgState> p);

        void SerializeProgState(PrgState p);

        PrgState DeserializeProgState();

        void ProgStateFile(PrgState p);

    }
}
