using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Mine
    {
        private Random random = new Random();
       
        // Console.ForegroundColor = ConsoleColor.Red;
        
        public void Traps(int i, int length, int width)
        {
            int x = random.Next(1, 1); // 6
            for (int j = 0; j < x; j++)
            {
                // 11 12 13
                if (i != 0 && i != width - 1)
                {
                    Field.Matrix[i, random.Next(1, length - 1)] = 'X';
                }
            }
        }

        public void Bonus()
        {
            int y = random.Next(1, Field.matrixWidth - 1);
            int x = random.Next(1, Field.matrixLength - 1);
            Field.Matrix[y, x] = '$';
            Console.SetCursorPosition(x, y);
            Console.Write('$');
        }
    }
}
