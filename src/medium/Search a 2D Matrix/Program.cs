using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Search_a_2D_Matrix
{
  class GridCreator
  {
    /*
    入力サンプル
    [[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]
    ↓
    [3,0,8,4]
    [2,4,5,7]
    [9,2,6,3]
    [0,3,1,0]
    */
    public static int[][] CreateGridJag(string a)
    {
      string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
      int[][] grid = new int[wk.Length][];
      for (int i = 0; i < wk.Length; i++)
      {
        string[] tmp = wk[i].Split(",");
        grid[i] = tmp.Select(x => int.Parse(x)).ToArray();
      }
      return grid;
    }
    public static int[,] CreateGrid(string a)
    {
      string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
      int[][] tmp = wk.Select(c => c.Split(",").Select(x => int.Parse(x)).ToArray()).ToArray();
      int[,] grid = new int[tmp.Length, tmp[0].Length];

      for (int i = 0; i < wk.Length; i++)
      {
        for (int j = 0; j < tmp[i].Length; j++)
          grid[i, j] = tmp[i][j];
      }
      return grid;
    }
    public static char[][] CreateCharGrid(string a)
    {
      string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
      char[][] grid = new char[wk.Length][];
      for (int i = 0; i < wk.Length; i++)
      {
        string[] tmp = wk[i].Split(",");
        grid[i] = tmp.Select(x => x[0]).ToArray();
      }
      return grid;
    }

    public static string GetResultStr(int[][] grid)
    {
      StringBuilder builder = new StringBuilder();
      builder.Append("[");
      foreach (var item in grid)
      {
        builder.Append("[");
        for (int i = 0; i < item.Length; i++)
        {
          if (i == item.Length - 1)
            builder.Append(item[i]);
          else
            builder.Append(item[i]).Append(",");
        }
        builder.Append("]");
      }
      builder.Append("]");
      return builder.ToString();
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      var grid1 = GridCreator.CreateGridJag("[  [1,   3,  5,  7],  [10, 11, 16, 20],  [23, 30, 34, 50]]");
      Console.WriteLine(program.SearchMatrix(grid1, 3));//true
      Console.WriteLine(program.SearchMatrix(grid1, 13));//false
      Console.WriteLine("Hello World!");
    }
    public bool SearchMatrix(int[][] matrix, int target)
    {
      if (matrix.Length == 0 || matrix[0].Length == 0)
        return false;

      int rows = matrix.Length;
      int columns = matrix[0].Length;

      int left = -1;
      int right = (rows * columns);

      while (right - left > 1)
      {
        int mid = left + (right - left) / 2;

        int midRow = (mid / columns);
        int midCol = (mid % columns);

        if (target < matrix[midRow][midCol])
          right = mid;
        else
          left = mid;
      }
      if (left < 0 || left >= (rows * columns))
        return false;
      int resR = (left / columns);
      int resC = (left % columns);
      return matrix[resR][resC] == target;
    }
    public bool SearchMatrixSlow(int[][] matrix, int target)
    {
      if (matrix.Length == 0 || matrix[0].Length == 0)
        return false;
      int row = RowSearch(matrix, target);
      if (row < 0 || row >= matrix.Length)
        return false;
      int col = Array.BinarySearch(matrix[row], target);
      return col >= 0;
    }
    private int RowSearch(int[][] matrix, int target)
    {
      int left = -1;
      int right = matrix.Length;
      while (right - left > 1)
      {
        int mid = left + (right - left) / 2;
        if (matrix[mid][0] > target)
          right = mid;
        else
          left = mid;
      }
      return left;
    }
  }
}
