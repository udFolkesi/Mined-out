using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Trap: Element
    {
        public override char symbol { get; set; }

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
