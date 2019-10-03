using System.Collections.Generic;
using System;

namespace K_diff_Pairs_in_an_Array
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //2
      Console.WriteLine(program.FindPairs(new int[] { 3, 1, 4, 1, 5 }, 2));
      //4
      Console.WriteLine(program.FindPairs(new int[] { 1, 2, 3, 4, 5 }, 1));
      //1
      Console.WriteLine(program.FindPairs(new int[] { 1, 3, 1, 5, 4 }, 0));
      //0
      Console.WriteLine(program.FindPairs(new int[] { 1, 2, 3, 4, 5 }, -1));
      //1
      Console.WriteLine(program.FindPairs(new int[] { 1, 1, 1, 2, 2 }, 1));
      Console.WriteLine("Hello World!");
    }
    public int FindPairs(int[] nums, int k)
    {
      if (k < 0)
        return 0;
      SortedDictionary<int, int> memo = new SortedDictionary<int, int>();
      foreach (var item in nums)
      {
        memo.TryAdd(item, 0);
        memo[item]++;
      }

      int res = 0;
      if (k == 0)
      {
        foreach (var item in memo)
        {
          if (item.Value > 1)
            res++;
        }
      }
      else
      {
        foreach (var item in memo)
        {
          if (memo.ContainsKey(item.Key + k))
            res++;
        }
      }
      return res;
    }
  }
}
