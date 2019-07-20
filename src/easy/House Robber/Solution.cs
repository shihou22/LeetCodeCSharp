using System;

namespace House_Robber
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int res = 0;
            // res = solution.Rob(new int[] { 1, 2, 3, 1 });
            // Console.WriteLine(res);
            // res = solution.Rob(new int[] { 2, 7, 9, 3, 1 });
            // Console.WriteLine(res);
            res = solution.Rob(new int[] { 1,  2 });
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }
        /*
        0 prev get  → contribute from 1
        1 prev skip → contribute from 0
                      contribute from 1
         */
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int[,] dp = new int[nums.Length + 1, 2];
            for (int i = 1; i <= nums.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 1] + nums[i - 1];
                dp[i, 1] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
            }
            return Math.Max(dp[nums.Length, 1],dp[nums.Length, 0]);
        }
    }
}
