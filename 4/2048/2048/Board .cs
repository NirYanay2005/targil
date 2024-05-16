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
            data = new int[4, 4];
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

            data[random.Next(0, 4), random.Next(0, 4)] = random.Next(1, 3) * 2;
            data[random.Next(0, 4), random.Next(0, 4)] = random.Next(1, 3) * 2;

        }

        

        private bool BoardIsFull() 
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(data[i,j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool CanMakeMove()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    try { if (data[i, j] == data[i + 1, j]) { return true; } }
                    catch (IndexOutOfRangeException) {}
                    try { if (data[i, j] == data[i - 1, j]) { return true; } }
                    catch (IndexOutOfRangeException) { }
                    try { if (data[i, j] == data[i, j + 1]) { return true; } }
                    catch (IndexOutOfRangeException) { }
                    try { if (data[i, j] == data[i, j - 1]) { return true; } }
                    catch (IndexOutOfRangeException) { }
                }
            }
            return false;
        }
        public bool isGameOver()
        {
            if (BoardIsFull())
            {
                if (CanMakeMove())
                {
                    return true;
                }
            }
            return false;
        }

        private void AddRandom()
        {
            bool success = false;
            int row = -1 , col = -1;
            do
            {
                row = random.Next(0, 4);
                col = random.Next(0, 4);
                if (data[row,col] != 0)
                {
                    data[row, col] = random.Next(1, 2) * 2;
                    success = true;
                }
            } while (!success);
        }
        public int MakeMove(int[] src, int[] dst)
        {
            if (dst[0] >= 4 || dst[1] >= 4 || dst[0] < 0 || dst[1] < 0)
            {
                return 0;
            }
            if (data[dst[0], dst[1]] != 0)
            {
                if (data[src[0], src[1]] == data[dst[0], dst[1]])
                {
                    data[dst[0], dst[1]] *= 2;
                    data[src[0], src[1]] = 0;
                    return data[dst[0], dst[1]];
                }
            }
            if (data[src[0], src[1]] != 0)
            {
                data[dst[0], dst[1]] = data[src[0], src[1]];
                data[src[0], src[1]] = 0;
                return 0;
            }
            return -1000; // NOT SUPOSE TO HAPPEN
        }

        public int Move(Direction direction)
        {
            int rowsChange = 0, colsChange = 0, totalPoints = 0;
            switch (direction)
            {
                case Direction.UP:
                    rowsChange++;
                    break;
                case Direction.DOWN:
                    rowsChange--;
                    break;
                case Direction.RIGHT:
                    colsChange++;
                    break;
                case Direction.LEFT:
                    colsChange--;
                    break;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (data[i, j] != 0)
                    {
                        int[] src = { i, j }, dst = { i + rowsChange, j + colsChange };
                        totalPoints += MakeMove(src, dst);
                    }
                }
            }
            return totalPoints;
        }

    }
}
