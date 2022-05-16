using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class File
    {
        //пээр
        //property
        string path = "saves.txt";
        public int num { get; set; } = 1;
        public void save()
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write($"{num} Record");
                writer.WriteLine();
            }
            num++;
        }
    }
}
