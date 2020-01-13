using System.Linq;
using System;
using System.Collections.Generic;

namespace Merge_Intervals
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      int[][] tmp = new int[2][];
      tmp[0] = new int[] { 1, 4 };
      tmp[1] = new int[] { 1, 5 };
      program.Merge(tmp);
      Console.WriteLine("Hello World!");
    }
    public int[][] Merge(int[][] intervals)
    {
      Array.Sort(intervals,
       (x, y) => x[0].CompareTo(y[0]) == 0 ? -x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));

      IList<int[]> res = new List<int[]>();

      for (int i = 0; i < intervals.Length; i++)
      {
        int start = intervals[i][0];
        int end = intervals[i][1];
        if (i + 1 < intervals.Length)
        {
          if (end >= intervals[i + 1][0])
          {
            int j = i;
            while (j + 1 < intervals.Length && end >= intervals[j + 1][0])
            {
              j++;
              end = Math.Max(end, intervals[j][1]);
            }
            i = j;
          }
        }
        res.Add(new int[] { start, end });
      }
      return res.ToArray();
    }
  }
}
