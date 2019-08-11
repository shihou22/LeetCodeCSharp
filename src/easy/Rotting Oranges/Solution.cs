using System.Collections.Generic;
using System;

namespace Rotting_Oranges
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      int[][] table = new int[3][];
      table[0] = new int[] { 2, 1, 1 };
      table[1] = new int[] { 0, 1, 1 };
      table[2] = new int[] { 1, 0, 1 };
      Console.WriteLine(solution.OrangesRotting(table));
      Console.WriteLine("Hello World!");
    }


    public int OrangesRotting(int[][] grid)
    {
      Queue<KeyValuePair<int, int>> que = new Queue<KeyValuePair<int, int>>();
      int total = 0;
      for (int i = 0; i < grid.Length; i++)
      {
        for (int j = 0; j < grid[i].Length; j++)
        {
          if (grid[i][j] == 2)
            que.Enqueue(new KeyValuePair<int, int>(i, j));

          if (grid[i][j] == 1)
            total++;
        }
      }

      int res = 0;
      int[] d = new int[] { 0, 1, 0, -1 };
      while (que.Count > 0)
      {
        int count = que.Count;
        for (int i = 0; i < count; i++)
        {
          KeyValuePair<int, int> elm = que.Dequeue();
          for (int j = 0; j < d.Length; j++)
          {
            int dX = elm.Key + d[j];
            int dY = elm.Value + d[j ^ 1];
            if (dX < 0 || dX >= grid.Length || dY < 0 || dY >= grid[0].Length)
              continue;
            if (grid[dX][dY] == 0 || grid[dX][dY] == 2)
              continue;
            que.Enqueue(new KeyValuePair<int, int>(dX, dY));
            grid[dX][dY] = 2;
            total--;
          }
        }
        if (que.Count > 0)
          res++;
      }
      return total == 0 ? res : -1;
    }
  }
}
