using Lab_1;
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
        Field field = new Field();
        Game game = new Game();

        public GameForm()
        {
            InitializeComponent();
            Player.first.PosLeft = Field.MiddleOfField + 1;
            Player.first.PosTop = Field.MatrixWidth - 1;
            Player.second.PosLeft = Player.first.PosLeft;
            Player.second.PosTop = Player.first.PosTop;
            field.Define(ref Field.first.Matrix);
            PrintField(ref Field.first.Matrix, labelPlayer1);
            if (Game.PlayerAmount == 2)
            {
                field.Define(ref Field.second.Matrix);
                PrintField(ref Field.second.Matrix, labelPlayer2);
            }

            labelPlayer1.BringToFront();
            game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            KeyDown += new KeyEventHandler(Form2_KeyDown);
            Game.gameStopped = false;
            game.Timer(label1);
        }
        

        public static Label labelPlayer1 = new Label
        {
            Size = new Size(15, 15),
            Font = new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold),
            Text = Game.TrapAmount.ToString(),
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.Black
        };

        public static Label labelPlayer2 = new Label()
        {
            Size = labelPlayer1.Size,
            Font = labelPlayer1.Font,
            Text = labelPlayer1.Text,
            TextAlign = labelPlayer1.TextAlign,
            BackColor = labelPlayer1.BackColor
        };

        public void PrintField(ref Element[,] Matrix, Label labelPlayer)
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

                    if (Matrix[i, j].GetType() == typeof(Trap))
                    {
                        
                        PrintElem(typeof(Trap), x, y);
                        PrintElem(typeof(Cell), x, y);
                    }

                    if (Matrix[i, j].GetType() == typeof(WallBorder))
                    {
                        PrintElem(typeof(WallBorder), x, y);
                    }

                    if (Matrix[i, j].GetType() == typeof(Wall))
                    {
                        PrintElem(typeof(Wall), x, y);
                    }

                    if (Matrix[i, j].GetType() == typeof(Bonus))
                    {
                        PrintElem(typeof(Bonus), x, y);
                    }

                    if (Matrix[i, j].GetType() == typeof(Cell))
                    {
                        PrintElem(typeof(Cell), x, y);
                    }

                    if (Matrix[i, j].GetType() == typeof(Player))
                    {
                        PrintElem(typeof(PassedCell), x, y);
                        labelPlayer.Location = new Point(x + 1, y + 1);
                        this.Controls.Add(labelPlayer);
                    }

                    x += 15;
                }

                y += 15;
            }
            y += 15;
        }

        public void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            Player.first.labelX = labelPlayer1.Location.X;
            Player.first.labelY = labelPlayer1.Location.Y;
            Player.second.labelX = labelPlayer2.Location.X;
            Player.second.labelY = labelPlayer2.Location.Y;

            if (e.KeyCode == Keys.Right && Field.first.Matrix[Player.first.PosTop, Player.first.PosLeft + 1].GetType() != typeof(Wall))
            {
                Player.first.PosLeft += 1;
                Player.first.labelX += 15;
                game.MovePlayer(ref Player.first.PosLeft, ref Player.first.PosTop, ref Field.first.Matrix, label3);
                PrintElem(typeof(PassedCell), Player.first.labelX, Player.first.labelY);
                game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            }
                
            if (e.KeyCode == Keys.Left && Field.first.Matrix[Player.first.PosTop, Player.first.PosLeft - 1].GetType() != typeof(Wall))
            {
                Player.first.PosLeft -= 1;
                Player.first.labelX -= 15;
                game.MovePlayer(ref Player.first.PosLeft, ref Player.first.PosTop, ref Field.first.Matrix, label3);
                PrintElem(typeof(PassedCell), Player.first.labelX, Player.first.labelY);
                game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            }
                
            if (e.KeyCode == Keys.Up && Field.first.Matrix[Player.first.PosTop - 1, Player.first.PosLeft].GetType() != typeof(Wall))
            {
                Player.first.PosTop -= 1;
                Player.first.labelY -= 15;
                game.MovePlayer(ref Player.first.PosLeft, ref Player.first.PosTop, ref Field.first.Matrix, label3);
                PrintElem(typeof(PassedCell), Player.first.labelX, Player.first.labelY);
                game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            }
                
            if (e.KeyCode == Keys.Down && Field.first.Matrix[Player.first.PosTop + 1, Player.first.PosLeft].GetType() != typeof(Wall))
            {
                Player.first.PosTop += 1;
                Player.first.labelY += 15;
                game.MovePlayer(ref Player.first.PosLeft, ref Player.first.PosTop, ref Field.first.Matrix, label3);
                PrintElem(typeof(PassedCell), Player.first.labelX, Player.first.labelY);
                game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);

            }

            if(Game.gameStopped == true)
            {
                ShowTraps();
            }
                
            labelPlayer1.Location = new Point(Player.first.labelX, Player.first.labelY);
            labelPlayer1.BringToFront();
            if(Game.PlayerAmount == 2)
            {
                labelPlayer2.Location = new Point(Player.second.labelX, Player.second.labelY);
                labelPlayer2.BringToFront();
            }
        }

        public void PrintElem(Type type, int x, int y) // класс в параметр !!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            PictureBox pictureBox = new PictureBox();

            if (type == typeof(WallBorder))
            {
                pictureBox.Image = Image.FromFile(WallBorder.path);
            }

            if (type == typeof(Cell))
            {
                pictureBox.Image = Image.FromFile(Cell.path);
            }

            if (type == typeof(Bonus))
            {
                pictureBox.Image = Image.FromFile(Bonus.path);
            }

            if (type == typeof(Trap))
            {
                pictureBox.Name = "trap";
                pictureBox.Image = Image.FromFile(Trap.path);
            }

            if (type == typeof(Wall))
            {
                pictureBox.Image = Image.FromFile(Wall.path);
            }

            if (type == typeof(PassedCell))
            {
                pictureBox.Image = Image.FromFile(PassedCell.path);
            }

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if(type == typeof(PassedCell))
            {
                pictureBox.Size = new Size(15, 15);
            }
            else
            {
                pictureBox.Size = new Size(15, 15);
            }
            
            pictureBox.Location = new Point(x, y);
            this.Controls.Add(pictureBox);
            pictureBox.BringToFront();
        }

        public void ShowTraps()
        {
            foreach (var picture in this.Controls.OfType<PictureBox>())
            {
                if(picture.Name == "trap")
                {
                    picture.BringToFront();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm form2 = new GameForm();
            form2.Show();
            Game.PlayerAmount = 1;
        }
    }
}
