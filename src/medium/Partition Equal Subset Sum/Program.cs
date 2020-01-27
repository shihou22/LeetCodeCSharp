using System;
using System.Linq;

namespace Partition_Equal_Subset_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CanPartitionDP(new int[] { 3, 3, 3, 4, 5 }));//true
            Console.WriteLine(program.CanPartitionDP(new int[] { 1, 5, 11, 5 }));//true
            Console.WriteLine(program.CanPartitionDP(new int[] { 1, 2, 3, 5 }));//false
            Console.WriteLine("Hello World!");
        }
        public bool CanPartition(int[] nums)
        {
            int total = 0;
            int max = int.MinValue;
            foreach (var num in nums)
            {
                total += num;
                max = Math.Max(max, num);
            }
            if ((total & 1) == 1)
                return false;
            int half = total >> 1;
            if (half < max)
                return false;
            return FindTarget(nums, 0, half);
        }

        private bool FindTarget(int[] nums, int index, int sum)
        {
            if (index >)
                return false;
            int delta = sum - nums[index];
            if (delta == 0)
                return true;
            if (delta > 0)
            {
                for (int i = index; i < nums.Length; i++)
                    if (FindTarget(nums, i, delta))
                        return true;
                return false;
            }

            return FindTarget(nums, index - 1, sum);
        }
        public bool CanPartitionDP(int[] nums)
        {
            int baseNum = 0;
            foreach (var item in nums)
            {
                baseNum += item;
            }
            int n = nums.Length;
            if (baseNum % 2 == 1)
                return false;
            int[][] dp = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[baseNum + 1];
            }
            for (int i = 1; i <= n; i++)
            {
                dp[i][nums[i - 1]] = 1;
                for (int j = 1; j < i; j++)
                {
                    // for (int k = 0; k < dp[j].Length; k++)
                    for (int k = 0; ((nums[j] + k) * 2) <= baseNum; k++)
                    {
                        if (j == i || dp[j][k] == 0)
                            continue;
                        int max = nums[j] + k;
                        if (max * 2 <= baseNum)
                            dp[i][max] = 1;
                        else
                            break;
                    }
                }
            }
            return dp[n][baseNum / 2] == 1;
        }
        public bool CanPartitionDFSTLE(int[] nums)
        {
            long baseNum = 0;
            foreach (var item in nums)
            {
                baseNum += item;
            }
            if (baseNum % 2 == 1)
                return false;
            return DFS(nums, nums.Length, 0, 0, baseNum, baseNum / 2);
        }
        private bool DFS(int[] nums, int n, int curr, long currNum, long total, long baseNum)
        {
            if (baseNum <= currNum)
                return total - currNum == baseNum;
            if (curr >= n)
                return baseNum == currNum;

            return DFS(nums, n, curr + 1, currNum, total, baseNum)
            || DFS(nums, n, curr + 1, currNum + nums[curr], total, baseNum);
        }
    }
}
