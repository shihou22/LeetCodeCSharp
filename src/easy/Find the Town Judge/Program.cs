using System.Linq;
using System;
using System.Collections.Generic;

namespace Find_the_Town_Judge
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int FindJudge(int N, int[][] trust)
    {
      Dictionary<int, int> people = new Dictionary<int, int>();
      for (int i = 1; i <= N; i++)
      {
        people.Add(i, N - 1);
      }
      foreach (var item in trust)
      {
        int p = item[0];
        if (people.ContainsKey(p))
          people.Remove(p);
        int wk = item[1];
        if (people.ContainsKey(wk))
          people[wk]--;
      }
      foreach (var item in people)
      {
        if (item.Value == 0)
          return item.Key;
      }
      return -1;
    }
  }
}
