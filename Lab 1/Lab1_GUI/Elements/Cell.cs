using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class Cell: Element
    {
        public override string Path { set; get; }
        public Cell()
        {
            Path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab1_GUI/images/cell.png";
            
        }
        public override void Define()
        {
            
        }
    }
}
