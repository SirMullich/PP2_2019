using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snake
{
    class Wall : GameObject
    {
        public Wall(char c, ConsoleColor consoleColor) : base(c, consoleColor)
        {
            // do nothing
        }

        public void LoadLevel(int level)
        {
            // string is immutable
            string fileName = string.Format("Levels/Level{0}.txt", level);  // ex: Levels/Level1.txt


            using (StreamReader streamReader = new StreamReader(fileName))
            {
                int row = 0;
                while(!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '#')
                        {
                            AddPoint(new Point() { X = i, Y = row });
                        }
                    }
                    row++;
                }
            }
        }
    }
}
