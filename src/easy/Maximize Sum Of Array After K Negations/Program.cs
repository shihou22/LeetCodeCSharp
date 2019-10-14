using System;

namespace Maximize_Sum_Of_Array_After_K_Negations
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //5
      //   Console.WriteLine(ps5rogram.LargestSumAfterKNegations(new int[] { 4, 2, 3 }, 1));
      //6
      //   Console.WriteLine(program.LargestSumAfterKNegations(new int[] { 3, -1, 0, 2 }, 3));
      //13
      //   Console.WriteLine(program.LargestSumAfterKNegations(new int[] { 2, -3, -1, 5, -4 }, 2));
      //20
      Console.WriteLine(program.LargestSumAfterKNegations(new int[] { 5, 6, 9, -3, 3 }, 2));
      Console.WriteLine("Hello World!");
    }
    public int LargestSumAfterKNegations(int[] A, int K)
    {
      Array.Sort(A);
      int sum = 0;
      int minusIndeices = 0;
      int min = A[A.Length - 1];
      foreach (var item in A)
      {
        sum += item;
        if (item < 0)
          minusIndeices++;
        min = Math.Min(Math.Abs(item), min);
      }
      if (minusIndeices == 0)
      {
        if (K % 2 == 0)
          return sum;
        else
          return sum - (A[0] * 2);
      }
      else if (minusIndeices >= K)
      {
        for (int i = 0; i < K; i++)
        {
          sum = sum - (A[i] * 2);
        }
        return sum;
      }
      else
      {
        int additional = K - minusIndeices;
        for (int i = 0; i < minusIndeices; i++)
        {
          sum = sum - (A[i] * 2);
        }
        if (additional % 2 == 0)
          return sum;
        else
          return sum - (min * 2);
      }

    }
  }
}
