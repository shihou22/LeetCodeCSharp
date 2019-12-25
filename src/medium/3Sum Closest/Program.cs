using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum_Closest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            var res1 = program.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1);
            Console.WriteLine(res1);
            Console.WriteLine("Hello World!");
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int minClose = int.MaxValue;
            int minDiff = 0;
            //初期値を0->最後から三番目まで調べる
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[left] + nums[right] + nums[i];
                    int close = Math.Abs(target - sum);
                    if (sum == target)
                    {
                        return sum;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                    if (close < minClose)
                    {
                        minClose = close;
                        minDiff = sum;
                    }
                }

            }
            return minDiff;
        }
        public int ThreeSumClosestRecursive(int[] nums, int target)
        {
            helper(nums, 0, 0, 0);
            List<int> res = wk.ToList();
            int min1 = res.Min(c => Math.Abs(c - target));
            return res.First(c => Math.Abs(c - target) == min1);
        }
        private void helper(int[] nums, int curr, int sum, int cnt)
        {
            if (nums.Length == curr || cnt > 3)
            {
                if (cnt == 3)
                    wk.Add(sum);
                return;
            }

            helper(nums, curr + 1, sum + nums[curr], cnt + 1);
            helper(nums, curr + 1, sum, cnt);
        }
        private HashSet<int> wk = new HashSet<int>();
    }
}
