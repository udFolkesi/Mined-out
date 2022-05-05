using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Program
    {
        public delegate void ThreadStart();

        internal static void Main()
        {
            Menuu menu = new Menuu();
            //Thread myThread1 = new Thread(menu.Menu);
            //Thread myThread3 = new Thread(menu.wordMenu);
            //Thread myThread2 = new Thread(menu.Define);
            //myThread1.Start();
            //myThread2.Start();
            //myThread3.Start();

            menu.Menu();
            menu.Define();
            // Field.Matrix = (char[,])ResizeArray(Field.Matrix, new char[] { 12, 2 });
            // field.Define();
            // player.Define();
        }
    }
}
