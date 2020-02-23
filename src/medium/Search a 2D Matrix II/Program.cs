using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Search_a_2D_Matrix_II
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
      if (false)
      {
        int[,] grid1 = GridCreator.CreateGrid("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]");
        Console.WriteLine(program.SearchMatrix(grid1, 5));//true
        Console.WriteLine(program.SearchMatrix(grid1, 20));//false
      }
      if (false)
      {
        int[,] grid1 = GridCreator.CreateGrid("[[-5]]");
        Console.WriteLine(program.SearchMatrix(grid1, -5));//true
        int[,] grid2 = GridCreator.CreateGrid("[[1,1]]");
        Console.WriteLine(program.SearchMatrix(grid2, 1));//true
      }
      if (true)
      {
        int[,] grid1 = GridCreator.CreateGrid("[[1,2,3,4,5],[6,7,8,9,10],[11,12,13,14,15],[16,17,18,19,20],[21,22,23,24,25]]");
        Console.WriteLine(program.SearchMatrix(grid1, 19));//true
        int[,] grid2 = GridCreator.CreateGrid("[[1,3,5,7,9],[2,4,6,8,10],[11,13,15,17,19],[12,14,16,18,20],[21,22,23,24,25]]");
        Console.WriteLine(program.SearchMatrix(grid2, 13));//true
      }
      Console.WriteLine("Hello World!");
    }
    public bool SearchMatrix(int[,] matrix, int target)
    {
      int currentRow = 0, currentCol = matrix.GetLength(1) - 1;

      while (currentRow <= matrix.GetLength(0) - 1 && currentCol >= 0)
        if (matrix[currentRow, currentCol] == target)
          return true;
        else if (matrix[currentRow, currentCol] < target)
          currentRow++;
        else if (matrix[currentRow, currentCol] > target)
          currentCol--;

      return false;
    }
    public bool SearchMatrixSlow(int[,] matrix, int target)
    {
      for (int i = 0; i < matrix.GetLength(0); i++)
      {
        if (ColSearch(matrix, i, target))
          return true;
      }
      return false;
    }

    private bool ColSearch(int[,] matrix, int h, int target)
    {
      int left = -1;
      int right = matrix.GetLength(1);
      while (right - left > 1)
      {
        int mid = left + (right - left) / 2;
        if (matrix[h, mid] > target)
          right = mid;
        else
          left = mid;
      }
      return (left >= 0 && left < matrix.GetLength(1)) && target == matrix[h, left];
    }
  }
}
