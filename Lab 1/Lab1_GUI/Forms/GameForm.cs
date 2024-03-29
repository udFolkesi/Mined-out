﻿using Lab_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public partial class GameForm : Form
    {
        int x = 0;
        int y = 0;
        private Field field = new Field();
        private Game game = new Game();

        public GameForm()
        {
            Game.GameStopped = false;
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            
            field.Fill(ref Field.first.Matrix);
            PrintField(ref Field.first.Matrix, labelPlayer1);
            game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix, labelPlayer1);
            if (Game.PlayerAmount == 2)
            {
                field.Fill(ref Field.second.Matrix);
                PrintField(ref Field.second.Matrix, labelPlayer2);
                game.Check(Player.second.PosLeft, Player.second.PosTop, ref Field.second.Matrix, labelPlayer2);
            }

            Game.GameStopped = false;
            //game.Timer(timeNumbers_label);
        }

        public void PrintField(ref Element[,] matrix, Label labelPlayer)
        {
            Field.MiddleOfField = Convert.ToInt32(Math.Floor(Field.MatrixLength / 2d) - 1);

            for (int i = 0; i < Field.MatrixWidth; i++)
            {
                for (int j = 0; j < Field.MatrixLength; j++)
                {
                    if (j == 0)
                    {
                        x = 0;
                    }

                    if (matrix[i, j].GetType() == typeof(Player))
                    {
                        PrintElem(new PassedCell().Path, x, y);
                        labelPlayer.Location = new Point(x + 1, y + 1);
                        this.Controls.Add(labelPlayer);
                        labelPlayer.BringToFront();
                    }
                    else
                    {
                        PrintElem(matrix[i, j].Path, x, y);
                    }

                    if (matrix[i, j].GetType() == typeof(Trap))
                    {
                        PrintElem(new Cell().Path, x, y);
                    }

                    x += Element.Length;
                }

                y += Element.Length;
            }

            y += Element.Length;
        }

        public void PressKey(
            object sender,
            KeyEventArgs e,
            Element[,] matrxi1,
            Element[,] matrix2,
            Player player1,
            Player player2)
        {

            if (e.KeyCode == Keys.Right && matrxi1[player1.PosTop, player1.PosLeft + 1].GetType() != typeof(Wall))
            {
                player1.PosLeft += 1;
            }

            if (e.KeyCode == Keys.Left && matrxi1[player1.PosTop, player1.PosLeft - 1].GetType() != typeof(Wall))
            {
                player1.PosLeft -= 1;
            }

            if (e.KeyCode == Keys.Up && matrxi1[player1.PosTop - 1, player1.PosLeft].GetType() != typeof(Wall))
            {
                
                player1.PosTop -= 1;
            }

            if (e.KeyCode == Keys.Down && matrxi1[player1.PosTop + 1, player1.PosLeft].GetType() != typeof(Wall))
            {
                player1.PosTop += 1;
            }

            game.MovePlayer(ref player1, ref matrxi1, life_label);
            PrintElem(new PassedCell().Path, player1.PosLeft * Element.Length, player1.PosTop * Element.Length);
            game.Check(player1.PosLeft, player1.PosTop, ref matrxi1, labelPlayer1);

            if(Game.PlayerAmount == 2)
            {
                if (e.KeyCode == Keys.D && matrix2[player2.PosTop, player2.PosLeft + 1].GetType() != typeof(Wall))
                {
                    player2.PosLeft += 1;
                }

                if (e.KeyCode == Keys.A && matrix2[player2.PosTop, player2.PosLeft - 1].GetType() != typeof(Wall))
                {
                    player2.PosLeft -= 1;
                }

                if (e.KeyCode == Keys.W && matrix2[player2.PosTop - 1, player2.PosLeft].GetType() != typeof(Wall))
                {
                    player2.PosTop -= 1;
                }

                if (e.KeyCode == Keys.S && matrix2[player2.PosTop + 1, player2.PosLeft].GetType() != typeof(Wall))
                {
                    player2.PosTop += 1;
                }

                game.MovePlayer(ref player2, ref matrxi1, life_label);
                PrintElem(new PassedCell().Path, player2.PosLeft * Element.Length, player2.PosTop * Element.Length);
                game.Check(player2.PosLeft, player2.PosTop, ref matrxi1, labelPlayer2);
            }

            labelPlayer1.Location = new Point(player1.PosLeft * Element.Length, player1.PosTop * Element.Length);
            labelPlayer1.BringToFront();
            if (Game.PlayerAmount == 2)
            {
                labelPlayer2.Location = new Point(player2.PosLeft * Element.Length, player2.PosTop * Element.Length);
            }

            if (Game.GameStopped == true)
            {
                PictureBox explosion = new PictureBox()
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Properties.Resources.explosion,
                    Size = new Size(Element.Length, Element.Length),
                    Location = new Point(player1.PosLeft * Element.Length, player1.PosTop * Element.Length),
                };
                this.Controls.Add(explosion);
                ShowTraps();
                explosion.BringToFront();
            }
        }

        public void PrintElem(string path, int x, int y) // класс в параметр 
        {
            PictureBox pictureBox = new PictureBox()
            {
                Image = Image.FromFile(path),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(Element.Length, Element.Length),
                Location = new Point(x, y),
            };

            if (path == new Trap().Path)
            {
                pictureBox.Tag = "trap";
            }

            this.Controls.Add(pictureBox);
            pictureBox.BringToFront();
        }

        public void ShowTraps()
        {
            foreach (var picture in this.Controls.OfType<PictureBox>())
            {
                if (picture.Tag == "trap")
                {
                    picture.BringToFront();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm form2 = new GameForm();
            form2.Show();
            Game.PlayerAmount = 1;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.GameStopped = true;
            this.Opacity = .98;
            this.Enabled = false;
            MessageBox.Show("PAUSE");
            this.Opacity = 1;
            this.Enabled = true;
            Game.GameStopped = false;
            game.Timer(timeNumbers_label);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.GameStopped = true;
        }
    }
}
