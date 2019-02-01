using System;

namespace CommandLineArgs
{
    class Program
    {
        // args - array of string
        // Project Properties -> Debug tab
        static void Main(string[] args)
        {
            for(int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine(args[i]);
            }
        }
    }
}
