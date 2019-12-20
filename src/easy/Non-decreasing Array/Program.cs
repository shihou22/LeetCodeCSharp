using System;
using System.Collections.Generic;

namespace Non_decreasing_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program(); ;
            //true
            Console.WriteLine(program.CheckPossibility(new int[] { 4, 2, 3 }));
            // //false
            Console.WriteLine(program.CheckPossibility(new int[] { 4, 2, 1 }));
            // //true
            Console.WriteLine(program.CheckPossibility(new int[] { 2, 5, 3, 4 }));
            //false
            Console.WriteLine(program.CheckPossibility(new int[] { 3, 4, 2, 3 }));
            //false
            Console.WriteLine(program.CheckPossibility(new int[] { 3, 3, 2, 2 }));
            //true
            Console.WriteLine(program.CheckPossibility(new int[] { 2, 3, 3, 2, 4 }));
            Console.WriteLine("Hello World!");
        }
        public bool CheckPossibility(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
                return true;
            var cnt = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    cnt++;
                    if (i - 2 >= 0 && nums[i - 2] > nums[i])
                        nums[i] = nums[i - 1];
                    else
                        nums[i - 1] = nums[i];
                }
                if (cnt > 1)
                    return false;
            }
            // if (cnt == 0)
            //     return true;
            // for (int i = 1; i < nums.Length; i++)
            // {
            //     if (nums[i - 1] > nums[i])
            //     {
            //         return false;
            //     }
            // }
            return true;
        }
    }
}
