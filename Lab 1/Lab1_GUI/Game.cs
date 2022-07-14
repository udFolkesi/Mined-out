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
        public static bool gameStopped = false;
        

        public void Start()
        {
        }

        public void Timer(Label label)
        {
            var watch = Stopwatch.StartNew();
            Task.Run(() =>
            {
                while (gameStopped == false)
                {
                    label.Text = watch.Elapsed.ToString();

                    if (gameStopped == true)
                    {
                        SpentTime = watch.Elapsed;
                        watch.Stop();
                    }
                }
            });
        }

        public void MovePlayer(ref int left, ref int top, ref Element[,] matrix, Label label)
        {
            if (matrix[top, left].GetType() == typeof(Trap))
            {
                if (Player.first.Life == 0)
                {
                    Result result = new Result();
                    result.Defeat(ref matrix);
                }

                if (Player.first.Life == 1)
                {
                    Player.first.Life = 0;
                    matrix[top, left] = new Cell();
                    label.Text = $"Life: {Player.first.Life}";
                }
            }

            if (top == 0)
            {
                if(left == Field.MiddleOfField || left == Field.MiddleOfField + 2 || left == Field.MiddleOfField + 1)
                {
                    Result result = new Result();
                    result.Win();
                }
            }

            if (left < 1)
            {
                left += 1;
                Player.first.labelX += 15;
            }

            if (top < 1 && left != Field.MiddleOfField && left != Field.MiddleOfField + 2 && left != Field.MiddleOfField + 1)
            {
                top += 1;
                Player.first.labelY += 15;
            }

            if (left > Field.MatrixLength - 2)
            {
                left -= 1;
                Player.first.labelX -= 15;
            }

            if (top > Field.MatrixWidth - 2 && left != Field.MiddleOfField && left != Field.MiddleOfField + 2 && left != Field.MiddleOfField + 1)
            {
                top -= 1;
                Player.first.labelY -= 15;
            }

            if (matrix[top, left].GetType() == typeof(Bonus))
            {
                //matrix[top, left] = new Cell();
                Player.first.Life = 1;
                label.Text = $"Life: {Player.first.Life}";
            }
        }

        public void Check(int x, int y, ref Element[,] matrix)
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

            GameForm.labelPlayer1.Text = TrapAmount.ToString();
            GameForm.labelPlayer1.ForeColor = System.Drawing.Color.Green;
            Player.WhatColor(TrapAmount);
        }
    }
}
