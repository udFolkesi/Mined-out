using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Field: Element
    {
        Mine mine = new Mine();
        public static char[,] matrix = new char[6, 17];
        override public void Define()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int k = 0; k < 17; k++)
                {
                    if (i > 0 && i < 5 && k > 0 && k < 16)
                    {
                        matrix[i, k] = ' ';
                    }
                    else
                    {
                        //Console.ForegroundColor = ConsoleColor.DarkBlue;
                        matrix[i, k] = '#';
                        //Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    if (i == 0 && k < 10 && k > 6)
                    {
                        matrix[i, k] = ' ';
                    }
                    if (i == 5 && k < 10 && k > 6)
                    {
                        matrix[i, k] = ' ';
                    }
                    Console.Write(matrix[i, k]);
                }
                Console.WriteLine();
                mine.traps(i);
            }
        }
        public void Draw()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    if(matrix[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(matrix[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                    } 
                }
                Console.WriteLine();
            }
        }
    }
}
