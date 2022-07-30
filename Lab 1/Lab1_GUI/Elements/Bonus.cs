using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class Bonus: Element
    {
        public override string Path { set; get; }
        public override char symbol { set; get; }

        public Bonus()
        {
            Path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/bonus.png";
        }
        
        public override void Define()
        {

        }
    }
}
