using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Count_Negative_Numbers_in_a_Sorted_Matrix
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
            string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
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
            //8
            int[][] grid1 = GridCreator.CreateGrid("[[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]");
            Console.WriteLine(program.CountNegatives(grid1));
            //0
            int[][] grid2 = GridCreator.CreateGrid("[[3,2],[1,0]]");
            Console.WriteLine(program.CountNegatives(grid2));
            Console.WriteLine("Hello World!");
        }
        public int CountNegatives(int[][] grid)
        {
            int cnt = 0;
            foreach (var item in grid)
            {
                int index = BinarySearch(item, 0);
                int n = item.Length - 1;
                cnt += n - index;
            }
            return cnt;
        }
        private int BinarySearch(int[] s, int t)
        {
            int left = -1;
            int right = s.Length;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (s[mid] >= t)
                    left = mid;
                else
                    right = mid;
            }
            return left;
        }
        public int CountNegativesSlow(int[][] grid)
        {
            int cnt = grid.Select(x => x.Where(y => y < 0).Count()).Sum();
            return cnt;
        }
    }
}
