using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public abstract class Element
    {
        public virtual char symbol { set; get; } 
        public abstract void Define();
        public virtual void Draw()
        {

        }// static
    }
}
