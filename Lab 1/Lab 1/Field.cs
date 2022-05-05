using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Field : Element
    {
        public static int matrixWidth = 8;
        public static int matrixLength = 23;
        // public int matrixLength { set; get; } = 23;
        public static char[,] Matrix = new char[100, 50];
        public int bord { set; get; } = Convert.ToInt32(Math.Floor(matrixLength / 2d) - 1);
        private Mine mine = new Mine();
        

        // 6, 17
        // abstract field
        public override void Define()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int k = 0; k < matrixLength; k++)
                {
                    if (i > 0 && i < matrixWidth - 1 && k > 0 && k < matrixLength - 1)
                    {
                        Matrix[i, k] = ' ';
                    }
                    else
                    {
                        Matrix[i, k] = '#';
                    }

                    if (i == 0 && k >= bord && k <= bord + 2)
                    {
                        Matrix[i, k] = ' ';
                    }

                    if (i == matrixWidth - 1 && k >= bord && k <= bord + 2)
                    {
                        Matrix[i, k] = ' ';
                    }

                    if (Matrix[i, k] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(Matrix[i, k]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(Matrix[i, k]);
                    }
                }

                Console.WriteLine();
                mine.Traps(i, matrixLength, matrixWidth);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (Matrix[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Matrix[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (Matrix[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(Matrix[i, j]);
                        Console.BackgroundColor = ConsoleColor.Black;
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
