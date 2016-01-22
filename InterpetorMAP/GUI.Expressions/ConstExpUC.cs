using System;
using System.Windows.Forms;
using InterpetorMAP.GUI.Statements;
using InterpretorMap.Domain.Expression;

namespace InterpetorMAP.GUI.Expressions
{
    public partial class ConstExpUC : UserControl, IVisualExp
    {

        public int H { get; set; }

        public ConstExpUC()
        {
            InitializeComponent();
            H = 0;
        }

        public ConstExp Exp;
        public int Eval { get; set; }
        public IVisualStmt ParentStatement { get; set; }
        

        public Exp GetExp()
        {
            return Exp;
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBox1.Text, out value))
            {
                Eval = value;
                Exp = new ConstExp(value);
               
            }                
        }
    }
}