using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        public void NameResult(string result)
        {
            if (result == "Easy win")
            {
                label1.ForeColor = Color.GreenYellow;
            }
            else
            {
                label1.ForeColor = Color.Red;
            }

            label1.Text = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogForm form3 = new DialogForm();
            form3.Show();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }
    }
}
