using System;
using System.Collections.Generic;
using System.IO;

namespace FizzBuzz
{
    public static class Fizz
    {
        public static void TokenizeMultiples(int min, int max, Dictionary<int, String> numberNameMap, FileStream fs)
        {
            if (min >= max)
            {
                throw new System.ArgumentException("Min parameter must be less than max Paramenter");
            }

            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);

            for (int i = min; i <= max; i++)
            {
                if (i < min)
                    break;

                string numToken = string.Empty;

                foreach (KeyValuePair<int, string> entry in numberNameMap)
                {
                    if (i % entry.Key == 0)
                    {
                        numToken = numToken + entry.Value + " ";
                    }
                }

                if (numToken == String.Empty)
                {
                    numToken = i.ToString();
                }
                sw.WriteLine("{0}", numToken);
            }

            sw.Flush();
        }
    }
}
