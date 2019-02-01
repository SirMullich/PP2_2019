using System;

namespace ConsoleInput
{
    class Program
    {
        // before executing, 
        // change the project in "Build" section of toolbar to "ConsoleInput"
        static void Main(string[] args)
        {
            // read two lines
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            Console.WriteLine("Input is: " + input1 + " and " + input2);

            // parse input to Integers
            int number1 = int.Parse(input1);
            int number2 = int.Parse(input2);

            // add two numbers
            int sum = number1 + number2;

            Console.WriteLine("Sum of input is: " + sum);
        }
    }
}
