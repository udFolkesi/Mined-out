using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class Trap: Element
    {
        public override string Path { set; get; }
        public override char symbol { get; set; }
        public Trap()
        {
            Path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/mine.png";
        }

        public override void Define()
        {

        }
    }
}
