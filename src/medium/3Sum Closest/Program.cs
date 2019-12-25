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
