using System.Collections.Generic;
using System;
using System.Linq;

namespace Fair_Candy_Swap
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.FairCandySwap(new int[] { 1, 1 }, new int[] { 2, 2 }));//1,2
      Console.WriteLine(solution.FairCandySwap(new int[] { 1, 2 }, new int[] { 2, 3 }));///1,2
      Console.WriteLine(solution.FairCandySwap(new int[] { 2 }, new int[] { 1, 3 }));//2,3
      Console.WriteLine(solution.FairCandySwap(new int[] { 1, 2, 5 }, new int[] { 2, 4 }));//5,4
      Console.WriteLine(solution.FairCandySwap(new int[] { }, new int[] { }));
      Console.WriteLine(solution.FairCandySwap(new int[] { }, new int[] { }));
      Console.WriteLine(solution.FairCandySwap(new int[] { }, new int[] { }));
      Console.WriteLine("Hello World!");
    }
    public int[] FairCandySwap(int[] A, int[] B)
    {
      int totalA = A.Sum();
      Dictionary<int, int> bDict = new Dictionary<int, int>();
      int totalB = 0;
      foreach (var item in B)
      {
        totalB += item;
        if (!bDict.ContainsKey(item))
          bDict.Add(item, item);
      }

      int diff = (totalA - totalB) / 2; //(8-12)/2=-2 -- (12-8)/2 = 2
      // int diff = (totalA+totalB)/2-totalA;//(8+12)/2-8=2 --- (12+8)/2-12=-2
      foreach (var item in A)
      {
        if (bDict.ContainsKey(item + diff))
        {
          return new int[] { item, item + diff };
        }
      }
      return null;
    }
    public int[] FairCandySwapSlow(int[] A, int[] B)
    {
      int totalA = A.Sum();
      int totalB = B.Sum();
      int diff = Math.Abs(totalA - totalB) / 2;
      int[] res = new int[2];
      if (totalA < totalB)
      {
        foreach (var itemA in A)
        {
          int index = Array.IndexOf(B, itemA + diff);
          if (index >= 0)
          {
            res[0] = itemA;
            res[1] = B[index];
            return res;
          }
        }
      }
      else
      {
        foreach (var itemB in B)
        {
          int index = Array.IndexOf(A, itemB + diff);
          if (index >= 0)
          {
            res[0] = A[index];
            res[1] = itemB;
            return res;
          }
        }
      }
      return null;
    }
  }
}
