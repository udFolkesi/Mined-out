﻿using System;
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
            menu.Menu();
            menu.Define();

            // Field.Matrix = (char[,])ResizeArray(Field.Matrix, new char[] { 12, 2 });
        }
    }
}
