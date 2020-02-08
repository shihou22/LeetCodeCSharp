using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Smallest_String_With_Swaps
{
  class UnionFind
  {

    private int[] par;

    public UnionFind(int n)
    {
      this.par = new int[n];
      Array.Fill(par, -1);
    }

    public List<int> GetNumOfGroups()
    {
      List<int> indexes = new List<int>();
      for (int i = 0; i < par.Length; i++)
      {
        if (par[i] < 0)
          indexes.Add(i);
      }
      return indexes;
    }

    public int GetRoot(int n)
    {
      if (par[n] < 0)
        return n;
      else
        return par[n] = GetRoot(par[n]);
    }

    public void Unite(int x, int y)
    {
      if (!IsSame(x, y))
      {
        int wkX = GetRoot(x);
        int wkY = GetRoot(y);
        if (par[wkX] < par[wkY])
        {
          par[wkX] += par[wkY];
          par[wkY] = wkX;
        }
        else
        {
          par[wkY] += par[wkX];
          par[wkX] = wkY;
        }
      }
    }

    public bool IsSame(int x, int y)
    {
      return GetRoot(x) == GetRoot(y);
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //bacd
      Console.WriteLine(program.SmallestStringWithSwaps("dcab", new List<IList<int>>() { new List<int>() { 0, 3 }, new List<int>() { 1, 2 } }));
      //abcd
      Console.WriteLine(program.SmallestStringWithSwaps("dcab", new List<IList<int>>() { new List<int>() { 0, 3 }, new List<int>() { 1, 2 }, new List<int>() { 0, 2 } }));
      Console.WriteLine("Hello World!");
    }
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
    {
      int n = s.Length;
      char[] res = new char[n];
      IDictionary<int, List<char>> map = new Dictionary<int, List<char>>();
      UnionFind unionFind = new UnionFind(s.Length);
      foreach (var item in pairs)
      {
        unionFind.Unite(item[0], item[1]);
      }
      foreach (var item in unionFind.GetNumOfGroups())
      {
        map.TryAdd(item, new List<char>());
      }
      for (int i = 0; i < n; i++)
      {
        var index = unionFind.GetRoot(i);
        map[index].Add(s[i]);
      }
      foreach (var item in map.Values)
      {
        item.Sort();
      }
      for (int i = 0; i < n; i++)
      {
        var index = unionFind.GetRoot(i);
        res[i] = map[index][0];
        map[index].RemoveAt(0);
      }
      return new string(res);
    }
  }
}
