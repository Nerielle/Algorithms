using System;
using System.Collections.Generic;

namespace BiggestIsland
{
    class Program
    {
        static void Main(string[] args)
        {
           	var twodim=new int[1][];
		twodim[0]=new int []{0,0,0,0,0,0,0,0};
	
		

            var res = MaxAreaOfIsland(twodim);
            Console.WriteLine("Hello World!: " + res);
        }

        public static int MaxAreaOfIsland(int[][] grid)
        {
            var biggestArea = 0;

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        continue;
                    }
                    var area = Traverse(grid, i, j);
                    biggestArea = biggestArea < area ? area : biggestArea;
                }
            }


            return biggestArea;
        }

        public static int Traverse(int[][] grid, int ii, int jj)
        {
            var queue = new Queue<Vertex>();
            var square = 0;
            queue.Enqueue(new Vertex(ii, jj));
            grid[ii][jj] = 0;
            while (queue.Count > 0)
            {
                var vertice = queue.Dequeue();
                square++;
                var neigbhours = new List<Vertex>();
                var i = vertice.I;
                var j = vertice.J;
                var left = j - 1;
                var up = i - 1;
                var right = j + 1;
                var down = i + 1;
                if (left > -1) { neigbhours.Add(new Vertex(i, left)); }
                if (up > -1) { neigbhours.Add(new Vertex(up, j)); }
                if (right < grid[i].Length) { neigbhours.Add(new Vertex(i, right)); }
                if (down < grid.Length) { neigbhours.Add(new Vertex(down, j)); }

                //add to queue not visited neigbhours
                foreach (var n in neigbhours)
                {
                    if (grid[n.I][n.J] == 1)
                    {

                        grid[n.I][n.J] = 0;
                        queue.Enqueue(n);
                    }
                }

            }
            return square;
        }

        public struct Vertex
        {
            public int I { get; private set; }
            public int J { get; private set; }
            internal Vertex(int row, int column)
            {
                I = row;
                J = column;
            }
        }
    }
}
