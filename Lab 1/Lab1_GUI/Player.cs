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

        public int labelX = GameForm.labelPlayer1.Location.X;
        public int labelY = GameForm.labelPlayer1.Location.Y;

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

        public static void WhatColor(int minesAmount, Label labelPlayer)
        {
            switch (minesAmount)
            {
                case 1:
                    labelPlayer.ForeColor = System.Drawing.Color.Yellow;
                    break;
                case 2:
                    labelPlayer.ForeColor = System.Drawing.Color.Orange;
                    break;
                case 3:
                    labelPlayer.ForeColor = System.Drawing.Color.Red;
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
