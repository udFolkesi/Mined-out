using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    class Player : Element
    {
        // proeprty?
        private static ConsoleKeyInfo key;
        public int cursorPosLeft2 = 0; // 11
        public int cursorPosTop2 = 0; // 7
        public int cursorPosLeft = 0; // 11
        public int cursorPosTop = 0; // 7
        public static int act = 0;
        public int life { get; set; }
        private Field field = new Field();
        private Rules rules = new Rules();
        //private Files file = new Files();
        private Result result = new Result();
        public static TimeSpan _time;
        public static int timeStop = 0;
        private static CancellationTokenSource _cts;
        private static object locker = new object();

        // Player player = new Player(); почему с этим с не работает?
        // чтоб можно было внизу и вверху по 3 клетки были свободными
        // абстрактное поле
        public override void Define()
        {
            timeStop = 0;
            int whatCase = 0; // чет другое придумать
            lock (locker)
            {
                Console.SetCursorPosition(Field.matrixLength + 1, 0);
            }

            Console.Write("00:00:00"); // убрать
            field.bord = Convert.ToInt32(Math.Floor(Field.matrixLength / 2d) - 1);
            cursorPosLeft = field.bord + 1;
            cursorPosTop = Field.matrixWidth - 1;
            cursorPosLeft2 = 50 + field.bord + 1;
            cursorPosTop2 = Field.matrixWidth - 1;
            lock (locker)
            {
                Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            }

            Check(cursorPosLeft, cursorPosTop, ref Field.Matrix1);

            lock (locker)
            {
                Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            }

            if (Menu.playerAmount == 2)
            {
                lock (locker)
                {
                    Console.SetCursorPosition(cursorPosLeft + 50, cursorPosTop);
                }

                Check(50 + cursorPosLeft, cursorPosTop, ref Field.Matrix2);

                lock (locker)
                {
                    Console.SetCursorPosition(cursorPosLeft + 50, cursorPosTop);
                }
            }

            key = Console.ReadKey(true);
            timer();

            while (key.Key != ConsoleKey.Escape && act == 0 && key.Key != ConsoleKey.R
                && key.Key != ConsoleKey.B) // пока игровая сессия идет = true
            {
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        whatCase = 1;
                        moveCase(whatCase, ref Field.Matrix1, ref cursorPosLeft, ref cursorPosTop);
                        break;
                    case ConsoleKey.DownArrow:
                        if(cursorPosTop == Field.matrixWidth - 1)
                        {
                            break;
                        }

                        whatCase = 2;
                        moveCase(whatCase, ref Field.Matrix1, ref cursorPosLeft, ref cursorPosTop);
                        break;
                    case ConsoleKey.LeftArrow:
                        whatCase = 3;
                        moveCase(whatCase, ref Field.Matrix1, ref cursorPosLeft, ref cursorPosTop);
                        break;
                    case ConsoleKey.RightArrow:
                        whatCase = 4;
                        moveCase(whatCase, ref Field.Matrix1, ref cursorPosLeft, ref cursorPosTop);
                        break;
                    case ConsoleKey.W:
                        whatCase = 1;
                        moveCase(whatCase, ref Field.Matrix2, ref cursorPosLeft2, ref cursorPosTop2);
                        break;
                    case ConsoleKey.A:
                        whatCase = 3;
                        moveCase(whatCase, ref Field.Matrix2, ref cursorPosLeft2, ref cursorPosTop2);
                        break;
                    case ConsoleKey.D:
                        whatCase = 4;
                        moveCase(whatCase, ref Field.Matrix2, ref cursorPosLeft2, ref cursorPosTop2);
                        break;
                    case ConsoleKey.S:
                        whatCase = 2;
                        moveCase(whatCase, ref Field.Matrix2, ref cursorPosLeft2, ref cursorPosTop2);
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
                menu.PrintMenu();
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

        public static void timer()
        {
            //_cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                var watch2 = Stopwatch.StartNew();
                while (timeStop == 0)
                {
                    Console.CursorVisible = false;
                    Thread.Sleep(1);
                    lock (locker)
                    {
                        Console.SetCursorPosition(Field.matrixLength + 1, 0);
                        Console.Write(watch2.Elapsed);
                    }

                    if (timeStop == 1 )
                    {
                        _time = watch2.Elapsed;
                        watch2.Stop();
                        _cts.Cancel();
                    }
                }
            });
        }

        // использовать this
        public void moveCase(int Case, ref char[,] Matrix, ref int cursorPosLeft, ref int cursorPosTop)
        {
            lock (locker)
            {

                    Console.SetCursorPosition(cursorPosLeft, cursorPosTop);

                
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write('.'); // ?
                Console.BackgroundColor = ConsoleColor.Black;
            }

            switch (Case)
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

            if(cursorPosLeft == cursorPosLeft2)
            {
                cursorPosLeft -= 50;
            }
            MoveCursor(ref cursorPosLeft, ref cursorPosTop, Case, ref Matrix);
            if (cursorPosLeft == cursorPosLeft2)
            {
                cursorPosLeft += 50;
            }
            if (Case == 1)
            {
                if (cursorPosTop != 0)
                {
                    Check(cursorPosLeft, cursorPosTop, ref Matrix);
                }

                if ((cursorPosLeft == field.bord + 1 && cursorPosTop == 0) ||
                    (cursorPosLeft == field.bord && cursorPosTop == 0) ||
                    (cursorPosLeft == field.bord + 2 && cursorPosTop == 0))
                {
                    timeStop = 1;
                    Console.Clear();

                    result.Win();
                    //Win();
                }
            }
            else
            {
                Check(cursorPosLeft, cursorPosTop, ref Matrix);
            }
            if (cursorPosLeft == cursorPosLeft2)
            {
                cursorPosLeft -= 50;
            }
            MoveCursor(ref cursorPosLeft, ref cursorPosTop, Case, ref Matrix);
            if (cursorPosLeft == cursorPosLeft2)
            {
                cursorPosLeft += 50;
            }
        }

        public void MoveCursor(ref int left, ref int top, int Case, ref char[,] Matrix)
        {
            if (Matrix[top, left] == '0')
            {
                switch (Case)
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

            if (top < 1 && left == field.bord + 1)
            {
                top = 0;
            }

            if (top < 1 && left != field.bord + 1 && left != field.bord + 2 && left != field.bord)
            {
                top = 1;
            }

            if (left > Field.matrixLength - 2)
            {
                left = Field.matrixLength - 2;
            }

            if (top == Field.matrixWidth - 1 && left == field.bord)
            {
                top = Field.matrixWidth - 1;
            }

            if (top > Field.matrixWidth - 2 && left != field.bord && left != field.bord + 2 && left != field.bord + 1)
            {
                top = Field.matrixWidth - 2;
            }

            if (Matrix[top, left] == '$')
            {
                Matrix[top, left] = ' ';
                life = 1;
                Console.SetCursorPosition(Field.matrixLength + 1, 1);
                Console.Write("Life: 1");
            }

            if (Matrix[top, left] == 'X')
            {
                if (life == 0)
                {
                    //Console.Write("hallo");
                    result.Defeat(ref Matrix);
                    //Defeat();
                }

                if (life == 1)
                {
                    life = 0;
                    Matrix[top, left] = ' ';
                    Console.SetCursorPosition(Field.matrixLength + 1, 1);
                    Console.Write("Life: 0");
                }
            }

            lock (locker)
            {
                if (Matrix == Field.Matrix1)
                {
                    Console.SetCursorPosition(left, top);
                }
                else
                {
                    Console.SetCursorPosition(left + 50, top);
                }
            }
        }

        public void Check(int x, int y, ref char[,] Matrix)
        {
            int amount = 0;
            if (Matrix == Field.Matrix2)
            {
                x+=50;
            }

            try
            {
                if (Matrix[y - 1, x] == 'X')
                {
                    amount++;
                }
            }
            catch
            {
            }


            try
            {
                if (Matrix[y, x + 1] == 'X')
                {
                    amount++;
                }
            }
            catch
            {

            }

            try
            {
                if (Matrix[y, x - 1] == 'X')
                {
                    amount++;
                }
            }
            catch
            {

            }

            try
            {
                if (Matrix[y + 1, x] == 'X')
                {
                    amount++;
                }
            }
            catch
            {
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
