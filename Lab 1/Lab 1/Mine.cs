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
        // Mine mine = new Mine();
        public void Traps(int i)
        {
            int x = this.random.Next(1, 7);
            for (int j = 0; j < x; j++)
            {
                // 11 12 13
                if (i != 0 && i != 7)
                {
                    Field.Matrix[i, this.random.Next(1, 22)] = 'X';
                }
            }
        }
    }
}
