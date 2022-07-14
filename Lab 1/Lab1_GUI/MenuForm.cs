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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            WordMenu();
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
            Game.PlayerAmount = 1;
            GameForm form2 = new GameForm();
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Game.PlayerAmount = 2;
            GameForm form2 = new GameForm();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Files files = new Files();
            files.GetInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FieldSizeForm fieldSizeForm = new FieldSizeForm();
            fieldSizeForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async Task WordMenu()
        {
            await Task.Run(() =>
            {
                var rnd = new Random();
                Thread.Sleep(10);
                while (true)
                {
                    //MenuLabel.Text = "   ";
                    //Thread.Sleep(500);
                    //MenuLabel.Text = "Menu";
                    MenuLabel.ForeColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    Thread.Sleep(500);
                }
            });
        }
    }
}
