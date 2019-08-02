using System;
using System.Linq;

namespace Largest_Number_At_Least_Twice_of_Others
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.DominantIndex(new int[] { 3, 6, 1, 0 }));//1
            Console.WriteLine(solution.DominantIndex(new int[] { 1, 2, 3, 4 }));//-1
            Console.WriteLine("Hello World!");
        }
        public int DominantIndex(int[] nums)
        {
            int max = nums.Max();
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (max == nums[i])
                    index = i;
                else if (max < nums[i] * 2)
                    return -1;

            }
            return index;
        }
    }
}
