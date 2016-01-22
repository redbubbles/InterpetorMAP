using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpretorMap.Domain.ProgramState
{
    public interface IHeap<T>
    {
        void Add1(int item);
       HMap Gett(int pos);
        HMap Remove(int pos);
        int Size();
        bool IsEmpty();
        int GiveHeapLocation();
    }
}
