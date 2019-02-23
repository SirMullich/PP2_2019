using System;
using System.IO;

namespace PalindromeFiles
{
    class Program
    {
        // checks if str is a palindrome
        static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            DirectoryInfo dInfo = new DirectoryInfo(@"C:\Users\daule\dev\PP2_2019\Week5\PalindromeFiles\testDirectory");
            // * is a sequence of any charachter
            var txtFiles = dInfo.GetFiles("*.txt");

            foreach(var txtFile in txtFiles)
            {
                // filename.txt
                // splict by '.' => [filename, txt]
                bool isPalindrome = IsPalindrome(txtFile.Name.ToLower().Split(".")[0]);
                Console.WriteLine("{0} is palindrome: {1}", txtFile.Name, isPalindrome);
            }
        }
    }
}
