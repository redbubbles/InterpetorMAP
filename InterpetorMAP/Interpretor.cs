using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterpetorMAP.GUI.Statements;
using InterpretorMap.Domain.Statement;
using InterpretorMap.Domain.ProgramState;
using InterpretorMap.Repository;
using InterpretorMap.Controller;
using InterpretorMap.Statement;

namespace InterpetorMAP
{
    public partial class Interpretor : Form
    {

       

        public Interpretor()
        {
            InitializeComponent();
            comboBox1.Items.Add("CompStmt");
            comboBox1.Items.Add("AssignStmt");
            comboBox1.Items.Add("PrintStmt");
            comboBox1.Items.Add("NewStmt");
            comboBox1.Items.Add("IfStmt");
            comboBox1.Items.Add("WhileStmt");
            comboBox1.Items.Add("WHStmt");
            comboBox1.Items.Add("ForkStmt");
            comboBox1.Items.Add("SkipStmt");
            
        }



        private void Interpretor_Load(object sender, EventArgs e)
        {

        }

        public IStmt Statement { get; set; }
        public IVisualStmt VisualStatement { get; set; }

        public MyIRepo repo;
        public Ctrl cont;
        private string s = "";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Width += 10;           
            Height += Heights.Get(comboBox1.SelectedItem.ToString());
            string s = comboBox1.SelectedItem.ToString();
            switch (s) 
            {
                case "CompStmt":
                    VisualStatement = new CompStmtUC();
                    break;

                case "AssignStmt":
                    VisualStatement = new AssignStmtUC();
                    break;

                case "PrintStmt":
                    VisualStatement = new PrintStmtUC();
                    break;

                case "NewStmt":
                    VisualStatement = new NewStmtUC();
                    break;

                case "IfStmt":
                    VisualStatement = new IfStmtUC();
                    break;

                case "WhileStmt":
                    VisualStatement = new WhileStmtUC();
                    break;

                case "WHStmt":
                    VisualStatement = new WHUC();
                    break;

                case "ForkStmt":
                    VisualStatement = new ForkUC();
                    break;

                case "SkipStmt":
                    VisualStatement = new SkipStmtUC();
                    break;
            }
            comboBox1.Enabled = false;
            Controls.Add((Control)VisualStatement);
            ((Control)VisualStatement).Left = 10;
            ((Control)VisualStatement).Top = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VisualStatement.FinalizeStatement();
            textBox1.Text = VisualStatement.Statement.ToStr();
            repo = new Repo(VisualStatement.Statement);
            cont = new Ctrl(repo);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            s = s + cont.OneStepForAllPrg();
            richTextBox1.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = cont.AllStep();
            richTextBox1.Text = s;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrgState prog = repo.GetCrtPrg();
            repo.SerializeProgState(prog);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            PrgState prog = repo.DeserializeProgState();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrgState prog = repo.GetCrtPrg();
            repo.ProgStateFile(prog);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
   
}
