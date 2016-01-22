using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterpretorMap.Domain.Expression;
using InterpetorMAP.GUI.Statements;

namespace InterpetorMAP.GUI.Expressions
{
    public partial class rHUC : UserControl, IVisualExp
    {
        public int H { get; set; }
        public Exp Exp;
        public int Eval { get; set; }
        public IVisualStmt ParentStatement { get; set; }

        public Exp GetExp()
        {
            return Exp;
        }

        public rHUC()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            Exp = new rHExp(s);

        }
    }
}
