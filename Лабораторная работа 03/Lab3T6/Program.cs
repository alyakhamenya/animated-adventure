using System;
using System.IO;

namespace Lab3T6
{
    class Program6
    {
        static void Main(string[] args)
        {
            string path = @"\\DESKTOP-4DN7JDM\Users\HP\Desktop\Txt\txt.txt";

            using(StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("Царикевич Валентин 10701321");
            }
        }
    }
}          
