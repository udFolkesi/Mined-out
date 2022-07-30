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
            ChangeMenuColor();
            player1_bttn.Visible = false;
            player2_bttn.Visible = false;
            startGame_bttn.Click += button1_Click;
            player1_bttn.Click += button1_Click;
            player2_bttn.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startGame_bttn.Visible = false;
            player1_bttn.Visible = true;
            player2_bttn.Visible = true;
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
            // сделать что-то перед выходом, что-то сохранить и тп
            Application.Exit();
        }

        private async Task ChangeMenuColor()
        {
            await Task.Run(() =>
            {
                var rnd = new Random();
                while (true)
                {
                    MenuLabel.ForeColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    Thread.Sleep(500);
                }
            });
        }
    }
}
