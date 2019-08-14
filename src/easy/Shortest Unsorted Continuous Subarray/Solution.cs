using System.Linq;
using System;
using System.Collections.Generic;

namespace Shortest_Unsorted_Continuous_Subarray
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.FindUnsortedSubarray(new int[] { 2, 6, 4, 8, 10, 9, 15 }));//5
      Console.WriteLine(solution.FindUnsortedSubarray(new int[] { 2, 1 }));//2
      Console.WriteLine(solution.FindUnsortedSubarray(new int[] { 1, 2, 3, 4 }));//0
      Console.WriteLine("Hello World!");
    }
    public int FindUnsortedSubarray(int[] nums)
    {
      IList<int> ordered = nums.OrderBy(a => a).ToArray();
      bool cntS = false;
      int s = 0;
      bool cntE = false;
      int e = 0;
      for (int i = 0; i < ordered.Count; i++)
      {
        if (nums[i] != ordered[i] && !cntS)
        {
          cntS = true;
          s = i;
        }
        if (nums[ordered.Count - 1 - i] != ordered[ordered.Count - 1 - i] && !cntE)
        {
          cntE = true;
          e = ordered.Count - 1 - i;
        }
        if (cntS && cntE)
          break;

      }

      return e - s != 0 ? e - s + 1 : 0;
    }
  }
}
