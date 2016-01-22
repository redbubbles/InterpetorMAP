using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterpetorMAP.GUI.Statements;
using InterpretorMap.Domain.Expression;

namespace InterpetorMAP.GUI.Expressions
{
    public partial class ArithExpUC : UserControl, IVisualExp
    {

        public IVisualExp Exp1;
        public IVisualExp Exp2;
        public string Operation;
        public int H { get; set; }

        public ArithExpUC()
        {
            H = 0;
            InitializeComponent();
            comboBox1.Items.Add("ConstExp");
            comboBox1.Items.Add("ArithExp");
            comboBox1.Items.Add("LogicalOp");
            comboBox1.Items.Add("VarExp");
            comboBox1.Items.Add("RelationalOp");
            comboBox1.Items.Add("rH");


            comboBox2.Items.Add("ConstExp");
            comboBox2.Items.Add("ArithExp");
            comboBox2.Items.Add("LogicalOp");
            comboBox2.Items.Add("VarExp");
            comboBox2.Items.Add("RelationalOp");
            comboBox2.Items.Add("rH");
            ;
        }

        public ArithExp Exp;
        public int Eval { get; set; }
        public IVisualStmt ParentStatement { get; set; }

        public Exp GetExp()
        {
            return Exp;
        }
        
        private void ArithExpUC_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Width += 10;
            Height += Heights.Get(comboBox1.SelectedItem.ToString());
            string s = comboBox1.SelectedItem.ToString();
            H = H + Heights.Get(s);
            switch (s)
            {
                case "ConstExp":
                    Exp1 = new ConstExpUC();
                    break;

                case "ArithExp":
                    Exp1 = new ArithExpUC();;
                    break;
      
                case "LogicalOp":
                    Exp1 = new LogicalOpUC();
                    break;

                case "VarExp":
                    Exp1 = new VarExpUC();
                    break;

                case "RelationalOp":
                    Exp1 = new RelationalOpUC();
                    break;

                case "rH":
                    Exp1 = new rHUC();
                    break;

            }
            comboBox1.Enabled = false;
            this.Controls.Add((Control)Exp1);
            ((Control)Exp1).Left = 10;
            ((Control)Exp1).Top = 60;
        }
        
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        { 
            Width += 10;
            Height += Heights.Get(comboBox2.SelectedItem.ToString()) + Exp1.H;
            string s = comboBox2.SelectedItem.ToString();
            H = H + Heights.Get(s);
            switch (s)
            {
                case "ConstExp":
                    Exp2 = new ConstExpUC();
                    break;

                case "ArithExp":
                    Exp2 = new ArithExpUC();
                    break;

                case "LogicalOp":
                    Exp2 = new LogicalOpUC();
                    break;

                case "VarExp":
                    Exp2 = new VarExpUC();
                    break;

                case "RelationalOp":
                    Exp2 = new RelationalOpUC();
                    break;

                case "rH":
                    Exp2 = new rHUC();
                    break;

            }
            this.Controls.Add((Control)Exp2);
            ((Control)Exp2).Left = 10;
            ((Control)Exp2).Top = 70 + Heights.Get(comboBox1.SelectedItem.ToString()) + Exp1.H;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char s = Convert.ToChar(textBox2.Text);
            switch (s)
            {
                case '+':
                    Exp = new ArithExp(Exp1.GetExp(), Exp2.GetExp(), 1);
                    break;
                case '-':
                    Exp = new ArithExp(Exp1.GetExp(), Exp2.GetExp(), 2);
                    break;
                case '*':
                    Exp = new ArithExp(Exp1.GetExp(), Exp2.GetExp(), 3);
                    break;
                case '/':
                    Exp = new ArithExp(Exp1.GetExp(), Exp2.GetExp(), 4);
                    break;
                default:
                    Exp = new ArithExp(Exp1.GetExp(), Exp2.GetExp(), 1);
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
