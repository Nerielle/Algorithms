using System;
using System.Collections.Generic;

namespace PacificFlow
{
    class Program
    {

        static void Main(string[] args)
        {
            var matrix = new int[3][];
            matrix[0] = new int[] { 1, 3, 2, 1 };
            matrix[1] = new int[] { 3, 4, 5, 2 };
            matrix[2] = new int[] { 7, 8, 9, 6 };

            Console.WriteLine("Hello World!");
        }

        public static IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    PacificFlow(matrix, i, j);
                    AtlanticFlow(matrix, i, j);
                }
            }
        }
        public static int Atlantic = -2;
        public static int Pacific = -1;
        public static int Both = -3;
        public static void PacificFlow(int[][] matrix, int i, int j)
        {
            if (matrix[i][j] == Pacific || matrix[i][j] == Both)
            {
                return;
            }
            if (i == 0 || j == 0)
            {
                matrix[i][j] = matrix[i][j] == Atlantic ? Both : Pacific;
                return;
            }
        }
        public static void AtlanticFlow(int[][] matrix, int i, int j)
        {
            if (matrix[i][j] == Atlantic || matrix[i][j] == Both)
            {
                return;
            }
            if (i == matrix.Length - 1 || j == matrix[0].Length - 1)
            {
                matrix[i][j] = matrix[i][j] == Pacific ? Both : Pacific;
                return;
            }
        }
    }
}
