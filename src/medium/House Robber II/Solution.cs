using System;

namespace House_Robber_II
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int res = 0;
            res = solution.Rob(new int[] { 2, 3, 2 });
            Console.WriteLine(res);
            res = solution.Rob(new int[] { 1, 2, 3, 1 });
            Console.WriteLine(res);
            res = solution.Rob(new int[] { 1 });
            Console.WriteLine(res);
            res = solution.Rob(new int[] { 1, 2 });
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
            if (nums.Length == 1)
            {
                return nums[0];
            }
            int[,] dp1 = new int[nums.Length + 1, 2];
            for (int i = 1; i < nums.Length; i++)
            {
                dp1[i, 0] = dp1[i - 1, 1] + nums[i - 1];
                dp1[i, 1] = Math.Max(dp1[i - 1, 0], dp1[i - 1, 1]);
            }
            int[,] dp2 = new int[nums.Length + 1, 2];
            for (int i = 2; i <= nums.Length; i++)
            {
                dp2[i, 0] = dp2[i - 1, 1] + nums[i - 1];
                dp2[i, 1] = Math.Max(dp2[i - 1, 0], dp2[i - 1, 1]);
            }
            int val1 = Math.Max(dp1[nums.Length - 1, 0], dp1[nums.Length - 1, 1]);
            int val2 = Math.Max(dp2[nums.Length, 0], dp2[nums.Length, 1]);
            return Math.Max(val1, val2);
        }
    }
}
