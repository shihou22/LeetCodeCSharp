using System;
using System.Linq;
using System.Collections.Generic;

namespace Perfect_Squares
{
    class Solution
    {
        static void Main(string[] args)
        {

            int res = 0;
            Solution solution = new Solution();
            res = solution.NumSquares(12);
            Console.WriteLine(res);
            res = solution.NumSquares(13);
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }
        /*
        dp[1] = 1
        dp[2] = dp[2-1*1]+1
        dp[3] = dp[3-1*1]+1
        dp[4] = Min(dp[4-1*1]+1 || dp[4-2*2]+1)
        dp[5] = Min(dp[5-1*1]+1 || dp[5-2*2]+1)
        dp[6] = Min(dp[6-1*1]+1 || dp[6-2*2]+1)
        dp[13] = Min(dp[13-1*1]+1 || dp[13-2*2]+1 || dp[13-3*3]+1)
         */
        public int NumSquares(int n)
        {
            int tmp = n;
            int[] dp = Enumerable.Range(0, n + 1).Select(_ => int.MaxValue).ToArray();
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }
            return dp[n];
        }
    }
}
