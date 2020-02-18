using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Maximal_Square
{
    class GridCreator
    {
        /*
        入力サンプル
        [[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]
        ↓
        [3,0,8,4]
        [2,4,5,7]
        [9,2,6,3]
        [0,3,1,0]
        */
        public static int[][] CreateGrid(string a)
        {
            string[] wk = a.Replace("[[", "").Replace("]]", "").Split("],[");
            int[][] grid = new int[wk.Length][];
            for (int i = 0; i < wk.Length; i++)
            {
                string[] tmp = wk[i].Split(",");
                grid[i] = tmp.Select(x => int.Parse(x)).ToArray();
            }
            return grid;
        }
        public static char[][] CreateCharGrid(string a)
        {
            string[] wk = a.Replace("[[", "").Replace("]]", "").Split("],[");
            char[][] grid = new char[wk.Length][];
            for (int i = 0; i < wk.Length; i++)
            {
                string[] tmp = wk[i].Split(",");
                grid[i] = tmp.Select(x => x[0]).ToArray();
            }
            return grid;
        }
        public static string GetResultStr(int[][] grid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            foreach (var item in grid)
            {
                builder.Append("[");
                for (int i = 0; i < item.Length; i++)
                {
                    if (i == item.Length - 1)
                        builder.Append(item[i]);
                    else
                        builder.Append(item[i]).Append(",");
                }
                builder.Append("]");
            }
            builder.Append("]");
            return builder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            char[][] arg1 = GridCreator.CreateCharGrid("[[1,0,1,0,0],[1,0,1,1,1],[1,1,1,1,1],[1,0,0,1,0]]");
            Console.WriteLine(program.MaximalSquare(arg1));
            char[][] arg2 = GridCreator.CreateCharGrid("[[1]]");
            Console.WriteLine(program.MaximalSquare(arg2));
            Console.WriteLine("Hello World!");
        }
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;
            int h = matrix.Length;
            int rows = matrix.Length;
            int cols = rows > 0 ? matrix[0].Length : 0;
            int[][] dp = new int[rows + 1][];
            Array.Fill(dp, new int[cols + 1]);

            int maxsqlen = 0;
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i][j] = Math.Min(Math.Min(dp[i][j - 1], dp[i - 1][j]), dp[i - 1][j - 1]) + 1;
                        maxsqlen = Math.Max(maxsqlen, dp[i][j]);
                    }
                }
            }
            return maxsqlen * maxsqlen;
        }
        public int MaximalSquareSlow(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;
            int h = matrix.Length;
            int w = matrix[0].Length;
            int wkMax = h * w;
            int res = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        res = Math.Max(res, maxSquare(matrix, i, j, h, w));
                        if (wkMax == res)
                            return res;
                    }
                }
            }
            return res;
        }
        private int maxSquare(char[][] square, int i, int j, int h, int w)
        {
            int cnt = 0;
            int res = 0;
            while (cnt + i < h && cnt + j < w)
            {
                for (int k = i; k <= cnt + i; k++)
                {
                    for (int l = j; l <= cnt + j; l++)
                    {
                        if (square[k][l] == '0')
                            return res;
                    }
                }
                cnt++;
                res = cnt * cnt;
            }
            return res;
        }
    }
}
