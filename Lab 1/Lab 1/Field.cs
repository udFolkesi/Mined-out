using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Field
    {
        private AddElements addElement = new AddElements();
        public static int matrixWidth = 8;
        public static int matrixLength = 23;

        // public int matrixLength { set; get; } = 23;
        public static object[,] Matrix1 = new object[40, 40];
        public static object[,] Matrix2 = new object[40, 40];
        //public static char[,] Matrix2 = new char[100, 50];

        public int middleOfField  = Convert.ToInt32(Math.Floor(matrixLength / 2d) - 1);

        public object locker = new object();

        // abstract field

        // override define
        public void Define(ref object[,] Matrix)
        {
            //Array.Clear(Matrix, 50, 50);
            lock (locker)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < matrixWidth; i++)
                {
                    if (Matrix == Matrix2)
                    {
                        Console.SetCursorPosition(50, i);
                    }

                    for (int k = 0; k < matrixLength; k++)
                    {
                        if (i > 0 && i < matrixWidth - 1 && k > 0 && k < matrixLength - 1)
                        {
                            Matrix[i, k] = ' ';
                        }
                        else
                        {
                            Matrix[i, k] = new WallBorder();
                        }

                        if (i == 0 && k >= middleOfField && k <= middleOfField + 2)
                        {
                            Matrix[i, k] = ' ';
                        }

                        if (i == matrixWidth - 1 && k >= middleOfField && k <= middleOfField + 2)
                        {
                            Matrix[i, k] = ' ';
                        }

                        if (Matrix[i, k].GetType() == typeof(WallBorder))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write('#');
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.Write(Matrix[i, k]);
                        }
                    }

                    Console.WriteLine();
                    addElement.Traps(i, matrixLength, matrixWidth, ref Matrix);
                }

                addElement.Wall(ref Matrix);
                addElement.Bonus(ref Matrix);
            }
        }

        public void Draw(ref object[,] Matrix)
        {
            Thread.Sleep(50);
            lock (locker)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < matrixWidth; i++)
                {
                    if (Matrix == Matrix2)
                    {
                        Console.SetCursorPosition(50, i);
                    }

                    for (int j = 0; j < matrixLength; j++)
                    {
                        if (Matrix[i, j].GetType() == typeof(Trap))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write('X');
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        if (Matrix[i, j].GetType() == typeof(WallBorder))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write('#');
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        if (Matrix[i, j].GetType() == typeof(Wall))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write('0');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                        if (Matrix[i, j].GetType() == typeof(Bonus))
                        {
                            Console.Write('$');
                        }

                        if (Matrix[i, j].GetType() == typeof(char))
                        {
                            Console.Write(' ');
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
