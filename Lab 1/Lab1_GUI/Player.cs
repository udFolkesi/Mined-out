using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_GUI
{
    public class Player: Element
    {
        public int CursorPosLeft = 0; // 11
        public int CursorPosTop = 0;
        public override void Define()
        {

        }

        public override void Draw() // или просто static
        {

        }

        /*public static void PressKeyToMove()
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveCase((int)Direction.up, ref Field.Matrix1, ref CursorPosLeft, ref CursorPosTop);
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorPosTop == Field.MatrixWidth - 1)
                    {
                        break;
                    }

                    MoveCase((int)Direction.down, ref Field.Matrix1, ref CursorPosLeft, ref CursorPosTop);
                    break;
                case ConsoleKey.LeftArrow:
                    MoveCase((int)Direction.left, ref Field.Matrix1, ref CursorPosLeft, ref CursorPosTop);
                    break;
                case ConsoleKey.RightArrow:
                    MoveCase((int)Direction.right, ref Field.Matrix1, ref CursorPosLeft, ref CursorPosTop);
                    break;
                case ConsoleKey.W:
                    MoveCase((int)Direction.up, ref Field.Matrix2, ref CursorPosLeft2, ref CursorPosTop2);
                    break;
                case ConsoleKey.S:
                    MoveCase((int)Direction.down, ref Field.Matrix2, ref CursorPosLeft2, ref CursorPosTop2);
                    break;
                case ConsoleKey.A:
                    MoveCase((int)Direction.left, ref Field.Matrix2, ref CursorPosLeft2, ref CursorPosTop2);
                    break;
                case ConsoleKey.D:
                    MoveCase((int)Direction.right, ref Field.Matrix2, ref CursorPosLeft2, ref CursorPosTop2);
                    break;
            }

            key = Console.ReadKey(true);
        }*/

        public static void WhatColor(int minesAmount)
        {
            switch (minesAmount)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }
    }
}
