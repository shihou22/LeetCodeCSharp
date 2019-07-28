using System;

namespace Longest_Increasing_Subsequence
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.LengthOfLIS(new int[] { 10, 9, 8, 7, 6, 5, 3, 7, 101, 102, 18 }));
      Console.WriteLine("Hello World!");
    }
    public int LengthOfLIS(int[] nums)
    {
      if (nums == null || nums.Length == 0)
        return 0;

      int n = nums.Length;
      int max = 1;

      int[] d = new int[n];
      d[0] = 1;

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < i; j++)
        {
          int cur = 1;
          if (nums[i] > nums[j])
            cur = d[j] + 1;

          d[i] = Math.Max(d[i], cur);
        }
        max = Math.Max(max, d[i]);
      }

      return max;
    }
    public int LengthOfLISOld(int[] nums)
    {
      if (nums == null || nums.Length == 0)
        return 0;
      int[] dp = new int[nums.Length];
      int count = 0;
      foreach (var num in nums)
      {
        int left = 0, right = count;
        while (left < right)
        {
          int mid = (left + right) / 2;
          if (dp[mid] < num)
            left = mid + 1;
          else
            right = mid;
        }
        dp[left] = num;
        if (left == count) count++;
      }
      return count;
    }

    int max = 0;
    public int LengthOfLISDFS(int[] nums)
    {
      DFS(nums, 0, 0, int.MinValue);
      return max;
    }
    private void DFS(int[] nums, int currentI, int len, int maxNum)
    {
      if (currentI > nums.Length - 1)
      {
        max = Math.Max(max, len);
        return;
      }

      if (nums[currentI] > maxNum)
      {
        DFS(nums, currentI + 1, len, maxNum);
        DFS(nums, currentI + 1, len + 1, nums[currentI]);
      }
      else
        DFS(nums, currentI + 1, len, maxNum);
    }
  }
}
