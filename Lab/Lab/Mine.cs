using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Mine
    {
        Random random = new Random();
        //Console.ForegroundColor = ConsoleColor.Red;
        //Mine mine = new Mine();
        public void traps(int i)
        {
            
            int x = random.Next(1, 6);
            for (int j = 0; j < x; j++)
            {
                if (i != 0 && i != 5) Field.matrix[i, random.Next(1, 16)] = 'X';
            }
            
        }
    }
}
