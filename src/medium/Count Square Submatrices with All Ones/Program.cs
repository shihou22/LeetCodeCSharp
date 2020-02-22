using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Count_Square_Submatrices_with_All_Ones
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
    public static int[][] CreateGrid(string a)
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
      var g1 = GridCreator.CreateGrid("[[0,1,1,1],[1,1,1,1],[0,1,1,1]]");
      Console.WriteLine(program.CountSquares(g1));
      Console.WriteLine("Hello World!");
    }
    public int CountSquares(int[][] matrix)
    {
      int res = 0;
      for (int i = 0; i < matrix.Length; i++)
      {
        for (int j = 0; j < matrix[0].Length; j++)
        {
          if (matrix[i][j] == 0)
            continue;
          res += countSquare(matrix, i, j);
        }
      }
      return res;
    }
    private int countSquare(int[][] matrix, int i, int j)
    {
      int res = 0;
      for (int size = 1; size <= matrix.Length; size++)
      {
        if (chkRangeCountSquare(matrix, i, j, size))
          res++;
        else
          return res;
      }
      return res;
    }
    private bool chkRangeCountSquare(int[][] matrix, int i, int j, int size)
    {
      if (i + size > matrix.Length || j + size > matrix[0].Length)
        return false;
      for (int k = i; k < i + size; k++)
      {
        for (int l = j; l < j + size; l++)
        {
          if (matrix[k][l] == 0)
            return false;
        }
      }
      return true;
    }

  }

}
