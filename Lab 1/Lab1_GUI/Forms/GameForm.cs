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
        // метода вывода элемента в классе эелемента
        int x = 0;
        int y = 0;
        private Field field = new Field();
        private Game game = new Game();

        public GameForm()
        {
            InitializeComponent();
            Player.first.PosLeft = Field.MiddleOfField + 1;
            Player.first.PosTop = Field.MatrixWidth - 1;
            Player.second.PosLeft = Player.first.PosLeft;
            Player.second.PosTop = Player.first.PosTop;
            Start();
        }

        public static Label labelPlayer1 = new Label
        {
            Size = new Size(15, 15),
            Font = new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold),
            Text = Game.TrapAmount.ToString(),
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.Black,
        };

        public static Label labelPlayer2 = new Label()
        {
            Size = labelPlayer1.Size,
            Font = labelPlayer1.Font,
            Text = labelPlayer1.Text,
            TextAlign = labelPlayer1.TextAlign,
            BackColor = labelPlayer1.BackColor,
        };

        public void Start()
        {
            field.Define(ref Field.first.Matrix);
            PrintField(ref Field.first.Matrix, labelPlayer1);
            game.Check(Player.first.PosLeft, Player.first.PosTop, ref Field.first.Matrix, labelPlayer1);
            if (Game.PlayerAmount == 2)
            {
                field.Define(ref Field.second.Matrix);
                PrintField(ref Field.second.Matrix, labelPlayer2);
                game.Check(Player.second.PosLeft, Player.second.PosTop, ref Field.second.Matrix, labelPlayer2);
            }

            KeyDown += new KeyEventHandler((sender, e) => Form2_KeyDown(sender, e, Field.first.Matrix, Field.second.Matrix, Player.first, Player.second));
            Game.GameStopped = false;
            game.Timer(label1);
        }

        public void PrintField(ref Element[,] matrix, Label labelPlayer)
        {
            Field.MiddleOfField = Convert.ToInt32(Math.Floor(Field.MatrixLength / 2d) - 1);
            Type elemType;

            for (int i = 0; i < Field.MatrixWidth; i++)
            {
                for (int j = 0; j < Field.MatrixLength; j++)
                {
                    if (j == 0)
                    {
                        x = 0;
                    }

                    elemType = matrix[i, j].GetType();
                    PrintElem(elemType, x, y);
                    if (elemType == typeof(Trap))
                    {
                        PrintElem(typeof(Cell), x, y);
                    }

                    if (elemType == typeof(Player))
                    {
                        PrintElem(typeof(PassedCell), x, y);
                        labelPlayer.Location = new Point(x + 1, y + 1);
                        this.Controls.Add(labelPlayer);
                        labelPlayer.BringToFront();
                    }

                    x += 15;
                }

                y += 15;
            }

            y += 15;
        }

        public void Form2_KeyDown(
            object sender,
            KeyEventArgs e,
            Element[,] matrxi1,
            Element[,] matrix2,
            Player player1,
            Player player2)
        {
            player1.labelX = labelPlayer1.Location.X;
            player1.labelY = labelPlayer1.Location.Y;
            player2.labelX = labelPlayer2.Location.X;
            player2.labelY = labelPlayer2.Location.Y;

            if (e.KeyCode == Keys.Right && matrxi1[player1.PosTop, player1.PosLeft + 1].GetType() != typeof(Wall))
            {
                player1.PosLeft += 1;
                player1.labelX += 15;
            }

            if (e.KeyCode == Keys.Left && matrxi1[player1.PosTop, player1.PosLeft - 1].GetType() != typeof(Wall))
            {
                player1.PosLeft -= 1;
                player1.labelX -= 15;
            }

            if (e.KeyCode == Keys.Up && matrxi1[player1.PosTop - 1, player1.PosLeft].GetType() != typeof(Wall))
            {
                player1.PosTop -= 1;
                player1.labelY -= 15;
            }

            if (e.KeyCode == Keys.Down && matrxi1[player1.PosTop + 1, player1.PosLeft].GetType() != typeof(Wall))
            {
                player1.PosTop += 1;
                player1.labelY += 15;
            }

            game.MovePlayer(ref player1.PosLeft, ref player1.PosTop, ref matrxi1, label3);
            PrintElem(typeof(PassedCell), player1.labelX, player1.labelY);
            game.Check(player1.PosLeft, player1.PosTop, ref matrxi1, labelPlayer1);

            if(Game.PlayerAmount == 2)
            {
                if (e.KeyCode == Keys.D && matrix2[player2.PosTop, player2.PosLeft + 1].GetType() != typeof(Wall))
                {
                    player2.PosLeft += 1;
                    player2.labelX += 15;
                }

                if (e.KeyCode == Keys.A && matrix2[player2.PosTop, player2.PosLeft - 1].GetType() != typeof(Wall))
                {
                    player2.PosLeft -= 1;
                    player2.labelX -= 15;
                }

                if (e.KeyCode == Keys.W && matrix2[player2.PosTop - 1, player2.PosLeft].GetType() != typeof(Wall))
                {
                    player2.PosTop -= 1;
                    player2.labelY -= 15;
                }

                if (e.KeyCode == Keys.S && matrix2[player2.PosTop + 1, player2.PosLeft].GetType() != typeof(Wall))
                {
                    player2.PosTop += 1;
                    player2.labelY += 15;
                }

                game.MovePlayer(ref player2.PosLeft, ref player2.PosTop, ref matrxi1, label3);
                PrintElem(typeof(PassedCell), player2.labelX, player2.labelY);
                game.Check(player2.PosLeft, player2.PosTop, ref matrxi1, labelPlayer2);
            }

            if (Game.GameStopped == true)
            {
                PictureBox explosion = new PictureBox()
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile("C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/explosion.gif"),
                    Size = new Size(15, 15),
                    Location = new Point(player1.labelX, player1.labelY),

                };
                this.Controls.Add(explosion);
                ShowTraps();
                explosion.BringToFront();
            }

            labelPlayer1.Location = new Point(player1.labelX, player1.labelY);
            labelPlayer1.BringToFront();
            if (Game.PlayerAmount == 2)
            {
                labelPlayer2.Location = new Point(player2.labelX, player2.labelY);
                labelPlayer2.BringToFront();
            }
        }

        public void PrintElem(Type type, int x, int y) // класс в параметр !!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            PictureBox pictureBox = new PictureBox();
            //pictureBox.Image = Image.FromFile( .path);
            // constructor

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
            pictureBox.Size = new Size(15, 15);
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
            this.Enabled = true;
            Game.GameStopped = false;
            game.Timer(label1);
        }
    }
}
