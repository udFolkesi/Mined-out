using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Menuu
    {
        private readonly string[] listMenu = new string[] { "Start game", "Settings", "Exit" };
        private ConsoleKeyInfo k;
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
            //Console.SetCursorPosition(5, 0){ } while true - change color

            Console.Write("**************");
            MenuAsync();
        }
        
        public async Task MenuAsync()
        {
            await Task.Run(wordMenu);
        }

        public void wordMenu()
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
        }

        // Parallel 

        public void Define()
        {
            Console.CursorVisible = false; // гасим курсор
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
                    if(y-1 > 0)
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

                    if (y + 1 < 4)
                    {
                        y++;
                    }
                    else
                    {
                        y = 3;
                    }
                }

                //Console.Clear();
                //Menu();
                if (k.Key == ConsoleKey.Enter && y == 1)
                {
                    Console.Beep();
                    Console.Clear();
                    rules.Define();
                    field.Define();
                    player.Define();
                    //time();
                }

                if (k.Key == ConsoleKey.Enter && y == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    // Console.WriteLine("Нихуя не придумал, так шо пока так");
                    Console.WriteLine("What size of field?");
                    Console.CursorVisible = true;
                    Console.Write("Width:");
                    Field.matrixWidth = int.Parse(Console.ReadLine());
                    Console.Write("Length:");
                    Field.matrixLength = int.Parse(Console.ReadLine());
                    Console.Clear();
                    // Field.Matrix
                    field.bord =Convert.ToInt32(Math.Floor(Field.matrixLength / 2d) - 1);
                    Menu();
                    Define();
                }

                if (k.Key == ConsoleKey.Enter && y == 3)
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }
            while (k.Key != ConsoleKey.Enter);
        }
    }
}
