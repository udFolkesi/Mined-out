using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Player : Element
    {
        // proeprty?
        private static ConsoleKeyInfo key;
        public int CursorPosLeft2 = 0; // 11
        public int CursorPosTop2 = 0; // 7
        public int CursorPosLeft = 0; // 11
        public int CursorPosTop = 0; // 7
        private Field field = new Field();
        private Rules rules = new Rules();
        private Result result = new Result();
        public static TimeSpan _time;
        public static int timeStop = 0;
        private static object locker = new object();

        public int Life { get; set; }

        // Player player = new Player(); почему с этим с не работает?
        // чтоб можно было внизу и вверху по 3 клетки были свободными
        // абстрактное поле
        public enum WhatCase
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

        public override void Define()
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

            Check(CursorPosLeft, CursorPosTop, ref Field.Matrix1);

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

                Check(CursorPosLeft2 - 50, CursorPosTop2, ref Field.Matrix2);

                lock (locker)
                {
                    Console.SetCursorPosition(CursorPosLeft2, CursorPosTop2);
                }
            }

            key = Console.ReadKey(true);
            Timer(watch2);

            while (timeStop == 0) // пока игровая сессия идет = true
            {
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveCase(1, ref Field.Matrix1, ref CursorPosLeft, ref CursorPosTop);
                        break;
                    case ConsoleKey.DownArrow:
                        if (CursorPosTop == Field.MatrixWidth - 1)
                        {
                            break;
                        }

                        MoveCase(2, ref Field.Matrix1, ref CursorPosLeft, ref CursorPosTop);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveCase(3, ref Field.Matrix1, ref CursorPosLeft, ref CursorPosTop);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveCase(4, ref Field.Matrix1, ref CursorPosLeft, ref CursorPosTop);
                        break;
                    case ConsoleKey.W:
                        MoveCase(1, ref Field.Matrix2, ref CursorPosLeft2, ref CursorPosTop2);
                        break;
                    case ConsoleKey.S:
                        MoveCase(2, ref Field.Matrix2, ref CursorPosLeft2, ref CursorPosTop2);
                        break;
                    case ConsoleKey.A:
                        MoveCase(3, ref Field.Matrix2, ref CursorPosLeft2, ref CursorPosTop2);
                        break;
                    case ConsoleKey.D:
                        MoveCase(4, ref Field.Matrix2, ref CursorPosLeft2, ref CursorPosTop2);
                        break;
                }

                key = Console.ReadKey(true);
            }

            if (key.Key == ConsoleKey.B)
            {
                Menu menu = new Menu();
                timeStop = 1;
                Thread.Sleep(20);
                Console.Clear();
                menu.Start();
            }

            if (key.Key == ConsoleKey.R)
            {
                timeStop = 1;
                Thread.Sleep(20);
                Console.Clear();
                rules.Define();
                field.Define(ref Field.Matrix1);
                Define();
                // Console.Beep();
            }

            if (key.Key == ConsoleKey.Escape)
            {
                timeStop = 1;
                Thread.Sleep(50);
                Console.Clear();
                Console.WriteLine("GAME OVER");
            }
        }

        public static void Timer(Stopwatch watch)
        {
            watch.Restart();
            Task.Run(() =>
            {
                while (timeStop == 0)
                {
                    Console.CursorVisible = false;
                    Thread.Sleep(1);
                    lock (locker)
                    {
                        Console.SetCursorPosition(Field.MatrixLength + 5, 0);
                        Console.Write(watch.Elapsed);
                    }

                    if (timeStop == 1 )
                    {
                        _time = watch.Elapsed;
                        watch.Stop();
                    }
                }
            });
        }

        // использовать this
        public void MoveCase(int direction, ref object[,] matrix, ref int cursorPosLeft, ref int cursorPosTop)
        {
            lock (locker)
            {

                Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write('.'); // ?
                Console.BackgroundColor = ConsoleColor.Black;
            }

            switch (direction)
            {
                case 1:
                    cursorPosTop--;
                    break;
                case 2:
                    cursorPosTop++;
                    break;
                case 3:
                    cursorPosLeft--;
                    break;
                case 4:
                    cursorPosLeft++;
                    break;
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

            if (direction == 1)
            {
                if (cursorPosTop != 0)
                {
                    if (matrix == Field.Matrix1)
                    {
                        Check(cursorPosLeft, cursorPosTop, ref matrix);
                    }
                    else
                    {
                        Check(cursorPosLeft - 50, cursorPosTop, ref matrix);
                    }
                }

                if ((cursorPosLeft == field.MiddleOfField + 1 && cursorPosTop == 0) ||
                    (cursorPosLeft == field.MiddleOfField && cursorPosTop == 0) ||
                    (cursorPosLeft == field.MiddleOfField + 2 && cursorPosTop == 0))
                {
                    timeStop = 1;
                    Console.Clear();
                    result.Win();
                }
            }
            else
            {
                if (matrix == Field.Matrix1)
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

        public void MoveCursor(ref int left, ref int top, int @case, ref object[,] matrix)
        {
            if (matrix[top, left].GetType() == typeof(Wall))
            {
                switch (@case)
                {
                    case 1:
                        top++;
                        break;
                    case 2:
                        top--;
                        break;
                    case 3:
                        left++;
                        break;
                    case 4:
                        left--;
                        break;
                }

                // continue
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
                matrix[top, left] = ' ';
                Life = 1;
                Console.SetCursorPosition(Field.MatrixLength + 1, 1);
                Console.Write("Life: 1");
            }

            if (matrix[top, left].GetType() == typeof(Trap))
            {
                if (Life == 0)
                {
                    result.Defeat(ref matrix);
                }

                if (Life == 1)
                {
                    Life = 0;
                    matrix[top, left] = ' ';
                    Console.SetCursorPosition(Field.MatrixLength + 1, 1);
                    Console.Write("Life: 0");
                }
            }

            lock (locker)
            {
                if (matrix == Field.Matrix1)
                {
                    Console.SetCursorPosition(left, top);
                }
                else
                {
                    Console.SetCursorPosition(left + 50, top);
                }
            }
        }

        public void Check(int x, int y, ref object[,] matrix)
        {
            int amount = 0;
            // Console.WriteLine(Matrix.GetLength(0/1));
            if (y - 1 <= Field.MatrixWidth)
            {
                if (matrix[y - 1, x].GetType() == typeof(Trap))
                {
                    amount++;
                }
            }

            if (x + 1 <= Field.MatrixLength)
            {
                if (matrix[y, x + 1].GetType() == typeof(Trap))
                {
                    amount++;
                }
            }

            if (x - 1 <= Field.MatrixLength)
            {
                if (matrix[y, x - 1].GetType() == typeof(Trap))
                {
                    amount++;
                }
            }

            if (y + 1 < Field.MatrixWidth)
            {
                if (matrix[y + 1, x].GetType() == typeof(Trap))
                {
                    amount++;
                }
            }

            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                WhatColor(amount);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write(amount);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void WhatColor(int minesAmount)
        {
            switch (minesAmount)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }
    }
}
