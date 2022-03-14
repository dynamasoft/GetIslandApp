using System;
using System.Collections.Generic;

namespace GetIslandApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string[,] input = new string [,] {
                {"1", "1", "0", "1", "0"},
                {"0", "0", "0", "0", "0"},
                {"1", "1", "0", "0", "0"},
                {"0", "0", "0", "0", "0"}};

            var result = numIslands(input);
            Console.Write("number of island:", result);
        }       


        static int numIslands(string [,] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int gridRow = grid.GetLength(0);
            int gridCol = grid.GetLength(1);
            int num_islands = 0;

            //iterate through the row 
            for (int r = 0; r < gridRow; ++r)            
            {
                //iterate through the col  
                for (int c = 0; c < gridCol; ++c)
                {

                    if (grid[r,c] == "1")
                    {
                        ++num_islands;
                        grid[r,c] = "0"; // mark as visited

                        Queue<int> neighbors = new Queue<int>();

                        neighbors.Enqueue(r * gridCol + c);

                        while (neighbors.Count > 0)
                        {
                            int id = neighbors.Dequeue();
                            int row = id / gridCol;
                            int col = id % gridCol;
                            //check the top
                            if (row - 1 >= 0 && grid[row - 1,col] == "1")
                            {
                                neighbors.Enqueue((row - 1) * gridCol + col);
                                grid[row - 1,col] = "0";
                            }
                            //check the bottom 
                            if (row + 1 < gridRow && grid[row + 1,col] == "1")
                            {
                                neighbors.Enqueue((row + 1) * gridCol + col);
                                grid[row + 1,col] = "0";
                            }
                            //check the left side
                            if (col - 1 >= 0 && grid[row,col - 1] == "1")
                            {
                                neighbors.Enqueue(row * gridCol + col - 1);
                                grid[row,col - 1] = "0";
                            }

                            //check the right side.
                            if (col + 1 < gridCol && grid[row,col + 1] == "1")
                            {
                                neighbors.Enqueue(row * gridCol + col + 1);
                                grid[row,col + 1] = "0";
                            }
                        }
                    }
                }
            }

            return num_islands;            
        }
    }
}