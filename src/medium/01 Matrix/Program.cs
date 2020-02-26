using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _01_Matrix
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
        public static int[][] CreateGridJag(string a)
        {
            string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
            int[][] grid = new int[wk.Length][];
            for (int i = 0; i < wk.Length; i++)
            {
                string[] tmp = wk[i].Split(",");
                if (tmp.Length > 0 && tmp[0].Length > 0)
                    grid[i] = tmp.Select(x => int.Parse(x)).ToArray();
            }
            return grid;
        }
        public static int[,] CreateGrid(string a)
        {
            string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
            int[][] tmp = wk.Select(c => c.Split(",").Select(x => int.Parse(x)).ToArray()).ToArray();
            int[,] grid = new int[tmp.Length, tmp[0].Length];

            for (int i = 0; i < wk.Length; i++)
            {
                for (int j = 0; j < tmp[i].Length; j++)
                    grid[i, j] = tmp[i][j];
            }
            return grid;
        }
        public static char[][] CreateCharGrid(string a)
        {
            string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
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
            /*
            [[0,0,0],
            [0,1,0],
            [0,0,0]]
            */
            // var matrix1 = GridCreator.CreateGridJag("[[0,0,0], [0,1,0], [0,0,0]]");
            // var res1 = program.UpdateMatrix(matrix1);
            /*
            [[0,0,0],
            [0,1,0],
            [1,2,1]]
            */
            // var matrix2 = GridCreator.CreateGridJag("[[0,0,0], [0,1,0], [1,1,1]]");
            // var res2 = program.UpdateMatrix(matrix2);
            /*
            [[1,0,1,1,0,0,1,0,0,1]
            [0,1,1,0,1,0,1,0,1,1]
            [0,0,1,0,1,0,0,1,0,0]
            [1,0,1,0,1,1,1,1,1,1]
            [0,1,0,1,1,0,0,0,0,1]
            [0,0,1,0,1,1,1,0,1,0]
            [0,1,0,1,0,1,0,0,1,1]
            [1,0,0,0,1,2,1,1,0,1]
            [2,1,1,1,1,2,1,0,1,0]
            [3,2,2,1,0,1,0,0,1,1]]
            */
            // var matrix3 = GridCreator.CreateGridJag("[[1,0,1,1,0,0,1,0,0,1],[0,1,1,0,1,0,1,0,1,1],[0,0,1,0,1,0,0,1,0,0],[1,0,1,0,1,1,1,1,1,1],[0,1,0,1,1,0,0,0,0,1],[0,0,1,0,1,1,1,0,1,0],[0,1,0,1,0,1,0,0,1,1],[1,0,0,0,1,1,1,1,0,1],[1,1,1,1,1,1,1,0,1,0],[1,1,1,1,0,1,0,0,1,1]]");
            // var res3 = program.UpdateMatrix(matrix3);
            var matrix4 = GridCreator.CreateGridJag("[[1,1,1,1,1,0,1,0,1,0,1,0,1,1,0,1,1,1,0,1,1,1,0,1,1,1,1,0,1,1],[1,1,1,0,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0,1,0,0,1],[1,1,1,1,0,1,0,0,1,1,0,1,1,0,1,1,1,0,1,0,1,0,0,1,0,1,0,1,1,1],[1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,0,0,0,1,0,0,0,0,1,1,1,1,0,0,1],[0,1,0,0,1,0,0,1,1,1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,0,1,1,1,0,1],[1,0,1,1,1,1,0,1,0,1,0,1,1,1,0,1,1,1,1,0,1,1,0,1,0,1,0,0,1,0],[1,1,0,1,1,0,0,0,1,1,0,0,0,1,0,1,1,1,1,1,0,1,0,1,1,0,1,1,1,1],[1,1,1,0,0,0,1,0,0,1,1,1,1,1,1,1,1,0,1,0,1,0,0,1,0,0,1,0,0,1],[0,1,1,0,1,1,1,0,1,0,1,1,0,1,1,1,1,0,1,0,1,1,1,1,1,0,0,1,0,1],[1,1,0,0,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,0,0,0,0,1,1],[1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,0,1,1,1,0,1,1,0,1,0,1,1,1,0],[1,1,1,1,0,1,0,0,0,1,1,1,0,1,1,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1],[0,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,0,1,0,0,0,1],[0,1,1,0,0,0,1,1,0,0,0,0,1,1,0,1,1,1,1,1,1,1,0,1,0,0,1,1,1,1],[1,1,1,1,0,0,1,1,1,0,0,1,1,0,1,1,1,0,0,1,1,0,1,0,0,0,0,1,1,1],[1,1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,1,0,0,0],[1,1,0,1,1,0,0,1,1,0,0,1,0,1,1,1,1,0,1,1,1,0,1,1,0,1,0,1,0,1],[1,0,0,0,1,1,1,0,1,1,1,1,0,0,1,1,1,0,1,1,0,1,0,0,1,1,1,1,1,0],[1,1,0,1,0,1,1,0,0,1,1,0,0,1,0,1,1,1,1,1,1,0,1,0,0,0,0,1,1,1],[1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,1,0,0,1,1,1,0,1,1,0,1,0,1,1,0],[1,0,0,1,1,1,1,0,1,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,1,1,0,1,1],[0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,0,1,0,0,1,0,1,1,0,1,1,0,1,0,1],[1,1,1,0,1,1,1,0,0,1,0,0,0,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1],[1,1,0,0,1,1,1,1,0,0,1,0,0,1,1,0,0,1,1,1,1,0,1,1,0,1,1,1,1,1],[0,0,0,1,1,1,1,1,1,0,1,1,1,0,0,1,1,1,1,1,1,1,0,1,0,0,0,1,1,0],[1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,0,1,1,1,1,0,1,0,0,0,0,0,1,1,1],[1,0,1,1,0,1,1,0,1,0,1,1,1,0,1,1,1,1,1,0,1,0,0,1,1,0,0,1,1,0],[1,1,1,0,0,1,1,1,1,0,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1],[1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,0,0,1,1,1],[0,1,1,0,1,1,0,0,1,0,1,1,1,1,0,0,1,1,1,1,1,1,0,0,0,1,1,0,1,0]]");
            var res4 = program.UpdateMatrix(matrix4);
            Console.WriteLine("Hello World!");
        }
        public int[][] UpdateMatrix(int[][] matrix)
        {
            int h = matrix.Length;
            if (h == 0)
                return new int[][] { };
            int w = matrix[0].Length;

            int[][] visited = new int[h][];
            for (int i = 0; i < h; i++)
            {
                visited[i] = new int[w];
                Array.Fill(visited[i], int.MaxValue - 1);
            }
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        visited[i][j] = 0;
                    }
                    else
                    {
                        if (i > 0)
                            visited[i][j] = Math.Min(visited[i][j], visited[i - 1][j] + 1);
                        if (j > 0)
                            visited[i][j] = Math.Min(visited[i][j], visited[i][j - 1] + 1);
                    }
                }
            }
            for (int i = h - 1; i >= 0; i--)
            {
                for (int j = w - 1; j >= 0; j--)
                {
                    if (matrix[i][j] == 0)
                    {
                        visited[i][j] = 0;
                    }
                    else
                    {
                        if (i < h - 1)
                            visited[i][j] = Math.Min(visited[i][j], visited[i + 1][j] + 1);
                        if (j < w - 1)
                            visited[i][j] = Math.Min(visited[i][j], visited[i][j + 1] + 1);
                    }
                }
            }
            return visited;
        }
        public int[][] UpdateMatrixDFS(int[][] matrix)
        {
            int h = matrix.Length;
            if (h == 0)
                return new int[][] { };
            int w = matrix[0].Length;

            int[][] visited = new int[h][];
            for (int i = 0; i < h; i++)
            {
                visited[i] = new int[w];
                Array.Fill(visited[i], int.MaxValue);
            }

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (matrix[i][j] == 1)
                        continue;
                    visited[i][j] = 0;
                    DFS(matrix, visited, i, j, 1);
                }
            }
            return visited;
        }
        private void DFS(int[][] matrix, int[][] visited, int i, int j, int cnt)
        {
            int[] dH = new int[] { 1, 0, -1, 0 };
            int[] dW = new int[] { 0, 1, 0, -1 };
            for (int d = 0; d < 4; d++)
            {
                int wkH = dH[d] + i;
                int wkW = dW[d] + j;
                if (wkH < 0 || wkW < 0 || wkH >= matrix.Length || wkW >= matrix[0].Length)
                    continue;
                if (matrix[wkH][wkW] == 0)
                    continue;
                if (visited[wkH][wkW] <= cnt)
                    continue;
                visited[wkH][wkW] = cnt;
                DFS(matrix, visited, wkH, wkW, cnt + 1);
            }
        }
    }
}
