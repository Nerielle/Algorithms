using System;
using System.Collections.Generic;
using System.Linq;
namespace PacificFlow
{
    class Program
    {

        static void Main(string[] args)
        {
            var matrix = new int[0][];
           // matrix[0] = new int[]{1};
           //  matrix[1] = new int[]{3};
            // matrix[2] = new int[]{7,8,9,6};
            
            

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
            if(matrix.Length <=1  || matrix[0].Length <=1){
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        res.Add(new List<int>(){i,j});
                    }
                }
                return res;
            }
            Dictionary<(int, int), string> visited = new Dictionary<(int, int), string>();
            for (int i = 0; i < matrix.Length ; i++)
            {
                for (int j = 0; j < matrix[0].Length ; j++)
                {
                    Bfs(matrix, i, j, visited);
                }
            }

            foreach (var item in visited)
            {
                if (item.Value.Contains(Pacific) && item.Value.Contains(Atlantic))
                {
                    res.Add(new List<int>() { item.Key.Item1, item.Key.Item2 });
                }
            }
            return res;
        }
        public static string Atlantic = "A";
        public static string Pacific = "P";


        public static void Bfs(int[][] matrix, int row, int col, Dictionary<(int, int), string> visited)
        {

            if (row < 0 || col < 0 || row >= matrix.Length || col >= matrix[0].Length || visited.ContainsKey((row, col)))
            {
                return;
            }
            if ((row == 0 && col == matrix[0].Length - 1) || (row == matrix.Length - 1 && col == 0))
            {
                visited[(row, col)] = Pacific + Atlantic;
                return;
            }


            visited.Add((row, col), "");
            if (row == 0 || col == 0)
            {
                visited[(row, col)] += Pacific;

            }
            if (row == matrix.Length - 1 || col == matrix[0].Length - 1)
            {
                visited[(row, col)] += Atlantic;

            }
            if ((row > 0 && matrix[row][col] >= matrix[row - 1][col]) || (col > 0 && matrix[row][col] >= matrix[row][col - 1]))
            {

                Bfs(matrix, row - 1, col, visited);
                Bfs(matrix, row, col - 1, visited);
                if ((row > 0 && visited[(row - 1, col)].Contains(Pacific)) || (col > 0 && visited[(row, col - 1)].Contains(Pacific)))
                {
                    visited[(row, col)] += Pacific;
                }
            }
            if ((row < matrix.Length - 1 && matrix[row][col] >= matrix[row + 1][col]) || (col < matrix[0].Length - 1 && matrix[row][col] >= matrix[row][col + 1]))
            {

                Bfs(matrix, row + 1, col, visited);
                Bfs(matrix, row, col + 1, visited);
                if ((row < matrix.Length - 1 && visited[(row + 1, col)].Contains(Atlantic)) || (col < matrix[0].Length - 1 && visited[(row, col + 1)].Contains(Atlantic)))
                {
                    visited[(row, col)] += Atlantic;
                }
            }


        }


    }
}
