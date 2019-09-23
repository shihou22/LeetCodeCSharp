using System.Data.SqlTypes;
using System;

namespace Flood_Fill
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //   int[][] wk = new int[3][];
      //   wk[0] = new int[] { 1, 1, 1 };
      //   wk[1] = new int[] { 1, 1, 0 };
      //   wk[2] = new int[] { 1, 0, 1 };
      //   var res = program.FloodFill(wk, 1, 1, 2);
      int[][] wk1 = new int[2][];
      wk1[0] = new int[] { 0, 0, 0 };
      wk1[1] = new int[] { 0, 1, 1 };
      var res1 = program.FloodFill(wk1, 1, 1, 1);
      Console.WriteLine("Hello World!");
    }
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
      bool[][] visited = new bool[image.Length][];
      for (int i = 0; i < visited.Length; i++)
      {
        visited[i] = new bool[image[0].Length];
      }
      ReColor(image, sr, sc, newColor, image[sr][sc], visited);
      return image;
    }
    private void ReColor(int[][] image, int sr, int sc, int newColor, int baseColor, bool[][] visited)
    {
      if (sr >= image.Length || sr < 0 || sc >= image[0].Length || sc < 0)
        return;
      if (visited[sr][sc] || image[sr][sc] != baseColor)
        return;
      image[sr][sc] = newColor;
      visited[sr][sc] = true;
      int[] d = new int[] { 0, 1, 0, -1 };
      for (int i = 0; i < d.Length; i++)
      {
        int wkX = d[i];
        int wkY = d[i ^ 1];
        ReColor(image, sr + wkX, sc + wkY, newColor, baseColor,visited);
      }
    }
  }
}
