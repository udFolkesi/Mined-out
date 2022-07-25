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
        // public static Element[,] Matrix1 = new Element[40, 40];

        public Element[,] Matrix = new Element[40, 40];
        //public static Element[,] Matrix1 = new Element[40, 40];
        //public static Element[,] Matrix2 = new Element[40, 40];
        //public static char[,] Matrix2 = new char[100, 50];

        public Element this[int index1, int index2]
        {
            set { field1.Matrix[index1, index2] = value; }
            get { return field2.Matrix[index1, index2]; }
        }

        public int MiddleOfField  = Convert.ToInt32(Math.Floor(MatrixLength / 2d) - 1);

        public object Locker = new object();
        private ElementsAdder addElement = new ElementsAdder();

        public static Field field1 = new Field()
        {
            
        };
        public static Field field2 = new Field()
        {

        };

        // abstract field
        public void Define(ref Element[,] Matrix)
        {
            //Array.Clear(Matrix, 50, 50);
            lock (Locker)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < MatrixWidth; i++)
                {
                    if (Matrix == field2.Matrix)
                    {
                        Console.SetCursorPosition(50, i);
                    }

                    for (int k = 0; k < MatrixLength; k++)
                    {
                        if (i > 0 && i < MatrixWidth - 1 && k > 0 && k < MatrixLength - 1)
                        {
                            Matrix[i, k] = new Cell();
                        }
                        else
                        {
                            Matrix[i, k] = new WallBorder();
                        }

                        if (i == 0 && k >= MiddleOfField && k <= MiddleOfField + 2)
                        {
                            Matrix[i, k] = new Cell();
                        }

                        if (i == MatrixWidth - 1 && k >= MiddleOfField && k <= MiddleOfField + 2)
                        {
                            Matrix[i, k] = new Cell();
                        }

                        if (Matrix[i, k].GetType() == typeof(WallBorder))
                        {
                            WallBorder wallBorder = new WallBorder();
                            wallBorder.Draw();
                        }
                        else
                        {
                            Cell.Print();
                        }
                    }

                    Console.WriteLine();
                    addElement.AddTraps(i, MatrixLength, MatrixWidth, ref Matrix);
                }

                addElement.AddWall(ref Matrix);
                addElement.AddBonus(ref Matrix);
                
            }
            /*Field field = new Field();
            Console.WriteLine(field[0, 1]);*/
        }

        public void Draw(ref Element[,] Matrix)
        {
            Thread.Sleep(50);
            lock (Locker)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < MatrixWidth; i++)
                {
                    if (Matrix == field2.Matrix)
                    {
                        Console.SetCursorPosition(50, i);
                    }

                    for (int j = 0; j < MatrixLength; j++)
                    {
                        if (Matrix[i, j].GetType() == typeof(Trap))
                        {
                            Trap trap = new Trap();
                            trap.Draw();
                        }

                        if (Matrix[i, j].GetType() == typeof(WallBorder))
                        {
                            WallBorder wallBorder = new WallBorder();
                            wallBorder.Draw();
                        }

                        if (Matrix[i, j].GetType() == typeof(Wall))
                        {
                            Wall wall = new Wall();
                            wall.Draw();
                        }

                        if (Matrix[i, j].GetType() == typeof(Bonus))
                        {
                            Bonus.Print();
                        }

                        if (Matrix[i, j].GetType() == typeof(Cell))
                        {
                            Cell.Print();
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
