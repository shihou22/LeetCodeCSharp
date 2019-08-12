using System.Linq;
using System.Collections.Generic;
using System;

namespace Positions_of_Large_Groups
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.LargeGroupPositions("abbxxxxzzy"));//[[3,6]]
      Console.WriteLine(solution.LargeGroupPositions("abc"));// []
      Console.WriteLine(solution.LargeGroupPositions("abcdddeeeeaabbbcd"));//[[3,5],[6,9],[12,14]]
      Console.WriteLine("Hello World!");
    }
    /*
    ソート SORT
    欄レングス圧縮 RLE
     */
    public IList<IList<int>> LargeGroupPositions(string S)
    {
      IList<KeyValuePair<int, List<int>>> tmp = new List<KeyValuePair<int, List<int>>>();
      int start = 0;
      int end = 0;
      char pre = S[0];
      for (int i = 1; i < S.Length; i++)
      {
        if (pre != S[i])
        {
          if (end - start >= 2)
            tmp.Add(new KeyValuePair<int, List<int>>(pre, new List<int>() { start, end }));

          start = i;
          pre = S[i];
        }
        end = i;
      }
      if (end - start >= 2)
        tmp.Add(new KeyValuePair<int, List<int>>(pre, new List<int>() { start, end }));

      IList<IList<int>> res = new List<IList<int>>();
      //   foreach (var item in tmp.OrderBy(x => x.Key).ThenBy(x => x.Value.Count))
      foreach (var item in tmp)
      {
        res.Add(item.Value);
      }
      return res;
    }
  }
}
