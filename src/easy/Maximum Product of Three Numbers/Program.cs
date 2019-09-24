using System;

namespace Maximum_Product_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaximumProduct(int[] nums)
        {
            int maInd1 = nums.Length - 1;
            int maInd2 = nums.Length - 2;
            int maInd3 = nums.Length - 3;
            int miInd1 = 0;
            int miInd2 = 1;
            int miInd3 = 2;
            Array.Sort(nums);
            int val1 = nums[maInd1] * nums[maInd2] * nums[maInd3];
            int val2 = nums[miInd1] * nums[miInd2] * nums[miInd3];
            int val3 = nums[maInd1] * nums[miInd1] * nums[miInd2];
            return Math.Max(Math.Max(val1, val2), val3);
        }
    }
}
