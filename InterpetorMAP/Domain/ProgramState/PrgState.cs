using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;
using InterpretorMap.Domain.Expression;
using InterpretorMap.Domain.ProgramState;

namespace InterpretorMap.Domain.ProgramState
{
    [Serializable]
    public class PrgState
    {
        public int id;
        public MyIStack<IStmt> exeStack;
        public Stack<MyIDictionary<MyMap>> symTable;
        public MyIList<int> output;
        public IStmt originalProgram; //optional field, but good to have
        public IHeap<HMap> heap;
  
        public PrgState()
        {
            id = 0;
            exeStack = null;
            symTable = null;
            output= null;
            originalProgram = null;
            heap = null;
        }

        public bool IsNotCompleted()
        {
            return !exeStack.IsEmpty();
        }

        public PrgState OneStep()
        {
            IStmt crtStmt = null;
            if (exeStack.IsEmpty())
            {
                Console.Write("empty stack!! \n");
                return null;
            }
            else
                crtStmt = exeStack.Pop();
                           
            return crtStmt.Execute(this);
        }

        public PrgState(MyIStack<IStmt> stk, Stack<MyIDictionary<MyMap>> symtbl, MyIList<int> otp, IStmt crtstm, IHeap<HMap> h)
        {
            id++;
            exeStack = stk;
            symTable = symtbl;
            output = otp;
            originalProgram = crtstm;
            exeStack.Push(crtstm);
            heap = h;
        }

        public MyIStack<IStmt> GetStk()
        {
            return exeStack;
        }



        public Stack<MyIDictionary<MyMap>> GetSymTable()
        {
            return symTable;
        }

        public MyIList<int> GetPrintList()
        {
            return output;
        }

        public IHeap<HMap> GetHeap()
        {
            return heap;
        }

        public string TextBoxPrint()
        {
            string s = "state id: " + id + "\n" + "ExeStack: {";
            for (int i = 0; i < exeStack.GetLength(); i++)
                s = s + exeStack.Get(i).ToStr() + " | ";
            s = s + "} \n SymTbl: {";
            for (int i = 0; i < symTable.ElementAt(0).GetLength(); i++)
                s = s + symTable.ElementAt(0).Get(i).ToStr() + " ; ";
            s = s + "} \n List: {";
            for (int i = 0; i < output.Size(); i++)
                s = s + output.Get(i) + " ; ";
            s = s + "}\n" + "Heap: {";
            for (int i = 0; i < heap.Size(); i++)
                s = s + heap.Gett(i).content + " ; ";
            s = s + "}\n\n";
            return s;
        }

        public void ToStr()
        {
            Console.Write("state id: ");
            Console.WriteLine(id);
            Console.Write("ExeStack: ");
            Console.Write("{");
          /*  for (int i = exeStack.GetLength() - 1; i >= 0; i--){
                Console.Write(exeStack.Get(i).ToStr() + " | ");
            }
            Console.Write("} \n");
            */

            for(int i=0;i<exeStack.GetLength();i++)
                Console.Write(exeStack.Get(i).ToStr() + " | ");
            Console.Write("} \n");
            //show the symTbl
            Console.Write("SymTbl: ");
            Console.Write("{");

            for (int i = 0; i < symTable.ElementAt(0).GetLength(); i++)
                Console.Write("" + symTable.ElementAt(0).Get(i).ToStr() + " ; ");
            Console.Write("} \n");


            //show the list of printed values
            
            Console.Write("List: ");
            Console.Write("{");

            for (int i = 0; i <output.Size(); i++ )
            Console.Write(output.Get(i) + " ; ");
            Console.Write("}\n");

            Console.Write("Heap: ");
            Console.Write("{");

            for (int i = 0; i < heap.Size(); i++)
                Console.Write(heap.Gett(i).content + " ; ");
            Console.Write("}\n\n");
        }

    }
}
