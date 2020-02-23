using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Word_Search
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
      char[][] board1 = GridCreator.CreateCharGrid("[  [A,B,C,E],  [S,F,C,S],  [A,D,E,E]]");
      // true
      Console.WriteLine(program.Exist(board1, "ABCCED"));
      // true
      Console.WriteLine(program.Exist(board1, "SEE"));
      // false
      Console.WriteLine(program.Exist(board1, "ABCB"));
      Console.WriteLine("Hello World!");
    }
    public bool Exist(char[][] board, string word)
    {
      if (board.Length == 0 || board[0].Length == 0 || word.Length == 0)
        return false;

      char s = word[0];
      bool[][] visited = new bool[board.Length][];
      for (int i = 0; i < board.Length; i++)
        visited[i] = new bool[board[0].Length];

      for (int i = 0; i < board.Length; i++)
      {
        for (int j = 0; j < board[0].Length; j++)
        {
          if (board[i][j] == s)
          {
            visited[i][j] = true;
            if (DFS(board, visited, i, j, word, 0))
              return true;
            visited[i][j] = false;
          }
        }
      }
      return false;
    }
    private bool DFS(char[][] board, bool[][] visited, int i, int j, string word, int curr)
    {
      if (board[i][j] != word[curr])
        return false;
      if (curr == word.Length - 1)
        return true;

      int[] dh = new int[4] { 0, 1, -1, 0 };
      int[] dw = new int[4] { 1, 0, 0, -1 };
      for (int d = 0; d < 4; d++)
      {
        int wh = i + dh[d];
        int ww = j + dw[d];
        if (wh < 0 || ww < 0 || wh >= board.Length || ww >= board[0].Length || visited[wh][ww])
          continue;
        visited[wh][ww] = true;
        if (DFS(board, visited, wh, ww, word, curr + 1))
          return true;
        visited[wh][ww] = false;
      }
      return false;
    }
  }

}
