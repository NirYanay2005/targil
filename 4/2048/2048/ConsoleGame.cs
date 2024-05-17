using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class ConsoleGame
    {
        private Game game;
        
        public ConsoleGame()
        {
            game = new Game();
            Console.WriteLine("Welcome To 2048!\n Good Luck!\n\n\n");
            main();
        }

        public Direction GetDirection()
        {
            string input = "";
            while (true)
            {
                Console.WriteLine("Enter The Direction You Want (U=UP, D=DOWM, R=RIGHT, L=LEFT):");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "u":
                        return Direction.UP;
                    case "d":
                        return Direction.DOWN;
                    case "r":
                        return Direction.RIGHT;
                    case "l":
                        return Direction.LEFT;
                    default:
                        Console.WriteLine("Please Enter a Vaild Letter!");
                        break;
                }
            }
        }

        public void main()
        {
            while (game.GetGameStatus() != GameStatus.Lose)
            {
                Console.WriteLine("Score: ", game.Points);
                game.PrintBoard();
                game.Move(GetDirection());                
            }
        }



    }
}
