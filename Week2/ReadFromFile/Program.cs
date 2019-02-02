using System;
using System.IO;

namespace ReadFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream(@"C:\Users\daule\source\repos\programming-principles-2-2019\Week2\ReadFromFile\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileStream);

            String line = sr.ReadLine();

            String[] stringNumbers = line.Split(" ");

            int sum = 0;

            for (int i = 0; i < stringNumbers.Length; ++i)
            {
                int num = int.Parse(stringNumbers[i]);
                sum += num;
            }

            Console.WriteLine(sum);



            sr.Close();
            fileStream.Close();
        }
    }
}
