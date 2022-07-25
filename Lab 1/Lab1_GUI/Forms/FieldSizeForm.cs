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
    public partial class FieldSizeForm : Form
    {
        public FieldSizeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Field.MatrixWidth = int.Parse(textBox1.Text);
            Field.MatrixLength = int.Parse(textBox2.Text);
            Close();
        }
    }
}
