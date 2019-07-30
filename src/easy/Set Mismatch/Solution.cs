using System;
using System.Linq;

namespace Set_Mismatch
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.FindErrorNums(new int[] { 1, 2, 2, 4 }));//2,3
            Console.WriteLine(solution.FindErrorNums(new int[] { 1, 1 }));//1,2
            Console.WriteLine(solution.FindErrorNums(new int[] { 2, 2 }));//2,1
            Console.WriteLine(solution.FindErrorNums(new int[] { 3, 2, 3, 4, 6, 5 }));//3,1
            Console.WriteLine("Hello World!");
        }
        public int[] FindErrorNums(int[] nums)
        {
            Array.Sort(nums);
            int dupNum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    dupNum = nums[i];
            }
            int wk = nums.Length;
            int disNum = ((wk * (wk + 1)) / 2) - (nums.Sum() - dupNum);
            // Console.WriteLine(dupNum + " / " + disNum);
            return new int[] { dupNum, disNum };
        }
    }
}
