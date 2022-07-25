using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public class Result
    {
        private ResultForm ResultForm = new ResultForm();
        private GameForm gameForm = new GameForm();

        public void Win()
        {
            Files files = new Files();
            files.Save();
            ResultForm.NameResult("Easy win");
            ResultForm.Show();
            gameForm.Hide();
        }

        public void Defeat(ref Element[,] matrix)
        {
            Game.GameStopped = true;
            ResultForm.NameResult("Defeat");
            ResultForm.Show();
        }
    }
}
