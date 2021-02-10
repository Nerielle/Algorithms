using System;
using System.Collections.Generic;

namespace PacificFlow
{
    class Program
    {
        /*
        Given the following 5x5 matrix:

         Pacific ~   ~   ~   ~   ~ 
             ~  1   2   2   3  (5) *
             ~  3   2   3  (4) (4) *
             ~  2   4  (5)  3   1  *
             ~ (6) (7)  1   4   5  *
             ~ (5)  1   1   2   4  *
             *   *   *   *   * Atlantic

        Return:

        [[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]] (positions with parentheses in above matrix).
        */

        static void Main(string[] args)
        {
            var matrix = new int[5][];
            matrix[0] = new int[] { 1, 2, 2, 3, 5 };
            matrix[1] = new int[] { 3, 2, 3, 4, 4 };
            matrix[2] = new int[] { 2, 4, 5, 3, 1 };
            matrix[3] = new int[] { 6, 7, 1, 4, 5 };
            matrix[4] = new int[] { 5, 1, 1, 2, 4 };


            var res = PacificAtlantic(matrix);
            Console.WriteLine("Count! " + res.Count);
            foreach (var vert in res)
            {
                Console.WriteLine("v " + vert[0] + vert[1] + "num: " + matrix[vert[0]][vert[1]]);
            }

        }

        public static IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return res;
            }


            Dictionary<(int, int), string> visited = new Dictionary<(int, int), string>();
            PacificFlow(matrix, visited);
            AtlanticFlow(matrix, visited);

            foreach (var item in visited)
            {
                var row = item.Key.Item1;
                var col = item.Key.Item2;
                if (item.Value.Contains(Pacific) && item.Value.Contains(Atlantic))
                {
                    res.Add(new List<int>() { row, col });
                }

            }
            return res;
        }
        public static string Atlantic = "A";
        public static string Pacific = "P";

        public static void PacificFlow(int[][] matrix, Dictionary<(int, int), string> visited)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Bfs(matrix, i, j, visited, Pacific);
                }
            }
        }
        public static void AtlanticFlow(int[][] matrix, Dictionary<(int, int), string> visited)
        {

            for (int j = matrix[0].Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    Bfs(matrix, i, j, visited, Atlantic);
                }
            }
        }
        public static void Bfs(int[][] matrix, int row, int col, Dictionary<(int, int), string> visited, string flow)
        {
            if (visited.ContainsKey((row, col)) && visited[(row, col)].Contains(flow))
            {
                return;
            }
            var leftFlow = col != 0 && visited.ContainsKey((row, col - 1)) ? visited[(row, col - 1)] : "";
            var upFlow = row != 0 && visited.ContainsKey((row - 1, col)) ? visited[(row - 1, col)] : "";
            var downFlow = row != matrix.Length - 1 && visited.ContainsKey((row + 1, col)) ? visited[(row + 1, col)] : "";
            var rightFlow = col != matrix[0].Length - 1 && visited.ContainsKey((row, col + 1)) ? visited[(row, col + 1)] : "";

            var left = leftFlow.Contains(flow) && matrix[row][col] >= matrix[row][col - 1];
            var up = upFlow.Contains(flow) && matrix[row][col] >= matrix[row - 1][col];
            var right = rightFlow.Contains(flow) && matrix[row][col] >= matrix[row][col + 1];
            var down = downFlow.Contains(flow) && matrix[row][col] >= matrix[row + 1][col];
            var isPacificShore = flow == Pacific && (row == 0 || col == 0);
            var isAtlanticShore = flow == Atlantic && (row == matrix.Length - 1 || col == matrix[0].Length - 1);

            if (isPacificShore || isAtlanticShore || left || up || right || down)
            {
                if (visited.ContainsKey((row, col)))
                {
                    visited[(row, col)] += flow;
                }
                else
                {
                    visited.Add((row, col), flow);
                }
            }
            if (visited.ContainsKey((row, col)) && visited[(row, col)].Contains(flow))
            {
                if (col != 0 && !leftFlow.Contains(flow) && matrix[row][col] <= matrix[row][col - 1])
                {
                    Bfs(matrix, row, col - 1, visited, flow);
                }
                if (row != 0 && !upFlow.Contains(flow) && matrix[row][col] <= matrix[row - 1][col])
                {
                    Bfs(matrix, row - 1, col, visited, flow);
                }
                if (row != matrix.Length - 1 && !downFlow.Contains(flow) && matrix[row][col] <= matrix[row + 1][col])
                {
                    Bfs(matrix, row + 1, col, visited, flow);
                }
                if (col != matrix[0].Length - 1 && !rightFlow.Contains(flow) && matrix[row][col] <= matrix[row][col + 1])
                {
                    Bfs(matrix, row, col + 1, visited, flow);
                }
            }


        }

        private static void ProcessNeighbour(int[][] matrix, int row, int col, Dictionary<(int, int), string> visited, string flow, List<(int, int)> neighbours)
        {
            Bfs(matrix, row, col, visited, flow);
            neighbours.Add((row, col));
        }
    }
}
