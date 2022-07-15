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
            label1.Text = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogForm form3 = new DialogForm();
            form3.Show();
        }
    }
}
