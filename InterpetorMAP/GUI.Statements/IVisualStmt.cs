using System.Windows.Forms;
using InterpretorMap.Domain.Statement;

namespace InterpetorMAP.GUI.Statements
{
    public interface IVisualStmt
    {
        IStmt Statement { get; set; }
        IVisualStmt ParentStatement { get; set; }
        void FinalizeStatement();
    }
}