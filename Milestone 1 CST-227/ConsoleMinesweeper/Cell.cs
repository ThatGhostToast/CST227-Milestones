using System;
using System.Reflection;

namespace ConsoleMinesweeper
{
    /// <summary>
    /// Zac Almas
    /// CST-227
    /// 1/16/21
    /// This is my own code for milestone 1
    /// </summary>
    public class Cell
    {
        //Define attributes
        public int row { get; set; } 
        public int column { get; set; }
        public bool visited { get; set; } 
        public bool isLive { get; set; } 
        public int liveNeighbors { get; set; }

        public Cell(int row, int column, bool visited, bool isLive, int liveNeighbors)
        {
            row = -1;
            column = -1;
            visited = false;
            isLive = false;
            liveNeighbors = 0;
        }
    }

}
