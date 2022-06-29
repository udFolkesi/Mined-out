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
        public static int MatrixWidth = 8;
        public static int MatrixLength = 23;

        // public int matrixLength { set; get; } = 23;
        public static object[,] Matrix1 = new object[40, 40];
        public static object[,] Matrix2 = new object[40, 40];
        //public static char[,] Matrix2 = new char[100, 50];

        public int MiddleOfField  = Convert.ToInt32(Math.Floor(MatrixLength / 2d) - 1);

        public object Locker = new object();
        private AddElements addElement = new AddElements();

        // abstract field

        // override define
        public void Define(ref object[,] Matrix)
        {
            //Array.Clear(Matrix, 50, 50);
            lock (Locker)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < MatrixWidth; i++)
                {
                    if (Matrix == Matrix2)
                    {
                        Console.SetCursorPosition(50, i);
                    }

                    for (int k = 0; k < MatrixLength; k++)
                    {
                        if (i > 0 && i < MatrixWidth - 1 && k > 0 && k < MatrixLength - 1)
                        {
                            Matrix[i, k] = ' ';
                        }
                        else
                        {
                            Matrix[i, k] = new WallBorder();
                        }

                        if (i == 0 && k >= MiddleOfField && k <= MiddleOfField + 2)
                        {
                            Matrix[i, k] = ' ';
                        }

                        if (i == MatrixWidth - 1 && k >= MiddleOfField && k <= MiddleOfField + 2)
                        {
                            Matrix[i, k] = ' ';
                        }

                        if (Matrix[i, k].GetType() == typeof(WallBorder))
                        {
                            WallBorder.Draw();
                        }
                        else
                        {
                            Console.Write(Matrix[i, k]);
                        }
                    }

                    Console.WriteLine();
                    addElement.AddTraps(i, MatrixLength, MatrixWidth, ref Matrix);
                }

                addElement.AddWall(ref Matrix);
                addElement.AddBonus(ref Matrix);
            }
        }

        public void Draw(ref object[,] Matrix)
        {
            Thread.Sleep(50);
            lock (Locker)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < MatrixWidth; i++)
                {
                    if (Matrix == Matrix2)
                    {
                        Console.SetCursorPosition(50, i);
                    }

                    for (int j = 0; j < MatrixLength; j++)
                    {
                        if (Matrix[i, j].GetType() == typeof(Trap))
                        {
                            Trap.Draw();
                        }

                        if (Matrix[i, j].GetType() == typeof(WallBorder))
                        {
                            WallBorder.Draw();
                        }

                        if (Matrix[i, j].GetType() == typeof(Wall))
                        {
                            Wall.Draw();
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
