using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Bonus: Element
    {
        public override char symbol { set; get; }
        public override void Define()
        {
            symbol = '$';
        }
        public override void Draw()
        {
            
        }
    }
}
