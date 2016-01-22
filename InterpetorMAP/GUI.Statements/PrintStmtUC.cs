using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterpretorMap.Domain.Statement;
using InterpetorMAP.GUI.Expressions;

namespace InterpetorMAP.GUI.Statements
{
    public partial class PrintStmtUC : UserControl, IVisualStmt
    {
        public IVisualExp Exp;

        public PrintStmtUC()
        {
            InitializeComponent();
            comboBox1.Items.Add("ConstExp");
            comboBox1.Items.Add("ArithExp");
            comboBox1.Items.Add("LogicalOp");
            comboBox1.Items.Add("VarExp");
            comboBox1.Items.Add("RelationalOp");
            comboBox1.Items.Add("rH");
        }

        public IStmt Statement { get; set; }
        public IVisualStmt ParentStatement { get; set; }

        public void FinalizeStatement()
        {
            Statement = new PrintStmt(Exp.GetExp());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            Width += 10;
            Height += Heights.Get(comboBox1.SelectedItem.ToString());

            string s = comboBox1.SelectedItem.ToString();

            switch (s)
            {
                case "ConstExp":
                    Exp = new ConstExpUC();
                    break;

                case "ArithExp":
                    Exp = new ArithExpUC();
                    break;

                case "LogicalOp":
                    Exp = new LogicalOpUC();
                    break;

                case "VarExp":
                    Exp = new VarExpUC();
                    break;

                case "RelationalOp":
                    Exp = new RelationalOpUC();
                    break;

                case "rH":
                    Exp = new rHUC();
                    break;

            }
            this.Controls.Add((Control)Exp);
            ((Control)Exp).Left = 10;
            ((Control)Exp).Top = 30;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEvaluateStmt1_Click(object sender, EventArgs e)
        {
            FinalizeStatement();
            textBox1.Text = Statement.ToStr();
        }
    }
}
