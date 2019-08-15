using System.Linq;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;

namespace Permutation_Sequence
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.GetPermutation(3, 3));//213
      Console.WriteLine("Hello World!");
    }
    public string GetPermutation(int n, int k)
    {
      IList<int> res = new List<int>();
      int[] nums = new int[n];
      for (int i = 0; i < n; i++)
      {
        nums[i] = i + 1;
      }
      this.k = k;
      return RecPerm(nums, n, new bool[n], 0, 0).ToString();
    }
    int k;
    private int RecPerm(int[] nums, int n, bool[] visited, int current, int num)
    {

      if (current == n)
      {
        k--;
        if (k == 0)
        {
          return num;
        }
        return -1;
      }
      for (int i = 0; i < nums.Length; i++)
      {
        if (visited[i])
          continue;
        visited[i] = true;
        int wkNum = num * 10 + nums[i];
        int res = RecPerm(nums, n, visited, current + 1, wkNum);
        if (res != -1)
        {
          return res;
        }
        visited[i] = false;
      }
      return -1;
    }
  }

}
