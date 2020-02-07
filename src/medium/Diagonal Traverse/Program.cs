using System.Linq;
using System.Collections.Generic;
using System;

namespace Diagonal_Traverse
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      int[][] graph = new int[3][];
      graph[0] = new int[] { 1, 2, 3 };
      graph[1] = new int[] { 4, 5, 6 };
      graph[2] = new int[] { 7, 8, 9 };
      var res1 = program.FindDiagonalOrder(graph);
      graph = new int[2][];
      graph[0] = new int[] { 1, 2 };
      graph[1] = new int[] { 3, 4 };
      var res2 = program.FindDiagonalOrder(graph);
      Console.WriteLine("Hello World!");
    }
    public int[] FindDiagonalOrder(int[][] matrix)
    {
      if (matrix.Length == 0 || matrix[0].Length == 0)
        return new int[] { };
      int h = matrix.Length;
      int w = matrix[0].Length;
      int cnt = h * w;
      int curH = 0;
      int curW = 0;
      bool isUp = true;
      IList<int> res = new List<int>();
      while (cnt > 0)
      {
        res.Add(matrix[curH][curW]);
        if (isUp)
        {
          int wkH = curH - 1;
          int wkW = curW + 1;
          if (wkH < 0 && wkW < w)
          {
            isUp = false;
            curH = 0;
            curW = wkW;
          }
          else if (wkH < 0 && wkW >= w)
          {
            isUp = false;
            curH = curH + 1;
          }
          else if (wkH >= 0 && wkW >= w)
          {
            isUp = false;
            curH = curH + 1;
          }
          else
          {
            curH = wkH;
            curW = wkW;
          }
        }
        else
        {
          int wkH = curH + 1;
          int wkW = curW - 1;
          if (wkH < h && wkW < 0)
          {
            isUp = true;
            curH = wkH;
            curW = 0;
          }
          else if (wkH >= h && wkW < 0)
          {
            isUp = true;
            curW = curW + 1;
          }
          else if (wkH >= h && wkW >= 0)
          {
            isUp = true;
            curW = curW + 1;
          }
          else
          {
            curH = wkH;
            curW = wkW;
          }
        }
        cnt--;
      }
      return res.ToArray();
    }
  }
}
