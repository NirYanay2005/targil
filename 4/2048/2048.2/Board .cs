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

        public void StartBoard() // starts the board with two randoms
        {
            int tmpRow = random.Next(0, Constants.SIZE), tmpCol = random.Next(0, Constants.SIZE);
            data[tmpRow, tmpCol] = random.Next(1, 3) * 2;
            do { 
                tmpRow = random.Next(0, Constants.SIZE);
                tmpCol = random.Next(0, Constants.SIZE);
            } while (data[tmpRow, tmpCol] != 0); // makes sure to not pick the same one twice
            data[tmpRow, tmpCol] = random.Next(1, 3) * 2;
        }

        

        public bool BoardIsFull() // checks if board is full
        {
            for (int row = 0; row < Constants.SIZE; row++)
            {
                for (int col = 0; col < Constants.SIZE; col++)
                {
                    if(data[row,col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool CanMakeMove() // checks if there is a possible merge
        {
            for (int row = 0; row < Constants.SIZE; row++)
            {
                for (int col = 0; col < Constants.SIZE; col++)
                {
                    try { if (data[row, col] == data[row + 1, col]) { return true; } }
                    catch (IndexOutOfRangeException) {}
                    try { if (data[row, col] == data[row - 1, col]) { return true; } }
                    catch (IndexOutOfRangeException) {}
                    try { if (data[row, col] == data[row, col + 1]) { return true; } }
                    catch (IndexOutOfRangeException) {}
                    try { if (data[row, col] == data[row, col - 1]) { return true; } }
                    catch (IndexOutOfRangeException) {}
                }
            }
            return false;
        }
        public bool isGameOver() // if board is full and cant make move = game over
        {// i chose to leave 2048 out of it beacuse i thought the game is better this way....
            return (BoardIsFull() && !CanMakeMove());
        }

        public void AddRandom() // adds random at empty
        {
            bool success = false;
            int row = -1 , col = -1;
            do
            {
                row = random.Next(0, Constants.SIZE);
                col = random.Next(0, Constants.SIZE);
                if (data[row,col] == 0) // checks if indeed empty
                {
                    data[row, col] = random.Next(1, 3) * 2;
                    success = true;
                }
            } while (!success);
        }
        public int MakeMove(int[] src, int[] dst) // actual move/merging making
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

        public int Move(Direction direction, bool doMergs) // move algorithem
        {
            int rowsChange = 0, colsChange = 0, totalPoints = 0, rowStart = 0, colStart = 0, rowEnd = Constants.SIZE, colEnd = Constants.SIZE, rowMovment = 1, colMovment = 1;
            switch (direction) // Decide how to move across board and where to move numbers
            {
                case Direction.UP:
                    rowsChange = -1;
                    rowMovment = -1;
                    rowStart = Constants.SIZE - 1;
                    rowEnd = -1;
                    break;
                case Direction.DOWN:
                    rowsChange = 1;
                    rowMovment = 1;
                    rowStart = 0;
                    rowEnd = Constants.SIZE ;
                    break;
                case Direction.LEFT:
                    colStart = 0;
                    colEnd = Constants.SIZE ;
                    colMovment = 1;
                    colsChange = -1;

                    break;
                case Direction.RIGHT:
                    colStart = Constants.SIZE - 1;
                    colEnd = -1;
                    colMovment = -1;
                    colsChange = 1;
                    break;
            }

            for (int row = rowStart; row != rowEnd; row += rowMovment) // scans the entire board
            {
                for (int col = colStart; col != colEnd; col += colMovment)
                {
                    int tmpRow = 0, tmpCol = 0, currentRow = 0, currentCol= 0;
                    tmpRow = row;
                    tmpCol = col;
                    currentRow = tmpRow;
                    currentCol = tmpCol;

                    if (data[currentRow, currentCol] == 0) // ignores empty spaces
                        continue;
                    while (currentRow + rowsChange >= 0 && currentRow + rowsChange < Constants.SIZE &&
                        currentCol + colsChange >= 0 && currentCol + colsChange < Constants.SIZE &&
                           data[currentRow + rowsChange, currentCol + colsChange] == 0) // moves numbers till blocked
                    {
                        currentRow += rowsChange;
                        currentCol += colsChange;
                    }

                    if (currentRow != tmpRow || currentCol != tmpCol) // moves if indeed they need
                    {
                        MakeMove(new int[] { tmpRow, tmpCol }, new int[] { currentRow, currentCol });
                        tmpRow = currentRow;
                        tmpCol = currentCol;
                    }
                    if (doMergs) // merging if needed
                    {
                        totalPoints += MakeMove(new int[] { tmpRow, tmpCol }, new int[] { tmpRow + rowsChange, tmpCol + colsChange });
                    }

                }
            }
            return totalPoints;
        }

    }
}
