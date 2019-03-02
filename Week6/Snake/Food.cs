using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Food : GameObject
    {
        private Random random;

        public Food(char character, ConsoleColor consoleColor) : base(character, consoleColor)
        {
            random = new Random();
            Generate();
        }

        public void Generate()
        {
            Point point = new Point() { X = random.Next(0, 40), Y = random.Next(0, 40) };
            body = new List<Point>() { point };
        }

        public Point GetFood()
        {
            return body[0];
        }
    }
}