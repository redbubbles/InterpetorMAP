using InterpretorMap.Domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpetorMAP.Domain.ProgramState
{
    [Serializable]
    public class Proc
    {

        public String Name;
        public List<String> VarList;
        public IStmt Statement;

        /**constructor */
        public Proc(String name, List<String> varList, IStmt stmt )
        {
            Name = name;
            VarList = varList;
            Statement = stmt;

        }

        public String GetProcName()
        {
            return Name;
        }

        public List<String> GetVarNames()
        {
            return VarList;
        }

        public IStmt GetStmtName()
        {
            return Statement;
        }

        public String ToStr()
        {
            string s = "Proc(Name: " + Name + "Variables: ";
            foreach (String x in VarList)
                s = s + x + " ,";
            s = s + "Statement: " + Statement;
            return  s;
        }
    }
}
