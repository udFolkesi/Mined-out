using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Menu
    {
        private readonly string[] listMenu = new string[] { "Start game", "Rate", "Settings", "Exit" };
        private ConsoleKeyInfo k;
        private Field field = new Field();
        private Game player = new Game();
        private Rules rules = new Rules();
        public static int PlayerAmount = 1;

        private async Task WordMenu()
        {
            await Task.Run(() =>
            {
                Console.CursorVisible = false;

                var r = new Random();
                string line = "Menu";

                Thread.Sleep(10);
                while (!Console.KeyAvailable && k.Key != ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(5, 0);
                    foreach (char letter in line)
                    {
                        Console.ForegroundColor = (ConsoleColor)r.Next(16);
                        Console.Write(letter);
                    }

                    Console.Write('\r');
                    Thread.Sleep(150);
                }

                Console.ResetColor();
            });
        }

        public void Start()
        {
            Console.WriteLine("**** Menu ****");
            for (int i = 0; i < listMenu.Length; i++)
            {
                Console.Write($" {listMenu[i]} \n");
            }

            // Console.SetCursorPosition(5, 0){ } while true - change color
            Console.Write("**************");
            _ = WordMenu();

            Console.CursorVisible = false; // гасим курсор
            Navigate();

            while (true)
            {
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.B)
                {
                    Console.Clear();
                    Start();
                }
            }
        }

        private void Navigate()
        {
            int x = 0;
            int y = 1;
            do
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write('>');
                k = Console.ReadKey(true);

                if (k.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                    if (y - 1 > 0)
                    {
                        y--;
                    }
                    else
                    {
                        y = 1;
                    }
                }
                else if (k.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');

                    if (y + 1 < 5)
                    {
                        y++;
                    }
                    else
                    {
                        y = 4;
                    }
                }

                if (k.Key == ConsoleKey.Enter && y == 1)
                {
                    ChoosePlayerAmount();
                    // time();
                }

                if (k.Key == ConsoleKey.Enter && y == 2)
                {
                    Files files = new Files();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Clear();
                    files.GetInfo();
                    // Console.WriteLine("пока хз");
                }

                if (k.Key == ConsoleKey.Enter && y == 3)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("What size of field?");
                    Console.CursorVisible = true;
                    Console.Write("Width:");
                    Field.MatrixWidth = int.Parse(Console.ReadLine());
                    Console.Write("Length:");
                    Field.MatrixLength = int.Parse(Console.ReadLine());
                    Console.Clear();
                    field.MiddleOfField = Convert.ToInt32(Math.Floor(Field.MatrixLength / 2d) - 1);
                    Start();
                }

                if (k.Key == ConsoleKey.Enter && y == 4)
                {
                    Console.Clear();
                }
            }
            while (k.Key != ConsoleKey.Enter);
        }

        private void ChoosePlayerAmount()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1 player | 2 players");
            Console.WriteLine("--------");
            int index = 0;
            do
            {
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.RightArrow)
                {
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine("        ");
                    Console.SetCursorPosition(11, 1);
                    Console.WriteLine("---------");
                    index = 1;
                }

                if (k.Key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(11, 1);
                    Console.WriteLine("         ");
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine("--------");
                    index = 0;
                    // выбранный пункт сделать темнее
                }

                if (k.Key == ConsoleKey.Enter && index == 0)
                {
                    Console.Clear();
                    rules.Define();
                    field.Define(ref Field.Matrix1);
                    player.Start();
                    Console.Beep();
                }

                if (k.Key == ConsoleKey.Enter && index == 1)
                {
                    PlayerAmount = 2;
                    Console.Clear();
                    field.Define(ref Field.Matrix1);
                    field.Define(ref Field.Matrix2);
                    player.Start();
                }

                //перегрузку метода
            }
            while (k.Key != ConsoleKey.Enter);
        }
    }
}
