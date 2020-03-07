using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Image_Smoother
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
        if (tmp.Length > 0 && tmp[0].Length > 0)
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
      int[][] grid1 = GridCreator.CreateGridJag("[[1,1,1], [1,0,1], [1,1,1]]");
      //   var res1 = program.ImageSmoother(grid1);
      int[][] grid2 = GridCreator.CreateGridJag("[[2,3,4],[5,6,7],[8,9,10],[11,12,13],[14,15,16]]");
      var res2 = program.ImageSmoother(grid2);
      Console.WriteLine("Hello World!");
    }
    public int[][] ImageSmoother(int[][] M)
    {

      int n = M.Length;
      int inner = M[0].Length;
      int[][] res = new int[n][];

      for (int i = 0; i < n; i++)
        res[i] = new int[inner];

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < inner; j++)
        {
          int[] x = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };
          int[] y = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
          int num = M[i][j];
          int cnt = 1;
          for (int d = 0; d < 8; d++)
          {
            int dX = i + x[d];
            int dY = j + y[d];
            if (dX < 0 || dY < 0 || dX >= n || dY >= inner)
              continue;
            num += M[dX][dY];
            cnt++;
          }
          res[i][j] = num / cnt;
        }
      }
      return res;
    }
  }
}
