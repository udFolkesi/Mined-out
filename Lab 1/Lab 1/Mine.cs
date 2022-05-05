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
            int x = random.Next(1, 7);
            for (int j = 0; j < x; j++)
            {
                // 11 12 13
                if (i != 0 && i != width-1)
                {
                    Field.Matrix[i, random.Next(1, length-1)] = 'X';
                }
            }
        }
    }
}
