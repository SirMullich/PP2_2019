using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        private void DrawAndMoveGameObjects()
        {
            while (true)
            {
                // move and other logic
                serpent.Clear();
                serpent.Move();
                CheckFoodCatch();

                // draw
                serpent.Draw();
                food.Draw();

                // This parameter defines speed of movement
                Thread.Sleep(200);
            }
        }

        public void StartGame()
        {
            run = true;
            wall.LoadLevel(1);
            // draw it only once
            wall.Draw();

            ThreadStart threadStart = new ThreadStart(DrawAndMoveGameObjects);
            Thread moveDrawThread = new Thread(threadStart);
            // run the thread
            moveDrawThread.Start();

            // balance = 10 000 -> 15 000 -> 9000

            // op1: add 5000 = (1) get balance; (2) balance = (1) + 5000

            // op2: pay 1000 (mobile) = (1) get balance; (2) balance = (1) - 1000

            while (run)
            {
                // leads to many errors
                //DrawAndMoveGameObjects();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        // set movement direction
                        serpent.ChangeDirection(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        serpent.ChangeDirection(Direction.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        serpent.ChangeDirection(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        serpent.ChangeDirection(Direction.Right);
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
