using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Player: Element
    {
        public static ConsoleKeyInfo key;
        public int cursorPosLeft = 8;
        public int cursorPosTop = 5;
        static int act = 0;
        Field field = new Field();

        override public void Define()
        {
            Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            Console.Write('0');
            Console.SetCursorPosition(cursorPosLeft, cursorPosTop);
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter && act == 0)
            {
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Write('.');
                        cursorPosTop--;
                        MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                        if (cursorPosTop != 0)
                        {
                            check(cursorPosLeft, cursorPosTop);
                        }
                        if (cursorPosLeft == 8 && cursorPosTop == 0)
                        {
                            win();
                        }
                        MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Write('.');
                        cursorPosTop++;
                        MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                        check(cursorPosLeft, cursorPosTop);
                        MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Write('.');
                        cursorPosLeft--;
                        MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                        check(cursorPosLeft, cursorPosTop);
                        MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Write('.');
                        cursorPosLeft++;
                        MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                        check(cursorPosLeft, cursorPosTop);
                        //Console.Write('0');
                        MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                        break;
                }
                key = Console.ReadKey(true);

                while (key.Key != ConsoleKey.Enter && act == 0)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Console.Write('.');
                            cursorPosTop--;
                            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                            if (cursorPosTop != 0)
                            {
                                check(cursorPosLeft, cursorPosTop);
                            }
                            if (cursorPosLeft == 8 && cursorPosTop == 0)
                            {
                                win();
                            }
                            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                            break;
                        case ConsoleKey.DownArrow:
                            Console.Write('.');
                            cursorPosTop++;
                            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                            check(cursorPosLeft, cursorPosTop);
                            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                            break;
                        case ConsoleKey.LeftArrow:
                            Console.Write('.');
                            cursorPosLeft--;
                            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                            check(cursorPosLeft, cursorPosTop);
                            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                            break;
                        case ConsoleKey.RightArrow:
                            Console.Write('.');
                            cursorPosLeft++;
                            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                            check(cursorPosLeft, cursorPosTop);
                            //Console.Write('0');
                            MoveCursor(ref cursorPosLeft, ref cursorPosTop);
                            break;
                    }
                    key = Console.ReadKey(true);
                }
            }
        }
        public void MoveCursor(ref int left, ref int top)
        {
            if (left < 1)
                left = 1;
            if (top < 1 && left == 8)
                top = 0;
            if (top < 1 && left != 8)
                top = 1;
            if (left > 15)
                left = 15;
            if (top > 4)
                top = 4;
            if (Field.matrix[top, left] == 'X')
            {
                defeat();
            }

            Console.SetCursorPosition(left, top);
        }

        public void win()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Victory!{(char)1} ");
            Console.ForegroundColor = ConsoleColor.Gray;
            act++;
        }
        public void check(int x, int y)
        {
            int amount = 0;
            if (Field.matrix[y - 1, x] == 'X')
            {
                amount++;
            }
            if (Field.matrix[y, x + 1] == 'X')
            {
                amount++;
            }
            if (Field.matrix[y, x - 1] == 'X')
            {
                amount++;
            }
            if (Field.matrix[y + 1, x] == 'X')
            {
                amount++;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(amount);
            Console.ForegroundColor = ConsoleColor.Gray;
            //ConsoleColor.Gray;
        }
        public void defeat()
        {
            Console.Clear();
            field.Draw();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Defeat.");
            Console.ForegroundColor = ConsoleColor.Gray;
            act++;
            key = Console.ReadKey(false);
        }
    }
}
