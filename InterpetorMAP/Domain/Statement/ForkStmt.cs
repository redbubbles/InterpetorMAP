using InterpretorMap.Domain.ProgramState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Repository;



namespace InterpretorMap.Domain.Statement
{
    [Serializable]
    class ForkStmt: IStmt
    {
        public IStmt stmt;

        public ForkStmt(IStmt s)
        {
            stmt = s;
        }

        public String ToStr()
        {
            return "Fork(" + stmt.ToStr() +") " ;
        }


        PrgState IStmt.Execute(PrgState state)
        {         

            MyIStack<IStmt> stack = new MyLibStack<IStmt>();
            Stack<MyIDictionary<MyMap>> symtable = state.GetSymTable();
            MyIList<int> printList = state.GetPrintList();
            IHeap<HMap> h = state.GetHeap();

            MyLibStack<IStmt> crtstm = new MyLibStack<IStmt>();


            PrgState childPrgState = new PrgState(stack, symtable, printList, stmt, h);
            childPrgState.id = state.id * 10;

    
            return childPrgState;

        }


    }
}
