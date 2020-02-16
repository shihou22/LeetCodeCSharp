using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort_the_Matrix_Diagonally
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
      string[] wk = a.Replace("[[", "").Replace("]]", "").Split("],[");
      int[][] grid = new int[wk.Length][];
      for (int i = 0; i < wk.Length; i++)
      {
        string[] tmp = wk[i].Split(",");
        grid[i] = tmp.Select(x => int.Parse(x)).ToArray();
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
      //[[1,1,1,1],[1,2,2,2],[1,2,3,3]]
      int[][] mat1 = GridCreator.CreateGrid("[[3,3,1,1],[2,2,1,2],[1,1,1,2]]");
      var res1 = program.DiagonalSort(mat1);
      Console.WriteLine(GridCreator.GetResultStr(res1));
      Console.WriteLine("Hello World!");
    }
    public int[][] DiagonalSort(int[][] mat)
    {
      for (int i = 0; i < mat.Length; i++)
      {
        List<int> memo = new List<int>();
        int max = Math.Min(mat.Length - i, mat[i].Length);

        for (int j = 0; j < max; j++)
          memo.Add(mat[i + j][j]);

        memo.Sort();

        for (int j = 0; j < memo.Count; j++)
          mat[i + j][j] = memo[j]; ;
      }
      for (int i = 0; i < mat[0].Length; i++)
      {
        List<int> memo = new List<int>();
        int max = Math.Min(mat[0].Length - i, mat.Length);

        for (int j = 0; j < max; j++)
          memo.Add(mat[j][i + j]);

        memo.Sort();

        for (int j = 0; j < memo.Count; j++)
          mat[j][i + j] = memo[j]; ;
      }
      return mat;
    }
  }
}
