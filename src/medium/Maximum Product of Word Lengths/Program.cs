using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Product_of_Word_Lengths
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //16 The two words can be "abcw", "xtfn".
      Console.WriteLine(program.MaxProductTLE(new string[] { "abcw", "baz", "foo", "bar", "xtfn", "abcdef" }));
      //4
      Console.WriteLine(program.MaxProductTLE(new string[] { "a", "ab", "abc", "d", "cd", "bcd", "abcd" }));
      //0
      Console.WriteLine(program.MaxProductTLE(new string[] { "a", "aa", "aaa", "aaaa" }));
      Console.WriteLine("Hello World!");
    }
    public int MaxProduct(string[] words)
    {
      List<string> wk = words.OrderBy(x => -x.Length).ToList();
      int[] masks = new int[words.Length];

      for (int i = 0; i < wk.Count; i++)
      {
        int mask = 0;
        for (int j = 0; j < wk[i].Length; j++)
        {
          mask |= (1 << (wk[i][j] - 'a'));
        }
        masks[i] = mask;
      }
      int res = 0;
      for (int i = 0; i < wk.Count; i++)
      {
        for (int j = 0; j < wk.Count; j++)
        {
          var tmp = wk[i].Length * wk[j].Length;
          if (res >= tmp)
            break;
          if ((masks[i] & masks[j]) == 0)
            res = tmp;
        }
      }
      return res;
    }
    public int MaxProductTLE(string[] words)
    {
      List<string> wk = words.OrderBy(x => x.Length).ToList();
      int res = 0;
      for (int i = wk.Count - 1; i > 0; i--)
      {
        for (int j = i - 1; j >= 0; j--)
        {
          var tmp = wk[i].Length * wk[j].Length;
          if (res >= tmp)
            break;

          if (wk[i].Intersect(wk[j]).Count() == 0)
            res = tmp;
        }
      }
      return res;
    }
    public int MaxProductHashSet(string[] words)
    {
      List<string> wk = words.OrderBy(x => x.Length).ToList();
      List<HashSet<char>> memo = new List<HashSet<char>>();
      foreach (var item in wk)
      {
        HashSet<char> set = new HashSet<char>();
        foreach (var c in item)
        {
          set.Add(c);
        }
        memo.Add(set);
      }
      int res = 0;
      for (int i = memo.Count - 1; i > 0; i--)
      {
        for (int j = i - 1; j >= 0; j--)
        {
          if (isNotContains(memo[i], memo[j]))
            res = Math.Max(res, wk[i].Length * wk[j].Length);
        }
      }
      return res;
    }
    private bool isNotContains(HashSet<char> one, HashSet<char> two)
    {
      foreach (var item in one)
      {
        if (two.Contains(item))
          return false;
      }
      return true;
    }
  }
}
