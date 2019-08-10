using System;

namespace Number_of_Longest_Increasing_Subsequence
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();

      Console.WriteLine(solution.FindNumberOfLIS(new int[] { 1, 3, 5, 4, 7 }));//2
    //   Console.WriteLine(solution.FindNumberOfLIS(new int[] { 2, 2, 2, 2, 2 }));//5
      Console.WriteLine("Hello World!");
    }
    public int FindNumberOfLIS(int[] nums)
    {
      int[] dp = new int[nums.Length + 1];
      int[] cnt = new int[nums.Length + 1];

      for (int i = 0; i <= nums.Length; i++)
      {
        dp[i] = 1; // every individual element is LIS of length 1
        cnt[i] = 1; // tracks the number of LIS till this point
      }

      int ans = 0;
      int mx = 0; // keeps track of LIS length seen so far
      for (int i = 0; i < nums.Length; i++)
      {
        for (int j = 0; j < i; j++)
        {
          if (nums[i] > nums[j])
          {
            if (dp[i] < 1 + dp[j])
            {
              dp[i] = 1 + dp[j]; // Lis for i increases
              cnt[i] = cnt[j];   // update its count to cnt[j] as there are those many subsequences
            }
            else if (dp[i] == 1 + dp[j])
            {
              cnt[i] += cnt[j];  // if its the same, add the cnt[j] to existing cnt[i]
            }
          }
        }
        if (mx == dp[i])
        { // if mx is same as LIS at i
          ans += cnt[i]; // add the cnt to it
        }
        else if (mx < dp[i])
        { // found a higher LIS
          mx = dp[i]; // update the LIS
          ans = cnt[i]; // update the count
        }

      }
      return ans;
    }
  }
}
