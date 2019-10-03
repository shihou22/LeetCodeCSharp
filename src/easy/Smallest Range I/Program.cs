using System;

namespace Smallest_Range_I
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int SmallestRangeI(int[] A, int K)
    {
      int min = int.MaxValue;
      int max = int.MinValue;
      foreach (var item in A)
      {
        if (min > item || max < item)
        {
          min = Math.Min(min, item);
          max = Math.Max(max, item);
        }
      }
      if (A.Length == 1 || A.Length == 0)
        return 0;
      int diff = Math.Abs(max - min);
      if (K == 0)
        return diff;
      if (diff <= K * 2)
        return 0;
      else
        return diff - (K * 2);
    }
    public int SmallestRangeISort(int[] A, int K)
    {
      Array.Sort(A);
      if (A.Length == 1 || A.Length == 0)
        return 0;
      int diff = Math.Abs(A[0] - A[A.Length - 1]);
      if (K == 0)
        return diff;
      if (diff <= K * 2)
        return 0;
      else
        return diff - (K * 2);
    }
  }
}
