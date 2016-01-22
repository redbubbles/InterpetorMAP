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

namespace InterpetorMAP.GUI.Statements
{
    public partial class ForkUC : UserControl, IVisualStmt
    {
        public IVisualStmt Fork;
        public ForkUC()
        {
            InitializeComponent();
            comboBox1.Items.Add("AssignStmt");
            comboBox1.Items.Add("CompStmt");
            comboBox1.Items.Add("PrintStmt");
            comboBox1.Items.Add("NewStmt");
            comboBox1.Items.Add("WhileStmt");
            comboBox1.Items.Add("WHStmt");
        }

        public IStmt Statement { get; set; }
        public IVisualStmt ParentStatement { get; set; }

        public void FinalizeStatement()
        {
            Statement = new ForkStmt(Fork.Statement);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Width += 10;
            Height += Heights.Get(comboBox1.SelectedItem.ToString());

            string s = (comboBox1.SelectedItem.ToString());

            switch (s)
            {
                case "AssignStmt":
                    Fork = new AssignStmtUC();
                    break;

                case "CompStmt":
                    Fork = new CompStmtUC();
                    break;

                case "PrintStmt":
                    Fork = new PrintStmtUC();
                    break;

                case "NewStmt":
                    Fork = new NewStmtUC();
                    break;

                case "IfStmt":
                    Fork = new IfStmtUC();
                    break;

                case "WhileStmt":
                    Fork = new WhileStmtUC();
                    break;

                case "WHStmt":
                    Fork = new WHUC();
                    break;

            }
            comboBox1.Enabled = false;
            this.Controls.Add((Control)Fork);
            ((Control)Fork).Left = 10;
            ((Control)Fork).Top = 30;
        }

        private void btnEvaluateStmt1_Click(object sender, EventArgs e)
        {
            FinalizeStatement();
            textBox1.Text = Statement.ToStr();
        }
    }
}
