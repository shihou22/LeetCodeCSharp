using System;
using System.Collections.Generic;

namespace Non_decreasing_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //true
            Console.WriteLine(program.CheckPossibility(new int[] { 4, 2, 3 }));
            //false
            Console.WriteLine(program.CheckPossibility(new int[] { 4, 2, 1 }));
            //false
            Console.WriteLine(program.CheckPossibility(new int[] { 2, 5, 3, 4 }));
            Console.WriteLine("Hello World!");
        }
        public bool CheckPossibility(int[] nums)
        {

            if (nums.Length == 0 || nums.Length == 1)
                return true;
            var cnt = 0;
            HashSet<int> memo = new HashSet<int>();
            for (int i = 0; i < nums.Length - 1; i++)
            {
                memo.Add(nums[i]);
                if (nums[i] > nums[i + 1])
                {
                    int wk = nums[i] - 1;

                    nums[i] = wk;
                    cnt++;
                }
            }
            if (cnt > 1)
                return false;

            return true;
        }
    }
}
