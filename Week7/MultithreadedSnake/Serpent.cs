using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    enum Direction
    {
        Up, Down, Right, Left
    }

    class Serpent : GameObject
    {

        private Direction movementDirection;

        public Serpent(char character, ConsoleColor consoleColor) : base(character, consoleColor)
        {
            // initialize in the middle of the game field
            AddPoint(new Point() { X = 19, Y = 19 });

            movementDirection = Direction.Up;
        }

        public void ChangeDirection(Direction newDirection)
        {
            movementDirection = newDirection;
        }

        public void Move()
        {
            // move body first
            MoveBody();

            // move HEAD according to movement direction

            switch(movementDirection)
            {
                case Direction.Up:
                    body[0].Y = body[0].Y - 1;
                    break;
                case Direction.Down:
                    body[0].Y = body[0].Y + 1;
                    break;
                case Direction.Right:
                    body[0].X = body[0].X + 1;
                    break;
                case Direction.Left:
                    body[0].X = body[0].X - 1;
                    break;
                default:
                    break;
            }
        }

        // moves whole body except HEAD
        // movement start from TAIL of serpent
        private void MoveBody()
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                // body[i] = body[i - 1];
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
        }

        // check for collision
        public bool HasCollided(Point point)
        {
            // && is logical AND
            return body[0].X == point.X && body[0].Y == point.Y;
        }

        public void Eat(Point point)
        {
            if (HasCollided(point))
            {
                Point tail = body[body.Count - 1];
                AddPoint(new Point() { X = tail.X, Y = tail.Y });
            }
        }
    }
}
