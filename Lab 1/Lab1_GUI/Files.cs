using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    class Files
    {
        string path = "C:/Users/USER/Desktop/GitHub/Lab 1/Lab 1/bin/Debug/saves.txt";
        private int lineCount = 0;

        public void GetInfo()
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string info = "";
                string input = null;
                while ((input = streamReader.ReadLine()) != null)
                {
                    info += $"\n{input}";
                }
                ShowInfo(info);
            }
        }

        public void ShowInfo(string info)
        {
            MessageBox.Show(info);
        }

        public void GetNum()
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                lineCount = System.IO.File.ReadAllLines(path).Length;
            }
        }

        public void Save()
        {
            GetNum();
            lineCount++;
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write($"{lineCount} Record. Field size: {Field.MatrixWidth}x{Field.MatrixLength};" +
                    $" Time: {Game.SpentTime}; Result: Victory");
                writer.WriteLine();
            }
        }
    }
}
