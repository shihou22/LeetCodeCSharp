using System;

namespace Maximum_Product_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //6
            // Console.WriteLine(program.MaxProduct(new int[] { 2, 3, -2, 4 }));
            //0
            // Console.WriteLine(program.MaxProduct(new int[] { -2, 0, -1 }));
            //-2
            Console.WriteLine(program.MaxProduct(new int[] { -2 }));
            Console.WriteLine("Hello World!");
        }
        public int MaxProduct(int[] nums)
        {
            int max = nums[0];
            int curr = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                curr *= nums[i];
                max = Math.Max(max, curr);
                if (curr == 0) curr = 1;
            }
            curr = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                curr *= nums[i];
                max = Math.Max(max, curr);
                if (curr == 0) curr = 1;
            }

            return max;
        }
        public int MaxProductDP(int[] nums)
        {
            int[] max = new int[nums.Length];
            int[] min = new int[nums.Length];
            int res = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                max[i] = nums[i];
                min[i] = nums[i];

                if (i > 0)
                {
                    max[i] = Math.Max(max[i], nums[i] * max[i - 1]);
                    max[i] = Math.Max(max[i], nums[i] * min[i - 1]);

                    min[i] = Math.Min(min[i], nums[i] * max[i - 1]);
                    min[i] = Math.Min(min[i], nums[i] * min[i - 1]);

                }

                if (max[i] > res)
                    res = max[i];
            }
            return res;
        }
        public int MaxProductTLEBruteForce(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int res = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                int pro = 1;
                for (int j = i; j < nums.Length; j++)
                {
                    pro *= nums[j];
                    if (pro > res)
                        res = pro;
                }
            }
            return res;
        }
    }
}
