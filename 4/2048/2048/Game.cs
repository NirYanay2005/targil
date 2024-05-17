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

        public void PrintBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(string.Format("{0,4} ", board.Data[i, j]));
                }
                Console.WriteLine();
            }
        }

        public void Reset()
        {
            board = new Board();
            points = 0;
            gameStatus = GameStatus.Idle;
            board.StartBoard();

        }

        public void Move(Direction direction)
        {
            if (gameStatus == GameStatus.Lose)
            {
                Console.WriteLine("You Lost!");
            }
            else
            {
                points += board.Move(direction);
                if (board.isGameOver())
                {
                    gameStatus = GameStatus.Lose;
                    Console.WriteLine("You Lost!");
                }
                else
                {
                    board.AddRandom();
                }
            }
        }


    }
}
