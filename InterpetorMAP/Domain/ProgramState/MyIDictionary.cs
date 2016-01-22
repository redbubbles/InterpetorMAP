using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;

namespace InterpretorMap.Domain.Statement
{
    public interface MyIDictionary<T>
    {
        int Lookup(String id);

        bool IsDefined(String id);

        void Update(String id, int val);

        void Add(T item);

        int GetLength();

        T Get(int i);

        String ToString();


    }
}
