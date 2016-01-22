using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;
namespace InterpretorMap.Domain.Statement
{
   public interface MyIList<T>
    {
        void Add1(T E);
        T Get(int pos);
        T Remove(int pos);

        //boolean contains(Object E);
        int Size();
        bool IsEmpty();
    }
}
