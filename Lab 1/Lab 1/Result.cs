using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Result
    {
        //private Player player = new Player(); stack overflow exception???
        private Files file = new Files();
        private Field field = new Field(); // public?
        private Rules rules = new Rules();
        private object locker = new object();

        public void Win()
        {
            file.save();
            Console.ForegroundColor = ConsoleColor.Green;

            // Console.Write($"Victory!{(char)1} ");
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
            Player.act++;
            Environment.Exit(0); // лишнее
        }

        public void Defeat(ref char[,] Matrix)
        {
            Player.timeStop = 1;
            Console.Clear();
            field.Draw(ref Field.Matrix1);
            if(Menu.playerAmount == 2)
            {
                field.Draw(ref Field.Matrix2);
            }
            Console.ForegroundColor = ConsoleColor.Red;

            // Console.SetBufferSize; set??
            lock (locker)
            {
                Console.SetCursorPosition(0, Field.matrixWidth + 1);
                Console.Write("Defeat.");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Player.act++;

            // key = Console.ReadKey(false);
            Console.WriteLine("TRY AGAIN? (yes/no)");
            Console.CursorVisible = true;
            char game;
            bool flag = false;
            Player player = new Player(); 
            while (!flag)
            {
                game = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (game == 'y')
                {
                    //File.save();
                    flag = true;
                    Console.CursorVisible = false;
                    Console.Clear();
                    player.cursorPosLeft = field.bord;
                    player.cursorPosTop = Field.matrixWidth - 1;
                    Player.act = 0;
                    if(Menu.playerAmount == 1)
                    {
                        rules.Define();
                        field.Define(ref Field.Matrix1);
                    }
                    else
                    {
                        player.cursorPosLeft = 50 + field.bord;
                        player.cursorPosTop = Field.matrixWidth - 1;
                        field.Define(ref Field.Matrix1);
                        field.Define(ref Field.Matrix2);
                    }
                    player.Define();
                }
                if (game == 'n')
                {
                    flag = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    // Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(
                        @"
  ______                                                  
 / _____)                                                 
| /  ___   ____  ____    ____     ___  _   _  ____   ____ 
| | (___) / _  ||    \  / _  )   / _ \| | | |/ _  ) / ___)
| \____/|( ( | || | | |( (/ /   | |_| |\ V /( (/ / | |    
 \_____/  \_||_||_|_|_| \____)   \___/  \_/  \____)|_| 

                    ");
                    Environment.Exit(0); // extra
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            // restart?
        }
    }
}
