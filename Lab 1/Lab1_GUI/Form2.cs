using Lab_1;
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
    public partial class Form2 : Form
    {
        int x = 0;
        int y = 0;
        ElementsAdder elementsAdder = new ElementsAdder();
        Field field = new Field();
        

        public Form2()
        {
            InitializeComponent();

            field.Define(ref Field.Matrix1);
            PrintField(ref Field.Matrix1);
            Game game = new Game();
            //game.Start();
            //this.Controls.Add(player);

            textBox1.TabStop = false;
            labelPlayer.BringToFront();
            KeyDown += new KeyEventHandler(Form2_KeyDown);

        }

        public static Label labelPlayer = new Label
        {
            Size = new Size(14, 14),
            Font = new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold),
            Text = Game.TrapAmount.ToString(),
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.Green,
            BackColor = Color.White
        };

        public void PrintField(ref Element[,] Matrix)
        {
            
            for (int i = 0; i < Field.MatrixWidth; i++)
            {
                if (Matrix == Field.Matrix2)
                {
                    // Console.SetCursorPosition(50, i);
                }

                for (int j = 0; j < Field.MatrixLength; j++)
                {
                    if (j == 0)
                    {
                        x = 0;
                    }

                    if (Matrix[i, j].GetType() == typeof(Trap))
                    {
                        PrintElem(typeof(Trap));
                    }

                    if (Matrix[i, j].GetType() == typeof(WallBorder))
                    {
                        PrintElem(typeof(WallBorder));
                    }

                    if (Matrix[i, j].GetType() == typeof(Wall))
                    {
                        PrintElem(typeof(Wall));
                    }

                    if (Matrix[i, j].GetType() == typeof(Bonus))
                    {
                        PrintElem(typeof(Bonus));
                    }

                    if (Matrix[i, j].GetType() == typeof(Cell))
                    {
                        PrintElem(typeof(Cell));
                    }

                    if (Matrix[i, j].GetType() == typeof(Player))
                    {
                        labelPlayer.Location = new Point(x + 1, y + 1);
                        
                        this.Controls.Add(labelPlayer);
                        //PrintElem(typeof(Player));
                    }

                    x += 15;
                }

                y += 15;
            }
        }

        void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            int x = labelPlayer.Location.X;
            int y = labelPlayer.Location.Y;

            if (e.KeyCode == Keys.Right)
            {
                Game.Check(Player.PosLeft, Player.PosTop, ref Field.Matrix1);
                x += 15;
            }
                
            if (e.KeyCode == Keys.Left)
            {
                Game.Check(Player.PosLeft, Player.PosTop, ref Field.Matrix1);
                x -= 15;
            }
                
            if (e.KeyCode == Keys.Up)
            {
                Game.Check(Player.PosLeft, Player.PosTop, ref Field.Matrix1);
                
                y -= 15;
            }
                
            if (e.KeyCode == Keys.Down)
            {
                Game.Check(Player.PosLeft, Player.PosTop, ref Field.Matrix1);
                y += 15;
            }
                
            labelPlayer.Location = new Point(x, y);
        }

        public void PrintElem(Type type) // класс в параметр
        {
            PictureBox pictureBox = new PictureBox();
            string border = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/blueCell.jpg";
            string cell = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/whiteCell.jpg";
            string bonus = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/bonus.png";
            string trap = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/mine.png";
            string wall = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/wall.jpg";
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
            }
            if (type == typeof(Wall))
            {
                pictureBox.Image = Image.FromFile(wall);
            }
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(15, 15);
            pictureBox.Location = new Point(x, y);
            this.Controls.Add(pictureBox);
        }
    }
}
