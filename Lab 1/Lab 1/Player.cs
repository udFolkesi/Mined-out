using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Player : Element
    {
        private static ConsoleKeyInfo key;
        public int cursorPosLeft = 0; // 11
        public int cursorPosTop = 0; // 7
        private static int act = 0;
        private Field field = new Field();
        private Rules rules = new Rules();
        static int timeStop = 0;
        private static CancellationTokenSource _cts;
        public int life { set; get; }

        //удалить this
        static object locker = new object();

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
            Console.Write("00:00:00");
            field.bord = Convert.ToInt32(Math.Floor(Field.matrixLength / 2d) - 1);
            cursorPosLeft = field.bord + 1; 
            cursorPosTop = Field.matrixWidth - 1;
            lock (locker)
            {
                Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            }
            Check(cursorPosLeft, cursorPosTop);
            lock (locker)
            {
                Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            }
            key = Console.ReadKey(true);
            timer();
            

            while (key.Key != ConsoleKey.Escape && act == 0)
            {
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        whatCase = 1;
                        moveCase(whatCase);
                        break;
                    case ConsoleKey.DownArrow:
                        whatCase = 2;
                        moveCase(whatCase);
                        break;
                    case ConsoleKey.LeftArrow:
                        whatCase = 3;
                        moveCase(whatCase);
                        break;
                    case ConsoleKey.RightArrow:
                        whatCase = 4;
                        moveCase(whatCase);
                        break;
                }
                key = Console.ReadKey(true);
            }
            if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
            }
        }

        public static void timer()
        {
            _cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                var watch2 = Stopwatch.StartNew();
                while (timeStop == 0)
                {
                    Console.CursorVisible = false;
                    Thread.Sleep(1); // to simulate some work
                    lock (locker)
                    {
                        Console.SetCursorPosition(Field.matrixLength + 1, 0);
                        Console.Write(watch2.Elapsed);
                    }
                    if (timeStop == 1)
                    {
                        watch2.Stop();
                        _cts.Cancel();
                    }
                }
            });
        }

        public void moveCase(int Case)
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
            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
            //
            //
            //
            //
            //
            //
            //
            //
            if (Case == 1)
            {
                if (cursorPosTop != 0)
                {
                    Check(cursorPosLeft, cursorPosTop);
                }

                if ((cursorPosLeft == field.bord + 1 && cursorPosTop == 0) ||
                    (cursorPosLeft == field.bord && cursorPosTop == 0) ||
                    (cursorPosLeft == field.bord + 2 && cursorPosTop == 0))
                {
                    timeStop = 1;
                    Console.Clear();
                    Win();
                }
            }
            else
            {
                Check(cursorPosLeft, cursorPosTop);
            }
            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
        }

        public void MoveCursor(ref int left, ref int top)
        {
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

            if (Field.Matrix[top, left] == '$')
            {
                Field.Matrix[top, left] = ' ';
                life = 1;
                Console.SetCursorPosition(Field.matrixLength + 1, 1);
                Console.Write("Life: 1");
            }

            if (Field.Matrix[top, left] == 'X')
            {
                if(life != 1)
                {
                    Defeat();
                }
                if (life == 1)
                {
                    life = 0;
                    Console.SetCursorPosition(Field.matrixLength + 1, 1);
                    Console.Write("Life: 0");
                }
            }

            lock (locker)
            {
                Console.SetCursorPosition(left, top);
            }
        }

        public void Win()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            // Console.Write($"Victory!{(char)1} ");
            Console.Clear();
            Console.Write(
                    @"
 _    _  _                                  
| |  | |(_)        _                        
| |  | | _   ____ | |_   ___    ____  _   _ 
 \ \/ / | | / ___)|  _) / _ \  / ___)| | | |
  \  /  | |( (___ | |__| |_| || |    | |_| |
   \/   |_| \____) \___)\___/ |_|     \__  |
                                     (____/ 
                                            
");
            Console.ForegroundColor = ConsoleColor.Gray; //типа всвязке
            act++;
        }

        public void Check(int x, int y)
        {
            int amount = 0;
            try
            {
                if (Field.Matrix[y - 1, x] == 'X')
                {
                    amount++;
                }
            }
            catch
            {
            }

            if (Field.Matrix[y, x + 1] == 'X')
            {
                amount++;
            }

            if (Field.Matrix[y, x - 1] == 'X')
            {
                amount++;
            }

            try
            {
                if (Field.Matrix[y + 1, x] == 'X')
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

        public void Defeat()
        {
            timeStop = 1;
            Console.Clear();
            field.Draw();
            Console.ForegroundColor = ConsoleColor.Red;
            // Console.SetBufferSize; set??
            lock (locker)
            {
                Console.SetCursorPosition(0, Field.matrixWidth + 1);
                Console.Write("Defeat.");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            act++;

            // key = Console.ReadKey(false);
            Console.WriteLine("TRY AGAIN? (yes/no)");
            Console.CursorVisible = true;
            char game = Console.ReadKey().KeyChar;
            if (game == 'y')
            {
                Console.CursorVisible = false;
                Console.Clear();
                cursorPosLeft = field.bord;
                cursorPosTop = Field.matrixWidth - 1;
                act = 0;
                rules.Define();
                field.Define();
                Define();
            }

            if (game == 'n')
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                // Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    @"
  ______                                                  
 / _____)                                                 
| /  ___   ____  ____    ____     ___  _   _  ____   ____ 
| | (___) / _  ||    \  / _  )   / _ \| | | |/ _  ) / ___)
| \____/|( ( | || | | |( (/ /   | |_| |\ V /( (/ / | |    
 \_____/  \_||_||_|_|_| \____)   \___/  \_/  \____)|_| 

                    ");
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("Something is wrong, try again");
                game = Console.ReadKey().KeyChar;
            }
            // restart?
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
