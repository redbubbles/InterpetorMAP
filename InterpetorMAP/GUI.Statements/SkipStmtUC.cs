using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterpetorMAP.Domain.Statement;
using InterpretorMap.Domain.Statement;

namespace InterpetorMAP.GUI.Statements
{
    public partial class SkipStmtUC : UserControl, IVisualStmt
    {
        public SkipStmtUC()
        {
            InitializeComponent();
        }

        public IStmt Statement { get; set; }
        public IVisualStmt ParentStatement { get; set; }

        public void FinalizeStatement()
        {
            Statement = new SkipStmt();
        }

        private void btnEvaluateStmt1_Click(object sender, EventArgs e)
        {
            FinalizeStatement();
            textBox1.Text = "skiped";
        }
    }
}
