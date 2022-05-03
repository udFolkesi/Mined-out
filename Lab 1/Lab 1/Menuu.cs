using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Menuu
    {
        private readonly string[] listMenu = new string[] { "Start game", "Settings", "Exit" };
        private Field field = new Field();
        private Player player = new Player();
        private Rules rules = new Rules();

        public void Menu()
        {
            Console.WriteLine("**** Menu ****");
            for (int i = 0; i < listMenu.Length; i++)
            {
                Console.Write($" {listMenu[i]} \n");
            }

            Console.Write("**************");
        }

        public void Define()
        {
            Console.CursorVisible = false; // гасим курсор
            int x = 0;
            int y = 1;
            ConsoleKeyInfo k;
            do
            {
                Console.SetCursorPosition(x, y);
                Console.Write('>');
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.UpArrow)
                {
                    y--;
                }
                else if (k.Key == ConsoleKey.DownArrow)
                {
                    y++;
                }

                Console.Clear();
                Menu();
                if (k.Key == ConsoleKey.Enter && y == 1)
                {
                    Console.Beep();
                    Console.Clear();
                    rules.Define();
                    field.Define();
                    player.Define();
                }

                if (k.Key == ConsoleKey.Enter && y == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Нихуя не придумал, так шо пока так");
                }

                if (k.Key == ConsoleKey.Enter && y == 3)
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }
            while (k.Key != ConsoleKey.Enter);
        }

        public void DiffColors()
        {
            Console.CursorVisible = false;
            var r = new Random();
            string line = "Hello World!";
            while (true)
            {
                foreach (char letter in line)
                {
                    Console.ForegroundColor = (ConsoleColor)r.Next(16);
                    Console.Write(letter);
                }

                Console.Write('\r');
                Thread.Sleep(100);
            }

            // Console.ResetColor();
        }
    }
}
