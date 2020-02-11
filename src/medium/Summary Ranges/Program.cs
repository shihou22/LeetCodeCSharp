using System;
using System.Collections.Generic;

namespace Summary_Ranges
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // ["0->2","4->5","7"]
            var res1 = program.SummaryRanges(new int[] { 0, 1, 2, 4, 5, 7 });
            // ["0","2->4","6","8->9"]
            var res2 = program.SummaryRanges(new int[] { 0, 2, 3, 4, 6, 8, 9 });
            Console.WriteLine("Hello World!");
        }
        public IList<string> SummaryRanges(int[] nums)
        {
            int n = nums.Length;
            IList<string> res = new List<string>();
            if (n == 0)
                return res;
            int i = 0;
            while (i < n)
            {
                int t = BinarySearch(nums, i);
                if (t != i)
                    res.Add(nums[i] + "->" + nums[t]);
                else
                    res.Add(nums[i].ToString());
                i = t + 1; ;
            }
            return res;
        }
        private int BinarySearch(int[] nums, int t)
        {
            int left = t;
            int right = nums.Length;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (mid - left != nums[mid] - nums[left])
                    right = mid;
                else
                    left = mid;
            }
            return left;
        }
        public IList<string> SummaryRangesSlow(int[] nums)
        {
            IList<string> res = new List<string>();
            if (nums.Length == 0)
                return res;
            int cnt = 0;
            string resWk = nums[0].ToString();
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1] + 1)
                {
                    if (cnt != 0)
                        resWk += "->" + nums[i - 1].ToString();
                    res.Add(resWk);
                    resWk = nums[i].ToString();
                    cnt = 0;
                }
                else
                {
                    cnt++;
                }
            }
            res.Add(resWk + ((cnt == 0) ? "" : "->" + nums[nums.Length - 1].ToString()));
            return res;
        }
    }
}
