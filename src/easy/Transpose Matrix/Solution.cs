using System;

namespace Transpose_Matrix
{
  class Solution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int[][] Transpose(int[][] A)
    {
      int[][] res = new int[A[0].Length][];
      for (int i = 0; i < A[0].Length; i++)
      {
        res[i] = new int[A.Length];
        for (int j = 0; j < A.Length; j++)
        {
          res[i][j] = A[j][i];
        }
      }
      return res;
    }
  }
}
