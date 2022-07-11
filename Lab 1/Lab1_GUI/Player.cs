using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public class Player: Element
    {
        public static int PosLeft = 30; // 11
        public static int PosTop = Field.MiddleOfField + 1;
        
        public override void Define()
        {

        }

        public override void Draw() // или просто static
        {

        }

        public static void WhatColor(int minesAmount)
        {
            switch (minesAmount)
            {
                case 1:
                    Form2.labelPlayer.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case 2:
                    Form2.labelPlayer.ForeColor = System.Drawing.Color.Orange;
                    break;
                case 3:
                    Form2.labelPlayer.ForeColor = System.Drawing.Color.Red;
                    break;
            }
        }
    }
}
