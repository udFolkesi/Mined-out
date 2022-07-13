using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class Bonus: Element
    {
        public override char symbol { set; get; }
        public static string path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/bonus.png";
        public override void Define()
        {
            symbol = '$';
        }
        public static void Print()
        {
            Console.Write('$');
        }
    }
}
