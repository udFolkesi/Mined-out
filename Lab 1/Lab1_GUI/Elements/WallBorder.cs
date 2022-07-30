using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class WallBorder: Element
    {
        public override string Path { set; get; }
        public override char symbol { get; set; }

        public WallBorder()
        {
            Path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/wall.png";
        }

        public override void Define()
        {

        }
    }
}
