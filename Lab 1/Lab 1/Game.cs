using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Game
    {
        // proeprty?
        private static ConsoleKeyInfo key;
        public int CursorPosLeft2 = 0; // 11
        public int CursorPosTop2 = 0; // 7
        public int CursorPosLeft = 0; // 11
        public int CursorPosTop = 0; // 7
        private Player player = new Player();
        private Field field = new Field();
        private Rules rules = new Rules();
        private Result result = new Result();
        public static TimeSpan SpentTime;
        public static bool gameStopped = false;
        private static object locker = new object();

        public int Life { get; set; }

        // Player player = new Player(); почему с этим с не работает?
        // чтоб можно было внизу и вверху по 3 клетки были свободными
        // абстрактное поле
        public enum Direction // название go/move
        {
            up = 1,
            down = 2,
            left = 3,
            right = 4,
            w = 1,
            s = 2,
            a = 3,
            d = 4,
        }

        public void slovar(ref int x, ref int y, int @case)
        {
            var people = new Dictionary<int, int>()
            {
                {1, y - 1},
                {2, y + 1},
                {3, x - 1},
                {4, x + 1}
            };
            if (@case == 1 || @case == 2)
            {
                y = people[@case];
            }
            if (@case == 3 || @case == 4)
            {
                x = people[@case];
            }
        }

        public void Start()
        {
            lock (locker)
            {
                Console.SetCursorPosition(Field.MatrixLength + 5, 0);
            }

            var watch2 = Stopwatch.StartNew();
            watch2.Reset();
            Console.WriteLine(watch2.Elapsed);
            field.MiddleOfField = Convert.ToInt32(Math.Floor(Field.MatrixLength / 2d) - 1);
            CursorPosLeft = field.MiddleOfField + 1;
            CursorPosTop = Field.MatrixWidth - 1;
            CursorPosLeft2 = 50 + field.MiddleOfField + 1;
            CursorPosTop2 = Field.MatrixWidth - 1;
            lock (locker)
            {
                Console.SetCursorPosition(CursorPosLeft, CursorPosTop);
            }

            Check(CursorPosLeft, CursorPosTop, ref Field.field1.Matrix);

            lock (locker)
            {
                Console.SetCursorPosition(CursorPosLeft, CursorPosTop);
            }

            if (Menu.PlayerAmount == 2)
            {
                lock (locker)
                {
                    Console.SetCursorPosition(CursorPosLeft2, CursorPosTop2);
                }

                Check(CursorPosLeft2 - 50, CursorPosTop2, ref Field.field2.Matrix);

                lock (locker)
                {
                    Console.SetCursorPosition(CursorPosLeft2, CursorPosTop2);
                }
            }

            key = Console.ReadKey(true);
            Timer(watch2);

            while (gameStopped == false) // пока игровая сессия идет = true
            {
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveCase((int)Direction.up, ref Field.field1.Matrix, ref CursorPosLeft, ref CursorPosTop);
                        break;
                    case ConsoleKey.DownArrow:
                        if (CursorPosTop == Field.MatrixWidth - 1)
                        {
                            break;
                        }

                        MoveCase((int)Direction.down, ref Field.field1.Matrix, ref CursorPosLeft, ref CursorPosTop);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveCase((int)Direction.left, ref Field.field1.Matrix, ref CursorPosLeft, ref CursorPosTop);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveCase((int)Direction.right, ref Field.field1.Matrix, ref CursorPosLeft, ref CursorPosTop);
                        break;
                    case ConsoleKey.W:
                        MoveCase((int)Direction.up, ref Field.field2.Matrix, ref CursorPosLeft2, ref CursorPosTop2);
                        break;
                    case ConsoleKey.S:
                        MoveCase((int)Direction.down, ref Field.field2.Matrix, ref CursorPosLeft2, ref CursorPosTop2);
                        break;
                    case ConsoleKey.A:
                        MoveCase((int)Direction.left, ref Field.field2.Matrix, ref CursorPosLeft2, ref CursorPosTop2);
                        break;
                    case ConsoleKey.D:
                        MoveCase((int)Direction.right, ref Field.field2.Matrix, ref CursorPosLeft2, ref CursorPosTop2);
                        break;
                }

                key = Console.ReadKey(true);


                if (key.Key == ConsoleKey.P)
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
                    Menu menu = new Menu();
                    gameStopped = true;
                    Thread.Sleep(20);
                    Console.Clear();
                    menu.Start();
                }

                if (key.Key == ConsoleKey.R)
                {
                    gameStopped = true;
                    Thread.Sleep(20);
                    Console.Clear();
                    rules.Define();
                    field.Define(ref Field.field1.Matrix);
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
            }
        }

        public static void Timer(Stopwatch watch)
        {
            watch.Restart();
            Task.Run(() =>
            {
                while (gameStopped == false)
                {
                    Console.CursorVisible = false;
                    Thread.Sleep(1);
                    lock (locker)
                    {
                        Console.SetCursorPosition(Field.MatrixLength + 5, 0);
                        Console.Write(watch.Elapsed);
                    }

                    if (gameStopped == true)
                    {
                        SpentTime = watch.Elapsed;
                        watch.Stop();
                    }
                }
            });
        }

        // использовать this
        public void MoveCase(int direction, ref Element[,] matrix, ref int cursorPosLeft, ref int cursorPosTop)
        {
            lock (locker)
            {

                Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write('.'); // ?
                Console.BackgroundColor = ConsoleColor.Black;
            }

            slovar(ref cursorPosLeft, ref cursorPosTop, direction);

            if (cursorPosLeft == CursorPosLeft2)
            {
                cursorPosLeft -= 50;
            }

            MoveCursor(ref cursorPosLeft, ref cursorPosTop, direction, ref matrix);
            if (cursorPosLeft == CursorPosLeft2)
            {
                cursorPosLeft += 50;
            }

            if (direction == 1)
            {
                if (cursorPosTop != 0)
                {
                    if (matrix == Field.field1.Matrix)
                    {
                        Check(cursorPosLeft, cursorPosTop, ref matrix);
                    }
                    else
                    {
                        Check(cursorPosLeft - 50, cursorPosTop, ref matrix);
                    }
                }

                if (cursorPosTop == 0)
                {
                    gameStopped = true;
                    Console.Clear();
                    result.Win();
                }
            }
            else
            {
                if (matrix == Field.field1.Matrix)
                {
                    Check(cursorPosLeft, cursorPosTop, ref matrix);
                }
                else
                {
                    Check(cursorPosLeft - 50, cursorPosTop, ref matrix);
                }
            }

            if (cursorPosLeft == CursorPosLeft2)
            {
                cursorPosLeft -= 50;
            }

            MoveCursor(ref cursorPosLeft, ref cursorPosTop, direction, ref matrix);
            if (cursorPosLeft == CursorPosLeft2)
            {
                cursorPosLeft += 50;
            }
        }

        public void MoveCursor(ref int left, ref int top, int @case, ref Element[,] matrix)
        {
            if (matrix[top, left].GetType() == typeof(Wall))
            {
                slovar(ref top, ref left, @case);
            }

            if (left < 1)
            {
                left = 1;
            }

            if (top < 1 && left == field.MiddleOfField + 1)
            {
                top = 0;
            }

            if (top < 1 && left != field.MiddleOfField + 1 && left != field.MiddleOfField + 2 && left != field.MiddleOfField)
            {
                top = 1;
            }

            if (left > Field.MatrixLength - 2)
            {
                left = Field.MatrixLength - 2;
            }

            if (top == Field.MatrixWidth - 1 && left == field.MiddleOfField)
            {
                top = Field.MatrixWidth - 1;
            }

            if (top > Field.MatrixWidth - 2 && left != field.MiddleOfField && left != field.MiddleOfField + 2 && left != field.MiddleOfField + 1)
            {
                top = Field.MatrixWidth - 2;
            }

            if (matrix[top, left].GetType() == typeof(Bonus))
            {
                matrix[top, left] = new Cell();
                Life = 1;
                Console.SetCursorPosition(Field.MatrixLength + 1, 1);
                Console.Write("Life: 1");
            }

            if (matrix[top, left].GetType() == typeof(Trap))
            {
                if (Life == 0 /*&& timeStop == 0*/)
                {
                     result.Defeat(ref matrix);
                }

                if (Life == 1)
                {
                    Life = 0;
                    matrix[top, left] = new Cell();
                    Console.SetCursorPosition(Field.MatrixLength + 1, 1);
                    Console.Write("Life: 0");
                }
            }

            lock (locker)
            {
                if (matrix == Field.field1.Matrix)
                {
                    Console.SetCursorPosition(left, top);
                }
                else
                {
                    Console.SetCursorPosition(left + 50, top);
                }
            }
        }

        public void Check(int x, int y, ref Element[,] matrix)
        {
            int trapAmount = 0;
            // Console.WriteLine(Matrix.GetLength(0/1));
            if (y - 1 <= 0)
            {
                if (matrix[y - 1, x].GetType() == typeof(Trap))
                {
                    trapAmount++;
                }
            }

            if (x + 1 <= Field.MatrixLength)
            {
                if (matrix[y, x + 1].GetType() == typeof(Trap))
                {
                    trapAmount++;
                }
            }

            if (x - 1 >= 0)
            {
                if (matrix[y, x - 1].GetType() == typeof(Trap))
                {
                    trapAmount++;
                }
            } // проверить надобность в проверке

            if (y + 1 < Field.MatrixWidth)
            {
                if (matrix[y + 1, x].GetType() == typeof(Trap))
                {
                    trapAmount++;
                }
            }

            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Player.WhatColor(trapAmount);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                /*if(timeStop == 0)
                {*/

                    Console.Write(trapAmount);
                //}
                //matrix[x, y] = player;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
