using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class AddElements
    {
        private static Random random = new Random();
        

        // Console.ForegroundColor = ConsoleColor.Red;
        public void Traps(int i, int length, int width, ref object[,] Matrix)
        {
            int x = random.Next(1, 6); // 6
            for (int j = 0; j < x; j++)
            {
                // 11 12 13
                if (i != 0 && i != width - 1)
                {
                    Matrix[i, random.Next(1, length - 1)] = new Trap();
                }
            }
        }

        public void Wall(ref object[,] Matrix)
        {
            for (int i = 0; i < Field.matrixWidth; i++) 
            {
                int y = random.Next(1, Field.matrixWidth - 1);
                int x = random.Next(1, Field.matrixLength - 1);
                Matrix[y, x] = new Wall();
                if (Matrix == Field.Matrix2)
                {
                    Console.SetCursorPosition(50 + x, y);
                }
                else
                {
                    Console.SetCursorPosition(x, y);
                }

                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write('0');
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Bonus(ref object[,] Matrix)
        {
            int y = random.Next(1, Field.matrixWidth - 1);
            int x = random.Next(1, Field.matrixLength - 1);
            Matrix[y, x] = new Bonus();
            if (Matrix == Field.Matrix2)
            {
                Console.SetCursorPosition(50 + x, y);
            }
            else
            {
                Console.SetCursorPosition(x, y);
            }

            Console.Write('$');
        }
    }
}
