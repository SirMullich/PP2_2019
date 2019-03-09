using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    abstract class GameObject
    {
        private char character;

        // accessible in child classes
        protected List<Point> body;
        private ConsoleColor consoleColor;

        public GameObject(char character, ConsoleColor consoleColor)
        {
            body = new List<Point>();
            this.character = character;
            this.consoleColor = consoleColor;
        }

        public void AddPoint(Point point)
        {
            body.Add(point);
        } 

        public void AddPoints(List<Point> points)
        {
            body.AddRange(points);
        }

        public void Draw()
        {
            foreach (var point in body)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.ForegroundColor = consoleColor;
                Console.Write(character);
            }
        }

        public void Clear()
        {
            foreach (var point in body)
            {
                Console.SetCursorPosition(point.X, point.Y);
                // чтобы слилось с background
                Console.ForegroundColor = Console.BackgroundColor;
                Console.Write(' ');
            }
        }
        
    }
}
