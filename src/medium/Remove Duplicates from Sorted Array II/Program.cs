using System;

namespace Remove_Duplicates_from_Sorted_Array_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.RemoveDuplicates(new int[] { 1, 1, 1, 2, 2, 3 }));
            // Console.WriteLine(program.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 3, 3, 3 }));
            Console.WriteLine(program.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3, 3 }));
            Console.WriteLine("Hello World!");
        }
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int pre = nums[0];
            int cnt = 0;
            int res = 0;
            int index = 0;
            foreach (var item in nums)
            {
                //indexのみ進める
                if (pre == item && cnt >= 2)
                    continue;

                if (pre == item)
                {
                    cnt++;
                }
                else if (pre != item)
                {
                    cnt = 1;
                    pre = item;
                }
                res++;
                nums[index] = item;
                index++;
            }

            return res;
            //0, 0, 1, 1, 1, 1, 2, 3, 3, 3
        }
    }
}
