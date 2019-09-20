using System;

namespace Find_Pivot_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 }));//3
            // Console.WriteLine(program.PivotIndex(new int[] { 1, 2, 3 }));//-1
            // Console.WriteLine(program.PivotIndex(new int[] { -1, -1, -1, 0, 1, 1 }));//0
            Console.WriteLine(program.PivotIndex(new int[] { -1, -1, -1, 1, 1, 1 }));//5
            Console.WriteLine("Hello World!");
        }
        public int PivotIndex(int[] nums)
        {
            int nL = nums.Length;
            if (nums == null || nL == 0)
                return -1;
            int[] left = new int[nL];
            int[] right = new int[nL];
            left[0] = nums[0];
            int nLMinusOne = nL - 1;
            right[nLMinusOne] = nums[nLMinusOne];
            for (int i = 1; i < nL; i++)
            {
                left[i] = left[i - 1] + nums[i];
                right[nLMinusOne - i] = right[nLMinusOne - i + 1] + nums[nLMinusOne - i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    if (right[1] == 0)
                        return 0;
                }
                else if (i == nLMinusOne)
                {
                    if (left[nLMinusOne - 1] == 0)
                        return nLMinusOne;
                }
                else if (left[i - 1] == right[i + 1])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
