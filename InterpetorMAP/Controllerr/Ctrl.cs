using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;
using InterpretorMap.Domain.Expression;
using InterpretorMap.Domain.ProgramState;
using InterpretorMap.Repository;

namespace InterpretorMap.Controller
{
    public class Ctrl
    {
        public MyIRepo repo;

        public Ctrl(MyIRepo r)
        {
            repo = r;
        }

        public string OneStepForAllPrg()
        {
            string s = "";



            List<PrgState> prgList = repo.GetPrgList();

            foreach (PrgState p in prgList)
            {
                p.ToStr();
                s = s + p.TextBoxPrint();
            }

            List<Task<PrgState>> taskList = (from prg in prgList
                                             select Task<PrgState>.Factory.StartNew(() => prg.OneStep())).ToList();

            //get the PrgState results
            List<PrgState> newPrgList = (from tsk in taskList
                                         where tsk.Result != null
                                         select tsk.Result).ToList();

            //add the new created threads to the list of existing threads
            prgList.AddRange(newPrgList);

           
            repo.SetPrgList(prgList);
            return s;
        }




        public string AllStep()
        {
            string s="";
           
           while(true)
            {
                List<PrgState> prgList = RemoveCompletedPrg(repo.GetPrgList());
                if (prgList.Count == 0)
                    return s + OneStepForAllPrg();
                else
                   s = s +  OneStepForAllPrg() + "\n\n";
               
            }
            return s;


            //try
            //{
            //    while (!prg.exeStack.IsEmpty())
            //    {
            //        //remove the completed programs
            //        List<PrgState> prgList = RemoveCompletedPrg(repo.GetPrgList());
            //        if (prgList.Count == 0)
            //            return;
            //        else
            //            OneStepForAllPrg();
            //    }
            //}
            //catch (MyStmtExecException e)
            //{
            //    throw;
            //}

        }

        public List<PrgState> RemoveCompletedPrg(List<PrgState> inPrgList)
        {
            return inPrgList.Where(p => p.IsNotCompleted()).ToList<PrgState>();
        }





        /*first implementation for oneStep--------------------------------------------------------------------------
        /** If the statement is an assign one 


          if (crtStmt is AssignStmt) {
              AssignStmt crtStmt1 = (AssignStmt)crtStmt;
              Exp exp = crtStmt1.exp;
              MyIDictionary<MyMap> symTbl = state.GetSymTable();
              String id = crtStmt1.id;
              IHeap<HMap> heap = state.heap;
              int val = exp.Eval(symTbl, heap);

              if (symTbl.IsDefined(id))
                  symTbl.Update(id, val);
              else
              {
                  MyMap m = new MyMap(id, val);
                  symTbl.Add(m);

              }
              return;
          }



          /** If the statement is an comp one 

          if (crtStmt is CompStmt) {
              CompStmt crtStmt1 = (CompStmt)crtStmt;
              stk.Push(crtStmt1.snd);
              stk.Push(crtStmt1.first);
              return;
          }


          if (crtStmt is IfStmt){
              IfStmt crtStmt1 = (IfStmt)crtStmt;
              Exp exp = crtStmt1.exp;
              IStmt thenStmt = ((IfStmt)crtStmt).thenS;
              IStmt elseStmt = ((IfStmt)crtStmt).elseS;
              if (exp.Eval(state.GetSymTable(),state.GetHeap()) == 1)
                  stk.Push(thenStmt);
              else
                  stk.Push(elseStmt);
              return;
          }

          if (crtStmt is WhileStmt){
              WhileStmt crtStmt1 = (WhileStmt)crtStmt;
              Exp exp = crtStmt1.exp;
              IStmt[] s = crtStmt1.stmt;
              int k = exp.Eval(state.GetSymTable(),state.GetHeap());
              while (k > 0)
              {
                  for(int i=0; i<s.Length;i++)
                       stk.Push(s[i]);
                  k--; 
              }
              return;
          }

          if (crtStmt is PrintStmt){
              PrintStmt crtStmt1 = (PrintStmt)crtStmt;
              Exp exp = crtStmt1.exp;
              list.Add1(exp.ToStr());
              return;
          }
          /**--------------------------------------------------------------------------
          //finish one step old implementation
          */



    }
}
