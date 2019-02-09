using System;
using System.Collections.Generic;
using System.IO;

namespace FarManager
{
    enum Mode { Directory, File }

    class Folder
    {
        private int selectedIndex;
        // FileSystemInfo[] contents;
        List<FileSystemInfo> contents;
        public string FullPath { get; set; }

        public int GetSelectedIndex() { return selectedIndex; }

        // TODO fix me
        //public Folder(FileSystemInfo[] fileSystemInfos)
        //{
        //    selectedIndex = 0;
        //    // contents = fileSystemInfos;

        //    // TODO fix FullPath
        //    // FullPath = bla-bla-bla
        //}

        public Folder(DirectoryInfo directory, int index = 0)
        {
            selectedIndex = index;
            contents = new List<FileSystemInfo>();
            //contents = directory.GetFileSystemInfos();

            foreach (var fsi in directory.GetFileSystemInfos())
            {
                if (!fsi.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    contents.Add(fsi);
                }
            }
            FullPath = directory.FullName;
        }

        public void Up()
        {
            if (selectedIndex == 0)
            {
                // note: arrays start at 0, not 1
                selectedIndex = contents.Count - 1;
            } else
            {
                selectedIndex--;
            }
        }

        public void Down()
        {
            if (selectedIndex == contents.Count - 1)
            {
                selectedIndex = 0;
            } 
            else
            {
                selectedIndex++;
            }   
        }

        // get currently selected FileSystemInfo in contents
        public FileSystemInfo GetSelectedObj()
        {
            return contents[selectedIndex];
        }

        // prints contents of folder
        public void PrintFolder()
        {
            Console.Clear();

            for (int i = 0; i < contents.Count; i++)
            {
                // Setup colors for foreground and background colors

                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                
                if (contents[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else // FileInfo
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(contents[i].Name);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\daule\source\repos\programming-principles-2-2019");
            Folder folder = new Folder(dir);


            Stack<Folder> dirs = new Stack<Folder>();

            // push initial starting folder
            dirs.Push(folder);

            //DirectoryInfo dir2 = new DirectoryInfo(@"C:\Users\daule\source\repos\programming-principles-2-2019");
            //Folder f2 = new Folder(dir.GetFileSystemInfos());
            //f2.PrintFolder();

            // flag for running program
            bool run = true;

            Mode mode = Mode.Directory;

            // we refactored to Mode enum
            //bool directoryMode = true; // true = directory, false = file

            while (run)
            {
                if (mode == Mode.Directory)
                {
                    dirs.Peek().PrintFolder();
                }
                
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        dirs.Peek().Up();
                        break;
                    case ConsoleKey.DownArrow:
                        dirs.Peek().Down();
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo selected = dirs.Peek().GetSelectedObj();

                        // Different logic for directory and file
                        if (selected.GetType() == typeof(DirectoryInfo))
                        {
                            //FileSystemInfo[] fInfos = (selected as DirectoryInfo).GetFileSystemInfos();
                            //dirs.Push(new Folder(fInfos));

                            dirs.Push(new Folder(selected as DirectoryInfo));
                        }
                        else // type of selected is FileInfo
                        {
                            string fullPath = (selected as FileInfo).FullName;

                            FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                            StreamReader sr = new StreamReader(fileStream);

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Clear();
                            Console.Write(sr.ReadToEnd());

                            mode = Mode.File;
                            //directoryMode = false;

                            sr.Close();
                            fileStream.Close();
                        }

                        break;

                    case ConsoleKey.N:
                        // create a new directory
                        string currentPath = dirs.Peek().FullPath;
                        string newDirPath = currentPath + "/new-dir";

                        DirectoryInfo newDir = new DirectoryInfo(newDirPath);

                        if (!newDir.Exists) {
                            newDir.Create();
                        }

                        // refresh: pop last element of stack, and put it back
                        if (dirs.Count > 1)
                        {
                            Folder currentFolder = dirs.Pop();
                            dirs.Push(new Folder(new DirectoryInfo(currentPath), currentFolder.GetSelectedIndex()));
                        }

                        //mode = Mode.File;   // for debug
                        break;

                    case ConsoleKey.Escape:
                        if (mode == Mode.Directory) // directory
                        {
                            run = false; // stop the program
                        }
                        else // in file mode
                        {
                            mode = Mode.Directory;
                        }
                        break;

                    case ConsoleKey.Backspace:
                        if (dirs.Count > 1)
                        {
                            dirs.Pop();
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
