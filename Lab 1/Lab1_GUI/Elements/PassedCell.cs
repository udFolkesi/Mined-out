using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class PassedCell : Element
    {
        //public override string path 
        public override char symbol { set; get; }

        public PassedCell()
        {
            Path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/Grey_Cell.png";
        }

        public override void Define()
        {

        }
    }
}
