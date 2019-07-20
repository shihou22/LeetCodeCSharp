using System;
using System.Linq;

namespace Min_Cost_Climbing_Stairs
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = 0;
            res = solution.MinCostClimbingStairs(new int[] { 10, 15, 20 });
            Console.WriteLine(res);
            res = solution.MinCostClimbingStairs(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 });
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }

        public int MinCostClimbingStairs(int[] cost)
        {
            int[] dp = new int[cost.Length + 2];
            dp[0] = cost[0];
            dp[1] = cost[1];
            for (int i = 2; i < cost.Length; i++)
            {
                dp[i] = Math.Min(dp[i - 2], dp[i - 1]) + cost[i];
            }
            return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
        }

        public int MinCostClimbingStairsOld(int[] cost)
        {
            int[] dp = new int[cost.Length + 2];
            dp = Enumerable.Range(0, dp.Length).Select(_ => int.MaxValue).ToArray();
            for (int i = 0; i < 2; i++)
            {
                dp[i] = cost[i];
            }
            for (int i = 2; i <= cost.Length; i++)
            {
                if (i == cost.Length)
                {
                    dp[i] = Math.Min(dp[i], dp[i - 1]);
                    dp[i] = Math.Min(dp[i], dp[i - 2]);
                }
                else
                {
                    dp[i] = Math.Min(dp[i], dp[i - 1] + cost[i]);
                    dp[i] = Math.Min(dp[i], dp[i - 2] + cost[i]);
                }

            }
            return dp[cost.Length];
        }
    }
}
