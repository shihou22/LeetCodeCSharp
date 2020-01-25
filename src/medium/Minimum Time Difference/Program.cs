using System.Linq;
using System.Collections.Generic;
using System;

namespace Minimum_Time_Difference
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.FindMinDifference(new List<string>() { "23:59", "00:00" }));
      Console.WriteLine(program.FindMinDifference(new List<string>() { "23:59", "12:00", "13:00" }));
      Console.WriteLine("Hello World!");
    }
    /*
    Not as fast as I thought
    */
    public int FindMinDifference(IList<string> timePoints)
    {
      if (timePoints == null || timePoints.Count == 1)
        return 0;
      var tmp = timePoints.Select(s =>
      {
        string fr = s.Substring(0, 2);
        string bk = s.Substring(3, 2);
        return int.Parse(fr) * 60 + int.Parse(bk);
      }).ToList().OrderBy(x => x);
      int res = 1440;
      int prev = -1;
      int cnt = 0;
      int first = 0;
      foreach (var item in tmp)
      {
        if (cnt == 0)
        {
          cnt++;
          first = item;
          prev = item;
          continue;
        }

        res = Math.Min(res, item - prev);
        if (cnt == tmp.Count() - 1)
          res = Math.Min(res, first + 24 * 60 - item);
        prev = item;
        cnt++;
      }
      return res;
    }
    public int FindMinDifferenceSlow(IList<string> timePoints)
    {
      if (timePoints == null || timePoints.Count == 1)
        return 0;
      var tmp = timePoints.Select(s =>
      {
        string fr = s.Substring(0, 2);
        string bk = s.Substring(3, 2);
        return int.Parse(fr + bk);
      }).ToList().OrderBy(x => x);
      int res = 1440;
      int prev = -1;
      int cnt = 0;
      int first = 0;
      foreach (var item in tmp)
      {
        if (cnt == 0)
        {
          cnt++;
          first = item;
          prev = item;
          continue;
        }

        res = CalcTimeSpan(prev, item, res);
        if (cnt == tmp.Count() - 1)
          res = CalcTimeSpan(item, first + 2400, res);
        prev = item;
        cnt++;
      }
      return res;
    }
    private int CalcTimeSpan(int prev, int item, int res)
    {
      int h = item / 100;
      int pH = prev / 100;
      int m = item % 100;
      int pM = prev % 100;

      /*
      Maybe Firster than below
      */
      return Math.Min(res, (h * 60 + m) - (pH * 60 + pM));

      /*
      Slow
      */
      // int wkH = h - pH;
      // int wkM = 60;
      // if (wkH > 0)
      // {
      //   wkH--;
      //   wkM = m + wkM - pM;
      // }
      // else
      //   wkM = m - pM;
      // return Math.Min(res, wkH * 60 + wkM);
    }
  }
}
