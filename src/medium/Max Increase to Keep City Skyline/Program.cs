using System;
using System.Linq;

namespace Max_Increase_to_Keep_City_Skyline
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[][] grid = GridCreator.CreateGrid("[[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]");
            Console.WriteLine(program.MaxIncreaseKeepingSkyline(grid));
            Console.WriteLine("Hello World!");
        }
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int h = grid.Length;
            int w = grid[0].Length;
            int[][] fillH = new int[h][];
            int[] fillW = new int[w];
            for (int i = 0; i < h; i++)
            {
                fillH[i] = new int[w];
                int max = grid[i][0];
                for (int j = 0; j < w; j++)
                {
                    max = Math.Max(max, grid[i][j]);
                    fillW[j] = Math.Max(fillW[j], grid[i][j]);
                }
                Array.Fill(fillH[i], max);
            }
            int res = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    res += (Math.Min(fillW[j], fillH[i][j]) - grid[i][j]);
                }
            }
            return res;
        }
    }
}
