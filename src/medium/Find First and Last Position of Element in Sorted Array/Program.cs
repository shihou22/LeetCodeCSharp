using System;

namespace Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // var res1 = program.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            // var res2 = program.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);
            var res3 = program.SearchRange(new int[] { 1 }, 1);
            Console.WriteLine("Hello World!");
        }
        public int[] SearchRange(int[] nums, int target)
        {
            int[] res = new int[2];
            Array.Fill(res, -1);
            int left = firstSearch(nums, target, true);
            int right = firstSearch(nums, target, false) - 1;
            if (left == nums.Length || nums[left] != target || left > right)
            {
                return res;
            }
            res[0] = left;
            res[1] = right;
            return res;
        }

        private int firstSearch(int[] nums, int target, bool isEqual)
        {
            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target || (isEqual && nums[mid] == target))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
    }
}
