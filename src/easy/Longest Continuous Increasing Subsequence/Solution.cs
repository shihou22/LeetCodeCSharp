using System;

namespace Longest_Continuous_Increasing_Subsequence
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.FindLengthOfLCIS(new int[] { 1, 3, 5, 4, 7 }));
      Console.WriteLine(solution.FindLengthOfLCIS(new int[] { 2, 2, 2, 2, 2, 2 }));
      Console.WriteLine(solution.FindLengthOfLCIS(new int[] { 1 }));
      Console.WriteLine("Hello World!");
    }
    public int FindLengthOfLCIS(int[] nums)
    {
      if (nums == null || nums.Length == 0)
        return 0;

      int left = 0;
      int right = 1;
      int res = 1;
      while (left < right && right < nums.Length)
      {
        while (right < nums.Length && nums[right - 1] < nums[right])
        {
          right++;
        }
        res = Math.Max(right - left, res);
        left = right;
        right++;
      }
      return res;
    }
  }
}
