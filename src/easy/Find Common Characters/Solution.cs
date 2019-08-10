using System.Xml.Linq;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Find_Common_Characters
{
  class Solution
  {
    static void Main(string[] args)
    {
      IList<string> res = null;
      Solution solution = new Solution();
      res = solution.CommonChars(new string[] { "cool", "lock", "cook" });//["c","o"]
      res = solution.CommonChars(new string[] { "bella", "label", "roller" });//["e","l","l"]
      Console.WriteLine("Hello World!");
    }
    /*
    Dictionaryでのforeachの使い方
     */
    public IList<string> CommonChars(string[] A)
    {
      Dictionary<char, int> baseMemo = getMap(A[0]);
      for (int i = 1; i < A.Length; i++)
      {
        Dictionary<char, int> wkMemo = getMap(A[i]);
        foreach (var item in baseMemo.Keys.ToList())
        {
          if (wkMemo.ContainsKey(item))
          {
            int num = Math.Min(wkMemo[item], baseMemo[item]);
            baseMemo[item] = num;
          }
          else
          {
              baseMemo.Remove(item);
          }
        }
      }

      IList<string> res = new List<string>();
      foreach (var item in baseMemo)
        for (int i = 0; i < item.Value; i++)
          res.Add(item.Key.ToString());

      return res;
    }
    private Dictionary<char, int> getMap(string wk)
    {
      Dictionary<char, int> memo = new Dictionary<char, int>();
      foreach (var item in wk)
      {
        if (memo.ContainsKey(item))
          memo[item]++;
        else
          memo.Add(item, 1);
      }
      return memo;
    }
  }
}
