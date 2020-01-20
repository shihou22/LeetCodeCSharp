using System;
using System.Collections.Generic;
using System.Linq;

namespace Minimum_Size_Subarray_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 }));
            Console.WriteLine(program.MinSubArrayLen(3, new int[] { 1, 1 }));
            Console.WriteLine("Hello World!");
        }
        public int MinSubArrayLenON4(int s, int[] nums)
        {
            int res = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int wk = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    wk += nums[j];
                    if (wk >= s)
                    {
                        res = Math.Min(res, j - i + 1);
                        break;
                    }
                }
            }
            return res == int.MaxValue ? 0 : res;
        }
        public int MinSubArrayLen(int s, int[] nums)
        {
            int[] rui = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                rui[i + 1] = nums[i] + rui[i];
            }
            int res = nums.Length + 1;
            for (int i = 0; i < nums.Length; i++)
            {
                int wk = (s - nums[i]) + rui[i + 1];
                int index = lowerBound(rui, wk);
                if (index >= 0 && index <= nums.Length && index - i >= 0)
                {
                    res = Math.Min(res, index - i);
                }
            }
            return res != nums.Length + 1 ? res : 0;
        }
        /*
        LowerBound実装
         */
        private int lowerBound(int[] nums, long val)
        {
            int left = -1;
            int right = nums.Length;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (val <= nums[mid])
                    right = mid;
                else
                    left = mid;
            }
            return right;
        }

        public int MinSubArrayLenSlidingWindow(int s, int[] nums)
        {
            int sum = 0;
            int right = 0;
            int res = nums.Length + 1;
            for (int i = 0; i < nums.Length; i++)
            {
                while (right < nums.Length && sum < s)
                {
                    sum += nums[right];
                    right++;
                }
                if (sum >= s)
                {
                    res = Math.Min(res, right - i);
                    sum -= nums[i];
                }
                if (i == right)
                    right++;
            }

            return res != nums.Length + 1 ? res : 0;
        }
    }
}
