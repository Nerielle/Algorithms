using System;


namespace NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            var twodim = new char[4][];
            twodim[0] = new char[] { '1', '1', '0', '0', '0' };
            twodim[1] = new char[] { '1', '1', '0', '0', '0' };
            twodim[2] = new char[] { '0', '0', '1', '0', '0' };
            twodim[3] = new char[] { '0', '0', '0', '1', '1' };

            var res = NumIslands(twodim);

            Console.WriteLine("Hello World! : " + res);
        }

        public static int NumIslands(char[][] grid)
        {
            //var vertices = new List<Vertex>();
            var count = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '0')
                    {
                        continue;
                    }
                    Bfs(grid, i, j);
                    count++;
                }
            }


            return count;
        }



        private static void Bfs(char[][] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i > grid.Length - 1 || j > grid[i].Length - 1)
            {
                return;
            }

            if (grid[i][j] == '0')
            {
                return;
            }

            grid[i][j] = '0';
            Bfs(grid, i - 1, j);
            Bfs(grid, i + 1, j);
            Bfs(grid, i, j - 1);
            Bfs(grid, i, j + 1);
        }

        public class Vertex
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
