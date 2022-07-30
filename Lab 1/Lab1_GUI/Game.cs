using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public class Game
    {
        public static int TrapAmount = 0;
        public static int PlayerAmount = 1;
        public static TimeSpan SpentTime;
        public static bool GameStopped = false;

        public void Timer(Label label)
        {
            var watch = Stopwatch.StartNew();
            Task.Run(() =>
            {
                while (!GameStopped)
                {
                    label.Text = watch.Elapsed.ToString();
                }
                SpentTime = watch.Elapsed;
                watch.Stop();
            });
        }

        public void MovePlayer(ref Player player, ref Element[,] matrix, Label label)
        {
            Result result = new Result();
            if (matrix[player.PosTop, player.PosLeft].GetType() == typeof(Trap))
            {
                if (Player.first.Life == 0)
                {
                    result.Defeat(ref matrix);
                }

                if (Player.first.Life == 1)
                {
                    Player.first.Life = 0;
                    matrix[player.PosTop, player.PosLeft] = new Cell();
                    label.Text = $"Life: {Player.first.Life}";
                }
            }

            if (player.PosTop == 0)
            {
                if (player.PosLeft == Field.MiddleOfField || player.PosLeft == Field.MiddleOfField + 2 || player.PosLeft == Field.MiddleOfField + 1)
                {
                    result.Win();
                }
            }

            if (player.PosLeft < 1)
            {
                player.PosLeft += 1;
                Player.first.labelX += Element.Length;
            }

            if (player.PosTop < 1 && player.PosLeft != Field.MiddleOfField && player.PosLeft != Field.MiddleOfField + 2 && player.PosLeft != Field.MiddleOfField + 1)
            {
                player.PosTop += 1;
                Player.first.labelY += Element.Length;
            }

            if (player.PosLeft > Field.MatrixLength - 2)
            {
                player.PosLeft -= 1;
                Player.first.labelX -= Element.Length;
            }

            if (player.PosTop > Field.MatrixWidth - 2 && player.PosLeft != Field.MiddleOfField && player.PosLeft != Field.MiddleOfField + 2 && player.PosLeft != Field.MiddleOfField + 1)
            {
                player.PosTop -= 1;
                Player.first.labelY -= Element.Length;
            }

            if (matrix[player.PosTop, player.PosLeft].GetType() == typeof(Bonus))
            {
                // matrix[top, left] = new Cell();
                Player.first.Life = 1;
                label.Text = $"Life: {Player.first.Life}";
            }
        }

        public void Check(int x, int y, ref Element[,] matrix, Label labelPlayer)
        {
            TrapAmount = 0;
            if (true)
            {
                if (matrix[y - 1, x].GetType() == typeof(Trap))
                {
                    TrapAmount++;
                }
            }

            if (x + 1 <= Field.MatrixLength)
            {
                if (matrix[y, x + 1].GetType() == typeof(Trap))
                {
                    TrapAmount++;
                }
            }

            if (x - 1 >= 0)
            {
                if (matrix[y, x - 1].GetType() == typeof(Trap))
                {
                    TrapAmount++;
                }
            }

            if (y + 1 < Field.MatrixWidth)
            {
                if (matrix[y + 1, x].GetType() == typeof(Trap))
                {
                    TrapAmount++;
                }
            }

            labelPlayer.Text = TrapAmount.ToString();
            labelPlayer.ForeColor = System.Drawing.Color.Green;
            labelPlayer.ForeColor = Player.color[TrapAmount];
        }
    }
}
