using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public partial class DialogForm : Form
    {
        private List<Form> openForms = new List<Form>();
        public DialogForm()
        {
            InitializeComponent();
            foreach (Form form in Application.OpenForms)
            {
                openForms.Add(form);
            }
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (Form form in openForms)
            {
                if (form.Name != "MenuForm")
                {
                    form.Hide();
                }
            }

            GameForm gameForm = new GameForm();
            gameForm.Show();
            Game.GameStopped = false;
            Game.PlayerAmount = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResultForm resultForm = new ResultForm();
            resultForm.NameResult("Game over");
            resultForm.Show();
            Game.GameStopped = true;
            foreach (Form form in openForms)
            {
                if (form.Name == "MenuForm")
                {
                    form.Close();
                }
            }
        }
    }
}
