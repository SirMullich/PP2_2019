using System;
using System.IO;

namespace WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\daule\source\repos\programming-principles-2-2019\Week2\ReadFromFile\output.txt", FileMode.Create, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            int[] numbers = new int[] { 3, 5, 10, 14 };

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    sw.Write(number + " ");
                }
            }

            sw.Close();
            fs.Close();

      
        }
    }
}
