using System;
using System.Collections.Generic;

namespace Majority_Element_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MajorityElement(new int[] { 3, 2, 3 }));
            Console.WriteLine(program.MajorityElement(new int[] { 1 }));
            Console.WriteLine("Hello World!");
        }
        public IList<int> MajorityElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return nums;
            Array.Sort(nums);
            IList<int> res = new List<int>();
            int max = nums.Length / 3 + 1;
            int cnt = 0;
            int pre = nums[0];
            bool isAdd = true;
            foreach (var item in nums)
            {
                if (item == pre)
                {
                    cnt++;
                }
                else
                {
                    cnt = 1;
                    pre = item;
                    isAdd = true;
                }
                if (cnt >= max && isAdd)
                {
                    res.Add(item);
                    isAdd = false;
                }
            }
            return res;
        }
    }
}
