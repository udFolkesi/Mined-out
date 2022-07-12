using Lab_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public partial class Form2 : Form
    {
        int x = 0;
        int y = 0;
        Field field = new Field();
        Game game = new Game();

        public Form2()
        {
            InitializeComponent();
            field.Define(ref Field.first.Matrix);
            PrintField(ref Field.first.Matrix);
            textBox1.TabStop = false;
            labelPlayer.BringToFront();
            game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            KeyDown += new KeyEventHandler(Form2_KeyDown);
            game.Timer();
            //game.Timer();
        }
        

        public static Label labelPlayer = new Label
        {
            Size = new Size(15, 15),
            Font = new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold),
            Text = Game.TrapAmount.ToString(),
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.Black
        };

        public void PrintField(ref Element[,] Matrix)
        {
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
                        if(Game.gameStopped == false)
                        {
                            PrintElem(typeof(Cell), x, y);
                        }
                        else
                        {
                            PrintElem(typeof(Trap), x, y);
                        }
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
                        //PrintElem(typeof(Player));
                    }

                    x += 15;
                }

                y += 15;
            }
        }

        public void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            Player.first.labelX = labelPlayer.Location.X;
            Player.first.labelY = labelPlayer.Location.Y;

            if (e.KeyCode == Keys.Right && Field.first.Matrix[Player.first.PosTop, Player.first.PosLeft + 1].GetType() != typeof(Wall))
            {
                Player.first.PosLeft += 1;
                Player.first.labelX += 15;
                game.MovePlayer(ref Player.first.PosLeft, ref Player.first.PosTop, ref Field.first.Matrix);
                PrintElem(typeof(PassedCell), Player.first.labelX, Player.first.labelY);
                game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            }
                
            if (e.KeyCode == Keys.Left && Field.first.Matrix[Player.first.PosTop, Player.first.PosLeft - 1].GetType() != typeof(Wall))
            {
                Player.first.PosLeft -= 1;
                Player.first.labelX -= 15;
                game.MovePlayer(ref Player.first.PosLeft, ref Player.first.PosTop, ref Field.first.Matrix);
                PrintElem(typeof(PassedCell), Player.first.labelX, Player.first.labelY);
                game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            }
                
            if (e.KeyCode == Keys.Up && Field.first.Matrix[Player.first.PosTop - 1, Player.first.PosLeft].GetType() != typeof(Wall))
            {
                Player.first.PosTop -= 1;
                Player.first.labelY -= 15;
                game.MovePlayer(ref Player.first.PosLeft, ref Player.first.PosTop, ref Field.first.Matrix);
                PrintElem(typeof(PassedCell), Player.first.labelX, Player.first.labelY);
                game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            }
                
            if (e.KeyCode == Keys.Down && Field.first.Matrix[Player.first.PosTop + 1, Player.first.PosLeft].GetType() != typeof(Wall))
            {
                Player.first.PosTop += 1;
                Player.first.labelY += 15;
                game.MovePlayer(ref Player.first.PosLeft, ref Player.first.PosTop, ref Field.first.Matrix);
                PrintElem(typeof(PassedCell), Player.first.labelX, Player.first.labelY);
                game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix);
            }
                
            labelPlayer.Location = new Point(Player.first.labelX, Player.first.labelY);
            labelPlayer.BringToFront();
        }

        public void PrintElem(Type type, int x, int y) // класс в параметр
        {
            PictureBox pictureBox = new PictureBox();
            //pictureBox.BorderStyle = BorderStyle.None;
            string border = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/wall.png";
            string cell = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/cell.png";
            string bonus = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/bonus.png";
            string trap = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/mine.png";
            string wall = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/wall.jpg";
            string passedCell = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/Grey_Cell.png";
            if (type == typeof(WallBorder))
            {
                pictureBox.Image = Image.FromFile(border);
            }
            if (type == typeof(Cell))
            {
                pictureBox.Image = Image.FromFile(cell);
            }
            if (type == typeof(Bonus))
            {
                pictureBox.Image = Image.FromFile(bonus);
            }
            if (type == typeof(Trap))
            {
                pictureBox.Image = Image.FromFile(trap);
                if (Game.gameStopped == true)
                {
                    pictureBox.BringToFront();
                }
            }
            if (type == typeof(Wall))
            {
                pictureBox.Image = Image.FromFile(wall);
            }
            if (type == typeof(PassedCell))
            {
                pictureBox.Image = Image.FromFile(passedCell);
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
    }
}
