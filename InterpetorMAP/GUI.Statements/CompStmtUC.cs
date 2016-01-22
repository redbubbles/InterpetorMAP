using System;
using System.Windows.Forms;
using InterpretorMap.Domain.Statement;

namespace InterpetorMAP.GUI.Statements
{
    public partial class CompStmtUC : UserControl, IVisualStmt
    {
        public IVisualStmt First;
        public IVisualStmt Second;

        public CompStmtUC()
        {
            InitializeComponent();
            comboBox1.Items.Add("AssignStmt");
            comboBox1.Items.Add("CompStmt");
            comboBox1.Items.Add("PrintStmt");
            comboBox1.Items.Add("IfStmt");
            comboBox1.Items.Add("NewStmt");
            comboBox1.Items.Add("WhileStmt");
            comboBox1.Items.Add("ForkStmt");
            comboBox1.Items.Add("SkipStmt");

            comboBox2.Items.Add("AssignStmt");
            comboBox2.Items.Add("CompStmt");
            comboBox2.Items.Add("PrintStmt");
            comboBox2.Items.Add("IfStmt");
            comboBox2.Items.Add("NewStmt");
            comboBox2.Items.Add("WHStmt");
            comboBox2.Items.Add("ForkStmt");
            comboBox2.Items.Add("SkipStmt");
        }

        public IStmt Statement { get; set; }
        public IVisualStmt ParentStatement { get; set; }

        public void FinalizeStatement()
        {
            Statement = new CompStmt(First.Statement, Second.Statement);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Width += 10;
            panel1.Width += 10;
            Height += Heights.Get(comboBox1.SelectedItem.ToString());

            string s = (comboBox1.SelectedItem.ToString());

            switch (s)
            {
                case "AssignStmt":
                    First = new AssignStmtUC();
                    break;

                case "CompStmt":
                    First = new CompStmtUC();
                    break;

                case "PrintStmt":
                    First = new PrintStmtUC();
                    break;

                case "NewStmt":
                    First = new NewStmtUC();
                    break;

                case "IfStmt":
                   First = new IfStmtUC();
                    break;

                case "WhileStmt":
                    First = new WhileStmtUC();
                    break;

                case "WHStmt":
                    First = new WHUC();
                    break;

                case "ForkStmt":
                    First = new ForkUC();
                    break;

                case "SkipStmt":
                    First =  new SkipStmtUC();
                    break;
                
            }
          
            panel1.Controls.Add((Control) First);
            ((Control)First).Left = 10;
            ((Control)First).Top = 50;
            
             comboBox1.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Width += 10;
            panel2.Width += 10;
            Height += Heights.Get(comboBox2.SelectedItem.ToString());
            string s = (comboBox2.SelectedItem.ToString());

            switch (s)
            {
                case "AssignStmt":
                    Second = new AssignStmtUC();
                    break;

                case "CompStmt":
                    Second = new CompStmtUC();
                    break;

                case "PrintStmt":
                    Second = new PrintStmtUC();
                    break;

                case "NewStmt":
                    Second = new NewStmtUC();
                    break;

                case "IfStmt":
                    Second = new IfStmtUC();
                    break;

                case "WhileStmt":
                    Second = new WhileStmtUC();
                    break;

                case "WHStmt":
                    Second = new WHUC();
                    break;

                case "ForkStmt":
                    Second = new ForkUC();
                    break;

                case "SkipStmt":
                    Second = new SkipStmtUC();
                    break;
            }
             panel2.Controls.Add((Control) Second);
             ((Control)Second).Left = 10;
             ((Control)Second).Top = 50;
            
            comboBox2.Enabled = false;
        }

        private void btnEvaluateStmt1_Click(object sender, EventArgs e)
        {
            FinalizeStatement();
            textBox1.Text = Statement.ToStr();
        }

        private void CompStmtUC_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}