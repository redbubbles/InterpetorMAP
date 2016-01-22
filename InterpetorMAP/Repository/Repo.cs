using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpretorMap.Domain.Statement;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using InterpetorMAP;
using InterpretorMap.Domain.ProgramState;
using InterpretorMap.Domain.Expression;
using InterpretorMap.Statement;

namespace InterpretorMap.Repository
{
    public class Repo : MyIRepo
    {
        

        public List<PrgState> programs;

        public Repo()
        {
            
        }

        public Repo(IStmt S)
        {
            programs = new List<PrgState>();

            MyIStack<IStmt> stack = new MyLibStack<IStmt>();
            // MyIStack<String> stack = new MyLibStack();

            //MyIList<String> list = new MyArrayList();
            MyIList<int> list = new MyLibList<int>();

            //MyIDictionary<MyMap> dict = new MyLibDictionary<MyMap>();
            MyIDictionary<MyMap> d = new MyLibDictionary();

            Stack<MyIDictionary<MyMap>> dict = new Stack<MyIDictionary<MyMap>>();
            dict.Push(d);

            IHeap<HMap> heap = new Heap<HMap>();

            PrgState prog = new PrgState(stack, dict, list, S, heap);


            /*PrgState prog = new PrgState(stack, dict, list,
                new CompStmt
                    (new AssignStmt("a", new ConstExp(0)),

                    new CompStmt(
                            new IfStmt(
                                    new rHExp("a"),
                                    new AssignStmt("v", new ConstExp(2)),
                                    new New("v", new ArithExp(
                                                                    new ConstExp(1),
                                                                    new RelationalOp(new ConstExp(1), new ConstExp(2), 1),
                                                                    1))),
                            new CompStmt(
                                    new WhileStmt(

                                            new ConstExp(3),
                                            new PrintStmt(new rHExp("a"))),
                                    new CompStmt(
                                            new WH("v", new RelationalOp(new ConstExp(1), new ConstExp(2), 1)),
                                            new AssignStmt("y", new RH("v")))))), heap);
            
          */
            programs.Add(prog);
        }


        public List<PrgState> GetPrgList()
        {
            return programs;
        }

        public PrgState GetCrtPrg()
        {
            return programs.ElementAt(0);
        }

        public void SetPrgList(List<PrgState> p)
        {
            programs = p;
        }


        public void SerializeProgState(PrgState p)
        {


            Stream stream = null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream("C:/Users/Live/IdeaProjects/serProgState.txt", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, p);
            }
            catch
            {
                // do nothing, just ignore any possible errors
            }
            finally
            {
                if (null != stream)
                    stream.Close();
            }
            Console.WriteLine("Serialized data is saved in C:/Users/Live/IdeaProjects/serProgState.txt");

        }

        public PrgState DeserializeProgState()
        {
            Stream stream = null;
            PrgState p= new PrgState();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream("C:/Users/Live/IdeaProjects/serProgState.txt", FileMode.Open, FileAccess.Read, FileShare.None);
                p = (PrgState)formatter.Deserialize(stream);
            }
            catch
            {
                // do nothing, just ignore any possible errors
            }
            finally
            {
                if (null != stream)
                    stream.Close();
            }
            return p;


        }


        public void ProgStateFile(PrgState p)
        {
            StreamWriter writer = null;
            writer = new StreamWriter("C:/Users/Live/IdeaProjects/FileProgState.txt");

            String s = p.TextBoxPrint();
            writer.Write(s);

            //writer.WriteLine("Stack");
            //for (int i = p.exeStack.GetLength() - 1; i >= 0; i--)
            //{
            //    writer.Write(((IStmt)p.exeStack.Get(i)).ToStr());
            //    writer.WriteLine();
            //}
            //writer.WriteLine();

            //writer.Write(" state id: ");
            //writer.WriteLine(p.id);
            //writer.WriteLine(" List");
            //for (int i = 0; i < p.output.Size(); i++)
            //{
            //    writer.Write(p.output.Get(i));
            //    writer.WriteLine();
            //}
            //writer.WriteLine();

            //writer.WriteLine("Dictionary");
            //for (int i = 0; i < p.symTable.GetLength(); i++)
            //{
            //    writer.Write((p.symTable.Get(i)).ToStr());
            //    writer.WriteLine();
            //}

            //writer.WriteLine("Heap");
            //for (int i = 0; i < p.GetHeap().Size(); i++)
            //{
            //    writer.Write((p.GetHeap().Gett(i)).ToStr());
            //    writer.WriteLine();
            //}



            writer.Close();
        }
    }
}
