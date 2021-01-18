using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleMinesweeper
{
    /// <summary>
    /// Zac Almas
    /// CST-227
    /// 1/16/21
    /// This is my own code for milestone 1
    /// </summary>
    public class Board
    {
        static int size { get; set; }
        static Cell[,] grid;
        public static int difficulty { get; set; }

        //Constructor
        public Board (int sizeVal, int difficultyVal)
        {
            size = sizeVal;
            difficulty = difficultyVal;

            grid = new Cell[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    grid[x, y] = new Cell(x, y, false, false, 0);
                }
            }
        }

        /// <summary>
        /// Generates live bombs
        /// </summary>
        public void setupLiveNeighbors()
        {
            //Create a random number generator (RNG) to generate bombs
            Random rng = new Random();

            switch (difficulty)
            {
                case 1:
                    //Easy mode 15% chance will be live
                        for (int x = 0; x < size; x++)
                        {
                            for (int y = 0; y < size; y++)
                            {
                                int setBomb = rng.Next(0, 100);
                                if (setBomb <= 15)
                                {
                                    grid[x, y].isLive = true;
                                }
                            }
                        }

                    break;

                case 2:
                    //Medium mode 30% chance will be live
                        for (int x = 0; x < size; x++)
                        {
                            for (int y = 0; y < size; y++)
                            {
                                int setBomb = rng.Next(0, 100);
                                if (setBomb <= 30)
                                {
                                    grid[x, y].isLive = true;
                                }
                            }
                        }

                    break;

                case 3:
                    //Hard mode 60% will be live
                    for (int x = 0; x < size; x++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            int setBomb = rng.Next(0, 100);
                            if (setBomb <= 60)
                            {
                                grid[x, y].isLive = true;
                            }
                        }
                    }

                  break;
            }
        }

        /// <summary>
        /// Calculates nearby live bombs
        /// </summary>
        public void calculateLiveNeighbors()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (fixError(x + 1, y) && grid[x + 1, y].isLive)
                    {
                        grid[x, y].liveNeighbors++;
                    }

                    if (fixError(x + 1, y + 1) && grid[x + 1, y + 1].isLive)
                    {
                        grid[x, y].liveNeighbors++;
                    }

                    if (fixError(x + 1, y - 1) && grid[x + 1, y - 1].isLive)
                    {
                        grid[x, y].liveNeighbors++;
                    }

                    if (fixError(x - 1, y - 1) && grid[x - 1, y - 1].isLive)
                    {
                        grid[x, y].liveNeighbors++;
                    }

                    if (fixError(x, y + 1) && grid[x, y + 1].isLive)
                    {
                        grid[x, y].liveNeighbors++;
                    }

                    if (fixError(x - 1, y) && grid[x - 1, y].isLive)
                    {
                        grid[x, y].liveNeighbors++;
                    }

                    if (fixError(x - 1, y + 1) && grid[x - 1, y + 1].isLive)
                    {
                        grid[x, y].liveNeighbors++;
                    }

                    if (fixError(x - 1, y - 1) && grid[x, y - 1].isLive)
                    {
                        grid[x, y].liveNeighbors++;
                    }

                }
            }

        }

        /// <summary>
        /// Method to display the game board
        /// </summary>
        public void displayGame()
        {
            int count = 1;
            Console.WriteLine("  1    2    3    4    5    6    7    8    9    10");
            for (int x = 0; x < size; x++)
            {
                Console.WriteLine();
                for (int y = 0; y < size; y++)
                {
                    if (grid[x, y].isLive)
                    {
                        Console.Write("| *  ");
                    }
                    else
                    {
                        Console.Write("| " + grid[x, y].liveNeighbors + "  ");
                    }
                }
                Console.WriteLine("|  " + count);
                count++;
                Console.WriteLine("__________________________________________________");
            }
        }

        /// <summary>
        /// Small method that fixes a index out of bounds error in the check for live neighbors method
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Boolean fixError(int x, int y)
        {
            return (x >= 0 && x < size && y >= 0 && y < size);
        }

    }
}
