using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class Game
    {
        private Board board;
        private GameStatus gameStatus;
        private int points;
        
        public Game()
        {
            board = new Board();
            gameStatus = GameStatus.Idle;
            points = 0;
            board.StartBoard();
        }

        public GameStatus GetGameStatus() { return gameStatus; }
        public int Points 
        {
            get
            {
                return points;
            }
            protected set
            {
                points = value;
            }
        }
        public ConsoleColor GetColor(int num) // gets the color
        {
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Magenta };
            return colors[((int)Math.Log(num, 2) - 1) % 5];
        }

        public void PrintBoard() // prints the board nicely
        {
            Console.WriteLine(string.Format(new string('-', 29)));
            for (int i = 0; i < Constants.SIZE; i++)
            {
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    Console.Write("|");
                    if (board.Data[i, j] != 0)
                    {
                        Console.ForegroundColor = GetColor(board.Data[i, j]);
                    }
                    Console.Write(string.Format("{0,4}  ", board.Data[i, j]));
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.Write(string.Format("|\n" + new string('-', 29)));
                Console.WriteLine();
            }
        }

        public void Reset() // restarts game
        {
            board = new Board();
            points = 0;
            gameStatus = GameStatus.Idle;
            board.StartBoard();

        }

        public void Move(Direction direction) // Main Move Handler
        {
            if (gameStatus == GameStatus.Lose)
            {
                Console.WriteLine("You Lost!");
            }
            else
            {

                points += board.Move(direction, true);
                points += board.Move(direction, false); // Making sure everything move as far as it could yet not merging again

                if (board.isGameOver())
                {
                    gameStatus = GameStatus.Lose;
                    Console.WriteLine("You Lost!");
                }
                else
                {
                    if (board.BoardIsFull())
                    {
                        Console.WriteLine("Invalid Move!");
                    }
                    else
                    {
                        board.AddRandom();
                    }
                }
            }
        }


    }
}
