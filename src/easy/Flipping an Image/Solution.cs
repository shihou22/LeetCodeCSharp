using System;

namespace Flipping_an_Image
{
  class Solution
  {
    static void Main(string[] args)
    {
      //   int[][] table = new int[4][];
      //   table[0] = new int[] { 1, 1, 0, 0 };
      //   table[1] = new int[] { 1, 0, 0, 1 };
      //   table[2] = new int[] { 0, 1, 1, 1 };
      //   table[3] = new int[] { 1, 0, 1, 0 };
      int[][] table = new int[1][];
      //   table[0] = new int[] { 1, 0, 0, 0 };
      table[0] = new int[] { 1, 0, 0, 0, 1 };
      Solution solution = new Solution();
      solution.FlipAndInvertImage(table);
      Console.WriteLine("Hello World!");
    }
    public int[][] FlipAndInvertImage(int[][] A)
    {
      for (int i = 0; i < A.Length; i++)
      {
        int max = A[i].Length - 1;
        for (int j = 0; j < A[i].Length / 2; j++)
        {
          int s = j;
          int e = max - j;
          int tmp = A[i][s];
          A[i][s] = A[i][e];
          A[i][e] = tmp;
          A[i][s] = 1 - A[i][s];
          if (s != e)
            A[i][e] = 1 - A[i][e];
        }
        if (A[i].Length % 2 == 1)
          A[i][A[i].Length / 2] = 1 - A[i][A[i].Length / 2];
      }
      return A;
    }
  }
}
