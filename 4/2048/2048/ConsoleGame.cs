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
            Direction direction;
            string input = "";
            bool good = false;
            do
            {
                Console.WriteLine("Enter The Direction You Want (U=UP, D=DOWM, R=RIGHT, L=LEFT):");
                input = Console.ReadLine(input);
            }while(!good);
        }
        public void main()
        {
            while (game.GetGameStatus() != GameStatus.Lose)
            {
                game.PrintBoard();

            }
        }



    }
}
