using System;

namespace Rotate_Image
{
  class Solution
  {
    static void Main(string[] args)
    {
      int[][] table = new int[3][];
      table[0] = new int[] { 7, 4, 1 };
      table[1] = new int[] { 8, 5, 2 };
      table[2] = new int[] { 9, 6, 3 };
      Solution solution = new Solution();
      solution.Rotate(table);
      Console.WriteLine("Hello World!");
    }
    public void Rotate(int[][] matrix)
    {
      int n = matrix.Length - 1;
      int pad = 0;
      //そもそも一番最後に一番最初の値を入れるので-1が必須
      for (int i = 0; i < matrix.Length - 1 - pad; i++)
      {
        for (int j = i; j < matrix.Length - 1 - pad; j++)
        {
          int tmp = matrix[i][j];
          matrix[i][j] = matrix[n - j][i];
          matrix[n - j][i] = matrix[n - i][n - j];
          matrix[n - i][n - j] = matrix[j][n - i];
          matrix[j][n - i] = tmp;
        }
        pad++;
      }
    }
  }
}
