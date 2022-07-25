using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class ElementsAdder
    {
        private static Random random = new Random();

        public void AddTraps(int posX, int length, int width, ref Element[,] matrix)
        {
            int traps = random.Next(1, 6); // 6
            for (int j = 0; j < traps; j++)
            {
                // 11 12 13
                if (posX != 0 && posX != width - 1)
                {
                    matrix[posX, random.Next(1, length - 1)] = new Trap();
                }
            }
        }

        public void Place(ref Element[,] matrix, string elem)
        {
            int y = random.Next(1, Field.MatrixWidth - 1);
            int x = random.Next(1, Field.MatrixLength - 1);
            if (elem == "bonus")
            {
                matrix[y, x] = new Bonus();
            }
            else
            {
                matrix[y, x] = new Wall();
            }
        }
    }
}
