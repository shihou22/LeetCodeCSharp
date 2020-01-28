using System;
using System.Collections.Generic;

namespace Find_All_Duplicates_in_an_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            IList<int> wk = program.FindDuplicates(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
            Console.WriteLine("Hello World!");
        }
        public IList<int> FindDuplicates(int[] nums)
        {
            List<int> result = new List<int>();
            foreach (var item in nums)
            {
                if (nums[Math.Abs(item) - 1] < 0)
                    result.Add(Math.Abs(item));
                else
                    nums[Math.Abs(item) - 1] = -nums[Math.Abs(item) - 1];
            }
            return result;
        }
    }
}
