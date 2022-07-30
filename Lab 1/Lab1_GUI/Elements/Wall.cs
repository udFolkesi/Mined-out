using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class Wall: Element
    {

        //public static string path 
        public override char symbol { get; set; }

        public Wall()
        {
            Path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/unnamed.png";
        }

        public override void Define()
        {

        }
    }
}
