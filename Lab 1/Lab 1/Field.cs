using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Field : Element
    {
        internal static readonly char[,] Matrix = new char[8, 23];
        private Mine mine = new Mine();

        // 6, 17
        public override void Define()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 23; k++)
                {
                    if (i > 0 && i < 7 && k > 0 && k < 22)
                    {
                        Matrix[i, k] = ' ';
                    }
                    else
                    {
                        Matrix[i, k] = '#';
                    }

                    if (i == 0 && k < 13 && k > 9)
                    {
                        Matrix[i, k] = ' ';
                    }

                    if (i == 7 && k < 13 && k > 9)
                    {
                        Matrix[i, k] = ' ';
                    }

                    if (Matrix[i, k] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Matrix[i, k]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(Matrix[i, k]);
                    }
                }

                Console.WriteLine();
                this.mine.Traps(i);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    if (Matrix[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Matrix[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (Matrix[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Matrix[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (Matrix[i, j] == ' ')
                    {
                        Console.Write(Matrix[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
