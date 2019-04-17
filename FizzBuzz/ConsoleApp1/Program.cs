using FizzBuzz;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = System.IO.Path.GetTempFileName();
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write | FileAccess.Read);

            int min = 1;
            int max = int.MaxValue;

            Dictionary<int, String> numberNameMap = new Dictionary<int, string> { { 3, "three" }, { 5, "five"}, { 7, "seven" }, { 10, "ten" } };

            Fizz.TokenizeMultiples(min, max, numberNameMap, fs);

            using (StreamReader sr = new StreamReader(fs))
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = null;
                while ((str = sr.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
