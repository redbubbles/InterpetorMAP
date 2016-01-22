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
    public partial class WhileStmtUC : UserControl, IVisualStmt
    {
        public IVisualExp Exp;
        public IVisualStmt Stmt;


        public WhileStmtUC()
        {
            InitializeComponent();
            comboBox1.Items.Add("ConstExp");
            comboBox1.Items.Add("ArithExp");
            comboBox1.Items.Add("LogicalOp");
            comboBox1.Items.Add("VarExp");
            comboBox1.Items.Add("RelationalOp");
            comboBox1.Items.Add("rH");

            comboBox2.Items.Add("AssignStmt");
            comboBox2.Items.Add("CompStmt");
            comboBox2.Items.Add("PrintStmt");
            comboBox2.Items.Add("NewStmt");
            comboBox2.Items.Add("IfStmt");

        }

        public IStmt Statement { get; set; }
        public IVisualStmt ParentStatement { get; set; }

        public void FinalizeStatement()
        {
            Statement = new WhileStmt(Exp.GetExp(), Stmt.Statement);
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

            comboBox1.Enabled = false;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Width += 10;
            Height += Heights.Get(comboBox2.SelectedItem.ToString());
            string s = (comboBox2.SelectedItem.ToString());

            switch (s)
            {
                case "AssignStmt":
                    Stmt = new AssignStmtUC();
                    break;

                case "CompStmt":
                    Stmt = new CompStmtUC();
                    break;

                case "PrintStmt":
                    Stmt = new PrintStmtUC();
                    break;

                case "NewStmt":
                    Stmt = new NewStmtUC();
                    break;

                case "IfStmt":
                    Stmt = new IfStmtUC();
                    break;
            }
            comboBox2.Enabled = false;
            this.Controls.Add((Control)Stmt);
            ((Control)Stmt).Left = 10;
            ((Control)Stmt).Top = 60 + 190;

        }
    }
}
