using System;

namespace Remove_Covered_Intervals
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      int[][] intervals = new int[3][];
      intervals[0] = new int[] { 1, 4 };
      intervals[1] = new int[] { 3, 6 };
      intervals[2] = new int[] { 2, 8 };
      var res = program.RemoveCoveredIntervals(intervals);
      Console.WriteLine("Hello World!");
    }
    public int RemoveCoveredIntervals(int[][] intervals)
    {
      /*
      x:昇順
      y:降順
      */
      Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]) == 0 ? -x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));

      int index = 0;
      int cnt = 0;
      while (index < intervals.Length)
      {
        int[] wk = intervals[index];
        if (index + 1 < intervals.Length)
        {
          int i = index;
          while (i < intervals.Length)
          {
            int[] next = intervals[i];
            if (wk[1] < next[1])
            {
              break;
            }
            i++;
          }
          index = i;
        }
        else
        {
          index++;
        }
        cnt++;
      }
      return cnt;
    }
  }
}
