using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class Board
    {
        protected int[,] data;
        Random random;

        public Board()
        {
            data = new int[Constants.SIZE, Constants.SIZE];
            random = new Random();
            
        }
        public int[,] Data
        {
            get
            {
                return data;
            }
            protected set
            {
                data = value;
            }
        }

        public void StartBoard()
        {

            data[random.Next(0, Constants.SIZE), random.Next(0, Constants.SIZE)] = random.Next(1, 3) * 2;
            data[random.Next(0, Constants.SIZE), random.Next(0, Constants.SIZE)] = random.Next(1, 3) * 2;

        }

        

        public bool BoardIsFull() 
        {
            for (int i = 0; i < Constants.SIZE; i++)
            {
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    if(data[i,j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool CanMakeMove()
        {
            for (int row = 0; row < Constants.SIZE; row++)
            {
                for (int col = 0; col < Constants.SIZE; col++)
                {
                    try { if (data[row, col] == data[row + 1, col]) { return true; } }
                    catch (IndexOutOfRangeException) {}
                    try { if (data[row, col] == data[row - 1, col]) { return true; } }
                    catch (IndexOutOfRangeException) { }
                    try { if (data[row, col] == data[row, col + 1]) { return true; } }
                    catch (IndexOutOfRangeException) { }
                    try { if (data[row, col] == data[row, col - 1]) { return true; } }
                    catch (IndexOutOfRangeException) { }
                }
            }
            return false;
        }
        public bool isGameOver()
        {
            if (BoardIsFull())
            {
                if (!CanMakeMove())
                {
                    
                    return true;
                }
            }
            return false;
            
        }

        public void AddRandom()
        {
            bool success = false;
            int row = -1 , col = -1;
            do
            {
                row = random.Next(0, Constants.SIZE);
                col = random.Next(0, Constants.SIZE);
                if (data[row,col] == 0)
                {
                    data[row, col] = random.Next(1, 3) * 2;
                    success = true;
                }
            } while (!success);
        }
        public int MakeMove(int[] src, int[] dst)
        {
            if (dst[0] >= Constants.SIZE || dst[1] >= Constants.SIZE || dst[0] < 0 || dst[1] < 0)
            {
                return 0;
            }

            if (data[dst[0], dst[1]] == 0)
            {
                data[dst[0], dst[1]] = data[src[0], src[1]];
                data[src[0], src[1]] = 0;
                return 0;
            }

            if (data[src[0], src[1]] == data[dst[0], dst[1]])
            {
                data[dst[0], dst[1]] *= 2;
                data[src[0], src[1]] = 0;
                return data[dst[0], dst[1]];
            }
            return 0;
        }

        public int Move(Direction direction)
        {
            int rowsChange = 0, colsChange = 0, totalPoints = 0;
            switch (direction)
            {
                case Direction.UP:
                    rowsChange--;
                    break;
                case Direction.DOWN:
                    rowsChange++;
                    break;
                case Direction.RIGHT:
                    colsChange++;
                    break;
                case Direction.LEFT:
                    colsChange--;
                    break;
            }

            for (int row = 0; row < Constants.SIZE; row++)
            {
                for (int col = 0; col < Constants.SIZE; col++)
                {
                    int currentRow = row, currentCol = col;
                    if (data[currentRow, currentCol] == 0)
                        continue;

                    while (currentRow + rowsChange >= 0 && currentRow + rowsChange < Constants.SIZE && currentCol + colsChange >= 0 && currentCol + colsChange < Constants.SIZE &&
                           data[currentRow + rowsChange, currentCol + colsChange] == 0)
                    {
                        currentRow += rowsChange;
                        currentCol += colsChange;
                    }

                    if (currentRow != row || currentCol != col)
                    {
                        totalPoints += MakeMove(new int[] { row, col }, new int[] { currentRow, currentCol });
                    }
                    else
                    {
                        totalPoints += MakeMove(new int[] { row, col }, new int[] { row + rowsChange, col + colsChange });
                    }
                }
            }
            return totalPoints;
        }

    }
}
