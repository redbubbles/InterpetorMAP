using InterpetorMAP.GUI.Statements;
using InterpretorMap.Domain.Expression;

namespace InterpetorMAP
{
    public interface IVisualExp
    {
        int Eval { get; set; }
        IVisualStmt ParentStatement { get; set; }
        Exp GetExp();
        int H { get; set; }
    }
}