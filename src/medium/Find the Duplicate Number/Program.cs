using System;
using System.Linq;
using System.Collections;

namespace Find_the_Duplicate_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.FindDuplicate(new int[] { 1, 3, 4, 2, 2 }));//2
            // Console.WriteLine(program.FindDuplicate(new int[] { 3, 1, 3, 4, 2 }));//3
            // Console.WriteLine(program.FindDuplicate(new int[] { 2, 5, 9, 6, 9, 3, 8, 9, 7, 1 }));//3
            Console.WriteLine(program.FindDuplicate(new int[] { 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1, 2, 5, 9, 6, 9, 3, 8, 9, 7, 1 }));//3
            Console.WriteLine("Hello World!");
        }
        public int FindDuplicate(int[] nums)
        {
            BitArray bit = new BitArray(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (bit.Get(num))
                {
                    return num;
                }
                else
                {
                    bit.Set(num, true);
                }
            }
            return -1;

        }
        public int FindDuplicateRun(int[] nums)
        {
            int slow = nums[0];
            int speed = nums[0];
            do
            {
                slow = nums[slow];
                speed = nums[nums[speed]];
            } while (slow != speed);
            int ptr1 = nums[0];
            int ptr2 = slow;
            while (ptr1 != ptr2)
            {
                ptr1 = nums[ptr1];
                ptr2 = nums[ptr2];
            }
            return ptr1;
        }
    }
}
