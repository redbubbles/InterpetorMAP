using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;

namespace InterpretorMap.Domain.Statement
{
   public interface MyIStack<T>
    {
         bool IsEmpty();
         void Push(T item);
         int GetLength();
         T Get(int i);
         T Pop();
    }
}
