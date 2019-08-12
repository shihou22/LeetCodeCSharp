using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;

namespace Magic_Squares_In_Grid
{
  class Solution
  {
    static void Main(string[] args)
    {
      // int[][] table = new int[3][];
      // table[0] = new int[] { 4, 3, 8, 4 };
      // table[1] = new int[] { 9, 5, 1, 9 };
      // table[2] = new int[] { 2, 7, 6, 2 };
      // Solution solution = new Solution();
      // Console.WriteLine(solution.NumMagicSquaresInside(table));//1
      // int[][] table = new int[3][];
      // table[0] = new int[] { 5, 5, 5 };
      // table[1] = new int[] { 5, 5, 5 };
      // table[2] = new int[] { 5, 5, 5 };
      // Solution solution = new Solution();
      // Console.WriteLine(solution.NumMagicSquaresInside(table));//0
      // int[][] table = new int[3][];
      // table[0] = new int[] { 10, 3, 5 };
      // table[1] = new int[] { 1, 6, 11 };
      // table[2] = new int[] { 7, 9, 2 };
      // Solution solution = new Solution();
      // Console.WriteLine(solution.NumMagicSquaresInside(table));//0
      //   int[][] table = new int[5][];
      //   table[0] = new int[] { 3, 2, 9, 2, 7 };
      //   table[1] = new int[] { 6, 1, 8, 4, 2 };
      //   table[2] = new int[] { 7, 5, 3, 2, 7 };
      //   table[3] = new int[] { 2, 9, 4, 9, 6 };
      //   table[4] = new int[] { 4, 3, 8, 2, 5 };
      //   Solution solution = new Solution();
      //   Console.WriteLine(solution.NumMagicSquaresInside(table));//1 i:1 / j:0
      int[][] table = new int[5][];
      table[0] = new int[] { 3, 10, 2, 3, 4 };
      table[1] = new int[] { 4, 5, 6, 8, 1 };
      table[2] = new int[] { 8, 8, 1, 6, 8 };
      table[3] = new int[] { 1, 3, 5, 7, 1 };
      table[4] = new int[] { 9, 4, 9, 2, 9 };
      Solution solution = new Solution();
      Console.WriteLine(solution.NumMagicSquaresInside(table));//1 i:2 j:1
      Console.WriteLine("Hello World!");
    }
    /*
    3x3の中には1-9のすべての数値が入っている必要がある
     */
    public int NumMagicSquaresInside(int[][] grid)
    {

      int[][] horizontal = MakeHoeizontalGrid(grid);
      int[][] vertical = MakeVerticalGrid(grid);

      int res = 0;
      for (int i = 0; i + 2 < grid.Length; i++)
      {
        for (int j = 0; j + 2 < grid[i].Length; j++)
        {
          bool chkRes = true;
          HashSet<int> map = new HashSet<int>();
          for (int wkI = i; wkI < i + 3; wkI++)
          {
            for (int wkJ = j; wkJ < j + 3; wkJ++)
            {
              if (map.Contains(grid[wkI][wkJ]) || grid[wkI][wkJ] > 9 || grid[wkI][wkJ] < 1)
              {
                chkRes = false;
                break;
              }
              map.Add(grid[wkI][wkJ]);
            }
          }
          if (!chkRes)
            continue;
          int sumH = horizontal[i][j + 2] - (j == 0 ? 0 : horizontal[i][j - 1]);
          for (int wkI = i + 1; wkI < i + 3; wkI++)
          {
            if (sumH != horizontal[wkI][j + 2] - (j == 0 ? 0 : horizontal[wkI][j - 1]))
            {
              chkRes = false;
              break;
            }
          }
          if (!chkRes)
            continue;


          int sumW = vertical[i + 2][j] - (i == 0 ? 0 : vertical[i - 1][j]);
          for (int wkJ = j + 1; wkJ < j + 3; wkJ++)
          {
            if (sumW != vertical[i + 2][wkJ] - (i == 0 ? 0 : vertical[i - 1][wkJ]))
            {
              chkRes = false;
              break;
            }
          }
          if (!chkRes)
            continue;

          if (grid[i][j] + grid[i + 1][j + 1] + grid[i + 2][j + 2]
          != grid[i + 2][j] + grid[i + 1][j + 1] + grid[i][j + 2])
            continue;

          res++;
        }
      }
      return res;
    }
    private int[][] MakeHoeizontalGrid(int[][] grid)
    {
      int[][] horizontal = new int[grid.Length][];
      for (int i = 0; i < grid.Length; i++)
      {
        horizontal[i] = new int[grid[i].Length];
        horizontal[i][0] = grid[i][0];
        for (int j = 1; j < grid[i].Length; j++)
        {
          horizontal[i][j] = grid[i][j] + horizontal[i][j - 1];
        }
      }
      return horizontal;
    }
    private int[][] MakeVerticalGrid(int[][] grid)
    {
      int[][] vertical = new int[grid.Length][];
      for (int i = 0; i < grid.Length; i++)
        vertical[i] = new int[grid[i].Length];

      for (int j = 0; j < grid[0].Length; j++)
      {
        vertical[0][j] = grid[0][j];
        for (int i = 1; i < grid.Length; i++)
        {
          vertical[i][j] = grid[i][j] + vertical[i - 1][j];
        }
      }
      return vertical;
    }

  }
}
