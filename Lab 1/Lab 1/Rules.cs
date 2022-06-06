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
            Console.SetCursorPosition(2, 0);
            Console.Write(@"
                                              ============= Rules ================
                                              You can use arrows(◄ ►▲▼) for move
                                              Restart - press R
                                              To show hint press.. 
                                              Additional life - $
                                              Back - press B
                                              If you want to finish game press Esc
            ");
        }
    }
}
