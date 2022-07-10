using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public class Field
    {
        public static int MatrixWidth = 15;
        public static int MatrixLength = 23;

        // public int matrixLength { set; get; } = 23;
        // public static Element[,] Matrix1 = new Element[40, 40];
        public static Element[,] Matrix1 = new Element[40, 40];
        public static Element[,] Matrix2 = new Element[40, 40];
        //public static char[,] Matrix2 = new char[100, 50];
        public int[] MyArray = new int[] { 1, 2, 3 };
        public Element this[int index1, int index2]
        {
            set { Matrix1[index1, index2] = value; }
            get { return Matrix1[index1, index2]; }
        }

        public static int MiddleOfField  = Convert.ToInt32(Math.Floor(MatrixLength / 2d) - 1);

        private ElementsAdder elementsAdder = new ElementsAdder();

        public void Define(ref Element[,] Matrix)
        {
            
            //form2.metod();
            for (int i = 0; i < MatrixWidth; i++)
            {
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

                    if (i == MatrixWidth - 1 && k == MiddleOfField + 1)
                    {
                        Matrix[i, k] = new Player();
                    }
                }

                elementsAdder.AddTraps(i, MatrixLength, MatrixWidth, ref Matrix);
            }

            elementsAdder.Place(ref Matrix, "bonus");
            for (int i = 0; i < MatrixWidth; i++)
            {
                elementsAdder.Place(ref Matrix, "wallBorder");
            }
        }
    }
}
