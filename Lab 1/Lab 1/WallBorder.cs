using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class WallBorder: Element
    {
        // static
        public override char symbol { set; get; }
        public override void Define()
        {
            symbol = '#';
        }
    }
}
