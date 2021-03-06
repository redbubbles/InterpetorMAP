﻿using System;
using System.Windows.Forms;
using InterpetorMAP.GUI.Expressions;
using InterpretorMap.Domain.Expression;
using InterpretorMap.Domain.Statement;

namespace InterpetorMAP.GUI.Statements
{
    public partial class AssignStmtUC : UserControl, IVisualStmt
    {
        public IVisualExp Exp;
        public string Id;

        public AssignStmtUC()
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
            Statement = new AssignStmt(Id, Exp.GetExp());
        }

        private void btnEvaluateStmt1_Click(object sender, EventArgs e)
        {
            FinalizeStatement();
            textBox1.Text = Statement.ToStr();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Id = textBox2.Text;
        }

        private void AssignStmtUC_Load(object sender, EventArgs e)
        {

        }
    }
}