using System;
using System.Collections.Generic;
namespace SurroundedRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            var twodim = new char[4][];
            twodim[0] = new char[] { 'X', 'X', 'X', 'O' };
            twodim[1] = new char[] { 'X', 'O', 'X', 'O' };
            twodim[2] = new char[] { 'O', 'X', 'O', 'O' };
            twodim[3] = new char[] { 'O', 'O', 'O', 'O' };

            Solve(twodim);

            foreach (var row in twodim)
            {
                string line = String.Empty;
                for (int i = 0; i < row.Length; i++)
                {
                    line += $"{row[i]}";
                }
                Console.WriteLine(line);
            }
        }

        public static void Solve(char[][] board)
        {
            
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'X')
                    {
                        continue;
                    }
                    if (IsOnBorder(i, j, board))
                    {
                        Dfs(board, i, j);
                    }
                }
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                    if(board[i][j] == 'V'){
                        board[i][j] = 'O';
                    }
                }
            }
        }

        public static void Dfs(char[][] board, int startI, int startJ)
        {
            var jLength = board[0].Length;
            var stack = new Stack<int>() { };
            stack.Push(startI * jLength + startJ);
            while (stack.Count > 0)
            {
                var x = stack.Pop();
                var i = x / jLength;
                var j = x % jLength;
                board[i][j] = 'V';

                if (i - 1 > -1)
                {
                    ProcessNeigbhour(board, i - 1, j, stack);

                }
                if (i + 1 < board.Length)
                {
                    ProcessNeigbhour(board, i + 1, j, stack);

                }
                if (j - 1 > -1)
                {
                    ProcessNeigbhour(board, i, j - 1, stack);
                }
                if (j + 1 < jLength)
                {
                    ProcessNeigbhour(board, i, j + 1, stack);
                }

            }
        }

        private static bool IsOnBorder(int i, int j, char[][] board)
        {
            return i == 0 || j == 0 || i == board.Length - 1 || j == board[0].Length - 1;
        }

        private static void ProcessNeigbhour(char[][] board, int v, int j, Stack<int> stack)
        {
            if (board[v][j] == 'V' || board[v][j] == 'X')
            {
                return;
            }
            board[v][j] = 'V';
            stack.Push(v * board[0].Length + j);

        }
    }
}
