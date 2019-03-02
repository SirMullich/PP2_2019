using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameState
    {
        Food food;
        Serpent serpent;
        Wall wall;

        private bool run;

        public GameState()
        {
            food = new Food('$', ConsoleColor.Green);
            serpent = new Serpent('o', ConsoleColor.Red);
            wall = new Wall('#', ConsoleColor.Blue);

            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }

        private void CheckFoodCatch()
        {
            if (serpent.HasCollided(food.GetFood()))
            {
                serpent.Eat(food.GetFood());
                food.Generate();
            }
        }

        public void StartGame()
        {
            run = true;
            wall.LoadLevel(1);
            wall.Draw();

            while (run)
            {
                serpent.Draw();
                food.Draw();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        // Clear before moving because if serpent moves first, we cannot clear properly
                        serpent.Clear();
                        serpent.Move(Direction.Up);
                        CheckFoodCatch();
                        break;
                    case ConsoleKey.DownArrow:
                        serpent.Clear();
                        serpent.Move(Direction.Down);
                        CheckFoodCatch();
                        break;
                    case ConsoleKey.LeftArrow:
                        serpent.Clear();
                        serpent.Move(Direction.Left);
                        CheckFoodCatch();
                        break;
                    case ConsoleKey.RightArrow:
                        serpent.Clear();
                        serpent.Move(Direction.Right);
                        CheckFoodCatch();
                        break;
                    case ConsoleKey.Escape:
                        run = false;
                        break;
                    default:
                        break;
                }
                
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(19, 19);
            Console.Write("GAME OVER");
        }
    }
}
