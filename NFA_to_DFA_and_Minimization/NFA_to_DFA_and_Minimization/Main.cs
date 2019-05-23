using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NFA_to_DFA_and_Minimization
{
    public partial class Main : Form
    {
        public Main()
        {
            Icon icon = Icon.ExtractAssociatedIcon(@"Logo.ico");
            this.Icon = icon;
            InitializeComponent();
        }

        NFA NFA;
        DFA DFA;
        DFA MinDFA;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void optimizedSOPLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void NFAPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenerateNFA_Click(object sender, EventArgs e)
        {
            NFA = null;
            try
            {
                NFA = new NFA(NFAPath.Text);
                MessageBox.Show("Your Input Text Parsed and NFA Generated Successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateDFA_Click(object sender, EventArgs e)
        {
            try
            {
                if (NFA != null)
                {
                    DFA = new DFA(NFA);
                    DFA.ToTxtFile(DFAPath.Text);
                    DialogResult result = MessageBox.Show("NFA Parsed and DFA Generated Successfully\nDo You Want To Open It?", "Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Process.Start(DFAPath.Text);
                }
                else
                    MessageBox.Show("You Need to Load NFA First", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MinimizeDFA_Click(object sender, EventArgs e)
        {
            try
            {
                if (DFA != null)
                {
                    MinDFA = DFA.Minimizer(DFA);
                    MinDFA.ToTxtFile(MinimizedDFAPath.Text);
                    DialogResult result = MessageBox.Show("DFA Minimized Successfully\nDo You Want To Open It?", "Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Process.Start(MinimizedDFAPath.Text);
                }
                else
                    MessageBox.Show("You Need to Generate DFA First", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DFAPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void MinimizedDFAPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
