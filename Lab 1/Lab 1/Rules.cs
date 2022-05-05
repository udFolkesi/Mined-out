using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Rules : Element
    {
        public override void Define()
        {
            Console.SetCursorPosition(2, 1);
            Console.Write(@"
                                              ============= Rules ================
                                              You can use arrows(◄ ►▲▼) for move
                                              To show hint press.. 
                                              If you want to finish game press Esc
            ");
        }
    }
}
