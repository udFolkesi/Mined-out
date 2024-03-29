﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Result
    {
        // private Player player = new Player(); stack overflow exception???
        private Files file = new Files();
        private Field field = new Field(); // public?
        private Rules rules = new Rules();
        private object locker = new object();

        public void Win()
        {
            file.Save();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.Write(
                    @"
 _    _  _                                  
| |  | |(_)        _                        
| |  | | _   ____ | |_   ___    ____  _   _ 
 \ \/ / | | / ___)|  _) / _ \  / ___)| | | |
  \  /  | |( (___ | |__| |_| || |    | |_| |
   \/   |_| \____) \___)\___/ |_|     \__  |
                                     (____/ 
                                            
");
            Console.ForegroundColor = ConsoleColor.Gray; //типа всвязке
            throw new Exception();
            
            //Environment.Exit(0);
        }

        public void Defeat(ref Element[,] matrix)
        {
            Game.gameStopped = true;
            Console.Clear();
            field.Draw(ref Field.field1.Matrix);
            if (Menu.PlayerAmount == 2)
            {
                field.Draw(ref Field.field2.Matrix);
            }

            Console.ForegroundColor = ConsoleColor.Red;

            // Console.SetBufferSize; set??
            lock (locker)
            {
                Console.SetCursorPosition(0, Field.MatrixWidth + 1);
                Console.Write("Defeat.");
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            // key = Console.ReadKey(false);
            Console.WriteLine("TRY AGAIN? (yes/no)");
            Console.CursorVisible = true;
            char nextGame;
            bool question = true;
            Game player = new Game();
            while (question)
            {
                nextGame = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (nextGame == 'y')
                {
                    Game.gameStopped = false;
                    //File.save();
                    question = false;
                    Console.CursorVisible = false;
                    Console.Clear();
                    player.CursorPosLeft = field.MiddleOfField;
                    player.CursorPosTop = Field.MatrixWidth - 1;
                    if (Menu.PlayerAmount == 1)
                    {
                        rules.Define();
                        field.Define(ref Field.field1.Matrix);
                    }
                    else
                    {
                        player.CursorPosLeft = 50 + field.MiddleOfField;
                        player.CursorPosTop = Field.MatrixWidth - 1;
                        field.Define(ref Field.field1.Matrix);
                        field.Define(ref Field.field2.Matrix);
                    }
                    player.Start();
                    Console.WriteLine(matrix[7, 12]);
                }

                if (nextGame == 'n')
                {
                    question = false;
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(
                        @"
  ______                                                  
 / _____)                                                 
| /  ___   ____  ____    ____     ___  _   _  ____   ____ 
| | (___) / _  ||    \  / _  )   / _ \| | | |/ _  ) / ___)
| \____/|( ( | || | | |( (/ /   | |_| |\ V /( (/ / | |    
 \_____/  \_||_||_|_|_| \____)   \___/  \_/  \____)|_| 

                    ");
                    throw new Exception("end");
                    //Environment.Exit(0); // какая альтернатива
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                // Thread.Sleep(50);
            }

            // restart?
        }
    }
}
