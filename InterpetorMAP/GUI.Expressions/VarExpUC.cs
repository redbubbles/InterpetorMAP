using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterpetorMAP.GUI.Statements;
using InterpretorMap.Domain.Expression;

namespace InterpetorMAP.GUI.Expressions
{
    public partial class VarExpUC : UserControl,IVisualExp
    {
        public int H { get; set; }

        public VarExpUC()
        {
            InitializeComponent();
        }

        public Exp Exp;
        public int Eval { get; set; }
        public IVisualStmt ParentStatement { get; set; }


        public Exp GetExp()
        {
            return Exp;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            Exp = new rHExp(s);
        }
    }
}
