using System.Collections.Generic;
using System;

namespace Pairs_of_Songs_With_Total_Durations_Divisible_by_60
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //3
      //   Console.WriteLine(program.NumPairsDivisibleBy60(new int[] { 30, 20, 150, 100, 40 }));
      //0
      //   Console.WriteLine(program.NumPairsDivisibleBy60(new int[] { 439, 407, 197, 191, 291, 486, 30, 307, 11 }));
      //1
      //   Console.WriteLine(program.NumPairsDivisibleBy60(new int[] { 418, 204, 77, 278, 239, 457, 284, 263, 372, 279, 476, 416, 360, 18 }));
      //3
      Console.WriteLine(program.NumPairsDivisibleBy60(new int[] { 60, 60, 60 }));
      Console.WriteLine("Hello World!");
    }
    public int NumPairsDivisibleBy60(int[] time)
    {
      int res = 0;
      Dictionary<int, int> memo = new Dictionary<int, int>();
      for (int i = 0; i < time.Length; i++)
      {
        int wk = (60 - time[i] % 60) % 60;
        if (memo.ContainsKey(wk))
          res += memo[wk];

        memo.TryAdd(time[i] % 60, 0);
        memo[time[i] % 60]++;
      }
      return res;
    }
    public int NumPairsDivisibleBy60Greedy(int[] time)
    {
      Dictionary<int, List<int>> memo = new Dictionary<int, List<int>>();
      for (int i = 0; i < time.Length; i++)
      {
        memo.TryAdd(time[i], new List<int>());
        memo[time[i]].Add(i);
      }
      int res = 0;
      for (int i = 0; i < time.Length; i++)
      {
        res += CntNum(i, time[i], memo);
      }
      return res;
    }
    private int CntNum(int index, int num, Dictionary<int, List<int>> memo)
    {
      int res = 0;
      int wk = 60 - num % 60;
      while (wk <= 500)
      {
        if (memo.ContainsKey(wk))
        {
          var tmpList = memo[wk];
          foreach (var item in tmpList)
          {
            if (index < item)
              res++;
          }
        }

        wk += 60;
      }
      return res;
    }
  }
}
