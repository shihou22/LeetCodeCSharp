using System;
using System.Linq;
using System.Collections.Generic;

namespace How_Many_Numbers_Are_Smaller_Than_the_Current_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int[] sortedNums = new int[nums.Length];
            Array.Copy(nums, sortedNums, nums.Length);
            Array.Sort(sortedNums);

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = BinarySearch(sortedNums, nums[i]);
            }
            return nums;
        }
        private int BinarySearch(int[] sortedNums, int target)
        {
            int left = -1;
            int right = sortedNums.Length;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (target <= sortedNums[mid])
                    right = mid;
                else
                    left = mid;
            }
            return right;
        }
        public int[] SmallerNumbersThanCurrentBruteForce(int[] nums)
        {
            List<int> res = new List<int>();
            foreach (var item in nums)
            {
                int cnt = 0;
                foreach (var item2 in nums)
                {
                    if (item2 < item)
                        cnt++;
                }
                res.Add(cnt);
            }
            return res.ToArray();
        }
    }
}
