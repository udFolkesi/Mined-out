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
        public static int MatrixLength = 24;
        public Element[,] Matrix = new Element[40, 40];
        public static Field first = new Field();
        public static Field second = new Field();

        public Element this[int index1, int index2]
        {
            set { first[index1, index2] = value; }
            get { return second[index1, index2]; }
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
