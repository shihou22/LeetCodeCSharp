using System.Collections.Generic;
using System;
using System.Linq;

namespace Valid_Sudoku
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public bool IsValidSudoku(char[][] board)
    {
      for (int i = 0; i < board.Length; i++)
      {
        #region 水平
        IEnumerable<IGrouping<char, char>> horizontal = board[i].Where(x => x != '.').GroupBy(x => x);
        foreach (var group in horizontal)
        {
          if (group.Count() > 1)
            return false;
        }
        #endregion 水平完了

        #region　垂直
        ISet<int> set = new HashSet<int>();
        for (int j = 0; j < board.Length; j++)
        {
          char c = board[j][i];
          if (c == '.')
            continue;
          if (set.Contains(c))
            return false;
          set.Add(c);
        }
        #endregion　垂直完了

        #region　水平に3個/iを縦の番号とみなして横を探る
        if (i % 3 != 0)
          continue;

        for (int j = 0; j < board[i].Length; j += 3)
        {
          set.Clear();
          for (int i2 = i; i2 < i + 3; i2++)
          {
            for (int j2 = j; j2 < j + 3; j2++)
            {
              char c = board[i2][j2];
              if (c == '.')
                continue;
              if (set.Contains(c))
                return false;
              set.Add(c);
            }
          }
        }
        #endregion 水平3個完了
      }
      return true;
    }
  }
}
