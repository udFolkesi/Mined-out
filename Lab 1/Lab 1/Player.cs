using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Player : Element
    {
        private static ConsoleKeyInfo key;
        public int cursorPosLeft = 11;
        public int cursorPosTop = 7;
        private static int act = 0;
        private Field field = new Field();

        //удалить this

        // Player player = new Player(); почему с этим с не работает?
        // чтоб можно было внизу и вверху по 3 клетки были свободными
        public override void Define()
        {
            int whatCase = 0; // чет другое придумать
            Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            Check(cursorPosLeft, cursorPosTop);
            Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            key = Console.ReadKey(true);
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
                        // Console.Write('0');
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

        public void moveCase(int Case)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write('.');
            Console.BackgroundColor = ConsoleColor.Black;
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

            if (Case == 1)
            {
                if (cursorPosTop != 0)
                {
                    Check(cursorPosLeft, cursorPosTop);
                }

                if ((cursorPosLeft == 11 && cursorPosTop == 0) ||
                    (cursorPosLeft == 10 && cursorPosTop == 0) ||
                    (cursorPosLeft == 12 && cursorPosTop == 0))
                {
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
            // x=8, y=5
            // 6    17
            if (left < 1)
            {
                left = 1;
            }

            if (top < 1 && left == 11)
            {
                top = 0;
            }

            if (top < 1 && left != 11 && left != 12 && left != 10)
            {
                top = 1;
            }

            // if ((top < 1 && left) != 11||12|13)
            if (left > 21)
            {
                left = 21;
            }

            if (top == 7 && left == 10)
            {
                top = 7;
            }

            if (top > 6 && left != 10 && left != 12 && left != 11)
            {
                top = 6;
            }

            if (Field.Matrix[top, left] == 'X')
            {
                Defeat();
            }

            Console.SetCursorPosition(left, top);
        }

        public void Win()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Victory!{(char)1} ");
            Console.ForegroundColor = ConsoleColor.Gray;
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

            Console.ForegroundColor = ConsoleColor.Green;
            WhatColor(amount);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(amount);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            // ConsoleColor.Gray;
        }

        public void Defeat()
        {
            Console.Clear();
            field.Draw();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Defeat.");
            Console.ForegroundColor = ConsoleColor.Gray;
            act++;

            // key = Console.ReadKey(false);
            Console.WriteLine("TRY AGAIN?");
            Console.CursorVisible = true;
            string game = Console.ReadLine();
            if (game == "yes")
            {
                Console.Clear();
                cursorPosLeft = 11;
                cursorPosTop = 7;
                act = 0;
                field.Define();
                Define();
            }

            if (game == "no")
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
                Environment.Exit(0);
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
