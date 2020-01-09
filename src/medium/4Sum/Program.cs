using System;
using System.Collections.Generic;
using System.Linq;

namespace _4Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 10);
            program.FourSum(new int[] { -3, -2, -1, 0, 0, 1, 2, 3 }, 0);
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            int n = nums.Length;
            ISet<string> memo = new HashSet<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int k = j + 1;
                    int l = nums.Length - 1;
                    while (k < l)
                    {
                        int wk = nums[i] + nums[j] + nums[k] + nums[l];
                        if (wk == target)
                        {
                            if (!memo.Contains(nums[i] + "-" + nums[j] + "-" + nums[k] + "-" + nums[l]))
                            {
                                res.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });
                                memo.Add(nums[i] + "-" + nums[j] + "-" + nums[k] + "-" + nums[l]);
                            }
                            k++;
                            l--;
                        }
                        else if (wk < target)
                        {
                            k++;
                        }
                        else
                        {
                            l--;
                        }
                    }

                }
            }
            return res;
        }
    }
}
