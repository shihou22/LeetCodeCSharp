using System.Collections.Generic;
using System;

namespace Jewels_and_Stones
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.NumJewelsInStones("aA", "aAAbbbb"));
      Console.WriteLine("Hello World!");
    }
    public int NumJewelsInStones(string J, string S)
    {
      Dictionary<char, int> stones = new Dictionary<char, int>();
      int res = 0;
      foreach (var item in S)
      {
        if (J.Contains(item))
          res++;
      }
      return res;
    }
  }
}
