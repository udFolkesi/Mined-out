using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Files
    {
        string path = "saves.txt";
        private int lineCount = 0;

        public void GetInfo()
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string input = null;
                while ((input = streamReader.ReadLine()) != null)
                {
                    ShowInfo(input);
                }

                //Console.ReadLine();
            }
        }

        public void ShowInfo(string info)
        {
            Console.WriteLine(info);
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
