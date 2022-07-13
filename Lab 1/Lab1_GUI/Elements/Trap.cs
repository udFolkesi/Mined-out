using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class Trap: Element
    {
        public override char symbol { get; set; }
        public static string path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/mine.png";

        public override void Define()
        {
            symbol = 'X';
        }

        public override void Draw() // или просто static
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('X');
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
