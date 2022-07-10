using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    class Wall: Element
    {
        public override char symbol { get; set; }

        public override void Define()
        {
            symbol = '0';
        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write('0');
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
