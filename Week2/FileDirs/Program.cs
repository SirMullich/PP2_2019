using System;
using System.IO;

namespace FileDirs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dirs();
            Files();
            FileSystemInfos();
        }

        static void Dirs()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\daule\source\repos\programming-principles-2-2019\Week2");

            DirectoryInfo[] dirs = dirInfo.GetDirectories();

            foreach (var dir in dirs)
            {
                Console.WriteLine(dir.FullName);
            }

        }

        static void Files()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\daule\source\repos\programming-principles-2-2019\Week2");

            FileInfo[] files = dirInfo.GetFiles();

            foreach (var file in files)
            {
                Console.WriteLine(file.FullName);
            }
        }

        static void FileSystemInfos()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\daule\source\repos\programming-principles-2-2019\Week2");

            FileSystemInfo[] fileInfos = dirInfo.GetFileSystemInfos();

            foreach (var fileSystem in fileInfos)
            {
                Console.WriteLine(fileSystem.FullName);
            }
        }
    }
}
