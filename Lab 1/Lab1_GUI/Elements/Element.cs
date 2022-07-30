using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public abstract class Element
    {
        public static int Length = 15;
        public virtual char symbol { set; get; }
        public virtual string Path { set; get; }

        public abstract void Define();
    }
}
