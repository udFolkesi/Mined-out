using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class WallBorder: Element
    {
        // static
        public override char symbol { get; set; }
        public static string path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/wall.png";

        public override void Define()
        {
            symbol = '#';
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write('#');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
