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
        public static int PlayerAmount;
        public static TimeSpan SpentTime;
        public static bool gameStopped = false;

        public void Start()
        {
            Timer();

                /*if (key.Key == ConsoleKey.P)
                {
                    gameStopped = true;
                    //key = ConsoleKey.Clear;
                    while (gameStopped == true)
                    {
                        if(key.Key == ConsoleKey.P)
                        {
                            gameStopped = false;
                        }
                    }
                }

                if (key.Key == ConsoleKey.B)
                {
                    //Menu menu = new Menu();
                    gameStopped = true;
                    Thread.Sleep(20);
                    Console.Clear();
                    //menu.Start();
                }

                if (key.Key == ConsoleKey.R)
                {
                    gameStopped = true;
                    Thread.Sleep(20);
                    Console.Clear();
                    //rules.Define();
                    field.Define(ref Field.Matrix1);
                    Start();
                    // Console.Beep();
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    gameStopped = true;
                    Thread.Sleep(50);
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                }
            }*/
            
        }

        public void Timer()
        {
            var watch = Stopwatch.StartNew();
            Task.Run(() =>
            {
                while (gameStopped == false)
                {
                    Form2.label1.Text = watch.Elapsed.ToString();

                    if (gameStopped == true)
                    {
                        SpentTime = watch.Elapsed;
                        watch.Stop();
                    }
                }
            });
        }

        public void MovePlayer(ref int left, ref int top, ref Element[,] matrix)
        {

            if (top == 0)
            {
                if(left == Field.MiddleOfField || left == Field.MiddleOfField + 2 || left == Field.MiddleOfField + 1)
                {
                    Result.Win();
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
                //MessageBox.Show("О, жизька, заебись");
                Form2.label3.Text = $"Life: {Player.first.Life}";
            }

            if (matrix[top, left].GetType() == typeof(Trap))
            {
                if (Player.first.Life == 0 /*&& timeStop == 0*/)
                {
                    Result.Defeat(ref matrix);
                    //result.Defeat(ref matrix);
                }

                if (Player.first.Life == 1)
                {
                    Player.first.Life = 0;
                    matrix[top, left] = new Cell();
                    Form2.label3.Text = $"Life: {Player.first.Life}";
                }
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
            } // проверить надобность в проверке

            if (y + 1 < Field.MatrixWidth)
            {
                if (matrix[y + 1, x].GetType() == typeof(Trap))
                {
                    TrapAmount++;
                }
            }

            Form2.labelPlayer.Text = TrapAmount.ToString();
            Form2.labelPlayer.ForeColor = System.Drawing.Color.Green;
            Player.WhatColor(TrapAmount);
        }
    }
}
