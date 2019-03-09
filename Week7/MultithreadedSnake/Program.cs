using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestFood();
            //TestWall();


            GameState gameState = new GameState();
            gameState.StartGame();
        }

        static void TestFood()
        {
            Food food = new Food('$', ConsoleColor.Red);
            food.Draw();

            Console.ReadKey();

            food.Clear();
        }

        static void TestWall()
        {
            Wall wall = new Wall('#', ConsoleColor.Green);
            wall.LoadLevel(1);

            wall.Draw();
        }

    }
}
