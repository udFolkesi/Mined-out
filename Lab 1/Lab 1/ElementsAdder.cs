using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class ElementsAdder
    {
        private static Random random = new Random();
        // Console.ForegroundColor = ConsoleColor.Red;
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

        public void AddWall(ref Element[,] matrix)
        {
            for (int i = 0; i < Field.MatrixWidth; i++)
            {
                Place(ref matrix, "wall");
                Wall wall = new Wall();
                wall.Draw();
            }
        }

        public void AddBonus(ref Element[,] matrix)
        {
            Place(ref matrix, "bonus");
            Console.Write('$');
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

            if (matrix == Field.Matrix2)
            {
                Console.SetCursorPosition(50 + x, y);
            }
            else
            {
                Console.SetCursorPosition(x, y);
            }
        }
    }
}
