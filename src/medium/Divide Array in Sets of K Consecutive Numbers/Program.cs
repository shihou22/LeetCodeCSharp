using System.Linq;
using System.Collections.Generic;
using System;

namespace Divide_Array_in_Sets_of_K_Consecutive_Numbers
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.IsPossibleDivide(new int[] { 1, 2, 3, 3, 4, 4, 5, 6 }, 4));
      Console.WriteLine(program.IsPossibleDivide(new int[] { 3, 2, 1, 2, 3, 4, 3, 4, 5, 9, 10, 11 }, 3));
      Console.WriteLine(program.IsPossibleDivide(new int[] { 3, 3, 2, 2, 1, 1 }, 3));
      Console.WriteLine(program.IsPossibleDivide(new int[] { 1, 2, 3, 4 }, 3));
      Console.WriteLine("Hello World!");
    }
    public bool IsPossibleDivide(int[] nums, int k)
    {
      Array.Sort(nums);
      Dictionary<int, int> memo = new Dictionary<int, int>();
      foreach (var item in nums)
      {
        memo.TryAdd(item, 0);
        memo[item]++;
      }
      int[] memo2 = nums.Distinct().ToArray();
      for (int i = 0; i < memo2.Length - (k - 1); i++)
      {
        int item = memo2[i];
        if (!memo.ContainsKey(item))
          return false;
        int count = memo[item];
        if (count == 0)
          continue;
        for (int j = item; j <= item + (k - 1); j++)
        {
          if (!memo.ContainsKey(j))
            return false;
          memo[j] -= count;
          if (memo[j] < 0)
            return false;
        }
      }

      return memo.Where(i => i.Value > 0).Count() == 0;
    }
  }
}
