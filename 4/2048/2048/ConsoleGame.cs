using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class ConsoleGame
    {
        private Game game;
        private int highScore;
        private int gamesPlayed;
        private int totalScore;
        public ConsoleGame()
        {
            game = new Game();
            Console.WriteLine("Welcome To 2048!\n Good Luck!\n\n\n");
            main();
            highScore = 0;
            gamesPlayed = 0;
            totalScore = 0;
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

        public bool restart()
        {
            string input = "";
            do
            {
                Console.WriteLine("Do you want to go again? (y/n)");
                input = Console.ReadLine().ToLower();
            } while (input != "y" && input != "n");
            return (input.ToLower() == "y");


        }
        public void main()
        {
            bool go = true;
            while (go)
            {
                Console.WriteLine();
                Console.WriteLine("Score: " +  game.Points + "\t\t High Score:" + highScore);
                Console.WriteLine("-------------------------------------------------\n");
                game.PrintBoard();
                Console.WriteLine();
                game.Move(GetDirection());                
                if(game.Points > highScore)
                {
                    highScore = game.Points;
                }
                if (game.GetGameStatus() == GameStatus.Lose)
                {
                    totalScore += game.Points;
                    gamesPlayed++;
                    go = restart();
                    if (go)
                    {
                        game.Reset();
                    }
                    else
                    {
                        Console.WriteLine("\n\n\n");
                        Console.WriteLine("Highest Score: " + highScore);
                        Console.WriteLine("Games Played: " + gamesPlayed);
                        Console.WriteLine("Average Score: " + (totalScore / gamesPlayed));
                        Console.WriteLine("Total Points: " + totalScore);
                        Console.WriteLine("\n\n Bye!");

                    }
                }
            }

        }



    }
}
