using System;
using System.Text;

namespace Subarray_Product_Less_Than_K
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //8
            Console.WriteLine(program.NumSubarrayProductLessThanK(new int[] { 10, 5, 2, 6 }, 100));
            Console.WriteLine("Hello World!");

        }
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1)
                return 0;
            long num = 1;
            long res = 0;
            long right = 0;
            for (long left = 0; left < nums.Length; left++)
            {
                while (right < nums.Length && nums[right] * num < k)
                {
                    num *= nums[right];
                    right++;
                }
                res += (right - left);
                if (left == right)
                    right++;
                else
                    num /= nums[left];
            }
            return (int)res;
        }
    }
}
