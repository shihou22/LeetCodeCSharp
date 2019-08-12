using System;

namespace Monotonic_Array
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.IsMonotonic(new int[] { 1, 2, 2, 3 }));//true
      Console.WriteLine(solution.IsMonotonic(new int[] { 6, 5, 4, 4 }));//true
      Console.WriteLine(solution.IsMonotonic(new int[] { 1, 3, 2 }));//false
      Console.WriteLine(solution.IsMonotonic(new int[] { 1, 2, 4, 5 }));//true
      Console.WriteLine(solution.IsMonotonic(new int[] { 1, 1, 1 }));//true
      Console.WriteLine(solution.IsMonotonic(new int[] { 11, 11, 9, 4, 3, 3, 3, 1, -1, -1, 3, 3, 3, 5, 5, 5 }));//false
      Console.WriteLine("Hello World!");
    }
    public bool IsMonotonic(int[] A)
    {
      if (A.Length == 1)
        return true;

      int tmp = A[0];
      int isInc = 0;
      foreach (var item in A)
      {
        if (tmp < item && isInc >= 0)
        {
          isInc = 1;
          tmp = item;
        }
        else if (tmp > item && isInc <= 0)
        {
          isInc = -1;
          tmp = item;
        }
        else if (tmp == item)
        {
          //   isInc = 0;
        }
        else
        {
          return false;
        }
      }
      return true;

    }
  }
}
