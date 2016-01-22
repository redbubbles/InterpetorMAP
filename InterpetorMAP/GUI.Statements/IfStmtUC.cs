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
using InterpretorMap.Statement;
using InterpetorMAP.GUI.Expressions;

namespace InterpetorMAP.GUI.Statements
{
    public partial class IfStmtUC : UserControl, IVisualStmt
    {

        public IVisualExp Exp;
        public IVisualStmt Then;
        public IVisualStmt Else;


        public IfStmtUC()
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

            comboBox3.Items.Add("AssignStmt");
            comboBox3.Items.Add("CompStmt");
            comboBox3.Items.Add("PrintStmt");
            comboBox3.Items.Add("NewStmt");
            comboBox3.Items.Add("IfStmt");
            comboBox3.Items.Add("SkipStmt");
        }

        public IStmt Statement { get; set; }
        public IVisualStmt ParentStatement { get; set; }

        public void FinalizeStatement()
        {
            Statement = new IfStmt(Exp.GetExp(), Then.Statement, Else.Statement);
        }


        private void IfStmtUC_Load(object sender, EventArgs e)
        {

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
            ((Control)Exp).Top = 60;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Width += 10;
            Height += Heights.Get(comboBox2.SelectedItem.ToString());
            string s = (comboBox2.SelectedItem.ToString());

            switch (s)
            {
                case "AssignStmt":
                    Then = new AssignStmtUC();
                    break;

                case "CompStmt":
                    Then = new CompStmtUC();
                    break;

                case "PrintStmt":
                    Then = new PrintStmtUC();
                    break;

                case "NewStmt":
                    Then = new NewStmtUC();
                    break;

                case "IfStmt":
                    Then = new IfStmtUC();
                    break;

               

            }
            comboBox2.Enabled = false;
            this.Controls.Add((Control)Then);
            ((Control)Then).Left = 10;
            ((Control)Then).Top = 60 + 190;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Width += 10;
            Height += Heights.Get(comboBox3.SelectedItem.ToString()) + 140;
            string s = (comboBox3.SelectedItem.ToString());

            switch (s)
            {
                case "AssignStmt":
                    Else = new AssignStmtUC();
                    break;

                case "CompStmt":
                    Else = new CompStmtUC();
                    break;

                case "PrintStmt":
                    Else = new PrintStmtUC();
                    break;

                case "NewStmt":
                    Else = new NewStmtUC();
                    break;

                case "IfStmt":
                    Else = new IfStmtUC();
                    break;

                case "SkipStmt":
                    Else = new SkipStmtUC();
                    break;
            }
            comboBox3.Enabled = false;
            this.Controls.Add((Control)Else);
            ((Control)Else).Left = 10;
            ((Control)Else).Top = 60 + 450;

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
