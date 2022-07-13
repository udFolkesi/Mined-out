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
        public int PosLeft = Field.MiddleOfField + 1;// 11
        public int PosTop = Field.MatrixWidth - 1;

        public int labelX = GameForm.labelPlayer.Location.X;
        public int labelY = GameForm.labelPlayer.Location.Y;

        public int Life { get; set; } = 0;

        public static Player first = new Player()
        {
            PosLeft = Field.MiddleOfField + 1,
            PosTop = Field.MatrixWidth - 1
        };
        public static Player second = new Player()
        {
            PosLeft = Field.MiddleOfField + 1,
            PosTop = Field.MatrixWidth - 1
        };

        public static void WhatColor(int minesAmount)
        {
            switch (minesAmount)
            {
                case 1:
                    GameForm.labelPlayer.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case 2:
                    GameForm.labelPlayer.ForeColor = System.Drawing.Color.Orange;
                    break;
                case 3:
                    GameForm.labelPlayer.ForeColor = System.Drawing.Color.Red;
                    break;
            }
        }

        public override void Define()
        {

        }

        public override void Draw() // или просто static
        {

        }
    }
}
