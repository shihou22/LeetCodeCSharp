using System;
using System.Linq;
using System.Collections.Generic;

namespace Find_K_Pairs_with_Smallest_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // [[1,2],[1,4],[1,6]] 
            var res1 = program.KSmallestPairs(new int[] { 1, 7, 11 }, new int[] { 2, 4, 6 }, 3);
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            IList<IList<int>> wk = new List<IList<int>>();
            if (nums1.Length == 0 || nums2.Length == 0)
                return wk;

            for (int i = 0; i < Math.Min(nums1.Length, k); i++)
                for (int j = 0; j < Math.Min(nums2.Length, k); j++)
                    wk.Add(new List<int>() { nums1[i], nums2[j] });
            return wk.OrderBy(x => x[0] + x[1]).Take(k).ToList();
        }
    }
}
