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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button5.Visible = false;
            button6.Visible = false;
            button1.Click += button1_Click;
            button5.Click += button1_Click;
            button6.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Game.PlayerAmount = 1;
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Game.PlayerAmount = 2;
            form2.Show();
        }
    }
}
