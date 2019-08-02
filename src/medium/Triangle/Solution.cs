using System;
using System.Collections.Generic;
using System.Linq;

namespace Triangle
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = 0;
            IList<IList<int>> triangle = null;
            triangle = new List<IList<int>>();
            triangle.Add(new List<int> { 2 });
            triangle.Add(new List<int> { 3, 4 });
            triangle.Add(new List<int> { 6, 5, 7 });
            triangle.Add(new List<int> { 4, 1, 8, 3 });
            res = solution.MinimumTotal(triangle);
            Console.WriteLine(res);//11
            triangle = new List<IList<int>>();
            triangle.Add(new List<int> { -1 });
            triangle.Add(new List<int> { 2, 3 });
            triangle.Add(new List<int> { 1, -1, -3 });
            res = solution.MinimumTotal(triangle);
            Console.WriteLine(res);//-1
            triangle = new List<IList<int>>();
            triangle.Add(new List<int> { -1 });
            triangle.Add(new List<int> { 3, 2 });
            triangle.Add(new List<int> { -3, 1, -1 });
            res = solution.MinimumTotal(triangle);
            Console.WriteLine(res);//-1
            Console.WriteLine("Hello World!");
        }
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            int[][] dp = new int[n][];
            dp[n - 1] = new int[triangle[n - 1].Count];
            for (int i = 0; i < dp[n - 1].Length; i++)
                dp[n - 1][i] = triangle[n - 1][i];

            for (int i = n - 2; i >= 0; i--)
            {
                IList<int> wk = triangle[i];
                dp[i] = new int[wk.Count];
                for (int j = 0; j < wk.Count; j++)
                {
                    int firstIndex = j;
                    int secondIndex = j + 1;
                    dp[i][j] = wk[j] + Math.Min(dp[i + 1][firstIndex], dp[i + 1][secondIndex]);
                }
            }
            return dp[0][0];
        }
    }
}
