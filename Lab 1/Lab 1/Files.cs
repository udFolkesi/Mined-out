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
        private int num = 0;

        public void GetInfo()
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string input = null;
                while ((input = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }

                Console.ReadLine();
            }
        }

        public void GetNum()
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                /*string input = null;
                while ((input = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }*/
                string strNum = "";
                try
                {
                    strNum = File.ReadLines(path).Last();
                }
                catch
                {
                    Console.WriteLine("Проблемка");
                }

                try
                {
                    num = int.Parse(strNum.Substring(0, 2));
                }
                catch
                {
                    Console.WriteLine("Шото не так");
                }

                //int.TryParse(string.Join("", strNum.Where(c => char.IsDigit(c))), out num);
            }

            //Console.ReadLine();
        }

        public void Save()
        {
            GetNum();
            num++;
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write($"{num} Record. Field size: {Field.MatrixWidth}x{Field.MatrixLength};" +
                    $" Time: {Player._time}; Result: Victory");
                writer.WriteLine();
            }
        }
    }
}
