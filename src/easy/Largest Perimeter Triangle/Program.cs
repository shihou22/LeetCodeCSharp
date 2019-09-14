using System;

namespace Largest_Perimeter_Triangle
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int LargestPerimeter(int[] A)
    {
      if (A.Length < 3)
        return 0;
      Array.Sort(A);
      int three = 0;
      int two = 0;
      int one = 0;
      int res = 0;
      for (int i = A.Length - 1; i >= 2; i--)
      {
        three = A[i];
        two = A[i - 1];
        one = A[i - 2];
        if (one + two <= three)
          continue;
        int wk = one + two + three;
        res = Math.Max(res, wk);
      }
      return res;
    }
  }
}
