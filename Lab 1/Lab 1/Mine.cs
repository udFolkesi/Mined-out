using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Mine
    {
        private static Random random = new Random();
        //private Menu menu = new Menu();

        // Console.ForegroundColor = ConsoleColor.Red;
        public void Traps(int i, int length, int width, ref char[,] Matrix)
        {
            int x = random.Next(1, 6); // 6
            for (int j = 0; j < x; j++)
            {
                // 11 12 13
                if (i != 0 && i != width - 1)
                {
                    Matrix[i, random.Next(1, length - 1)] = 'X';
                }
            }
        }

        public void Wall(ref char[,] Matrix)
        {
            for (int i = 0; i < Field.matrixWidth; i++) 
            {
                int y = random.Next(1, Field.matrixWidth - 1);
                int x = random.Next(1, Field.matrixLength - 1);
                Matrix[y, x] = '0';
                if(Matrix == Field.Matrix2)
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

        public void Bonus(ref char[,] Matrix)
        {
            int y = random.Next(1, Field.matrixWidth - 1);
            int x = random.Next(1, Field.matrixLength - 1);
            Matrix[y, x] = '$';
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
