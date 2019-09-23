using System;

namespace Available_Captures_for_Rook
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int NumRookCaptures(char[][] board)
    {
      int row = 0;
      int col = 0;
      for (int i = 0; i < board.Length; i++)
      {
        for (int j = 0; j < board[0].Length; j++)
        {
          if (board[i][j] == 'R')
          {
            row = i;
            col = j;
            break;
          }
        }
      }
      int capture = 0;
      for (int i = col; i < board[0].Length; i++)
      {
        if (board[row][i] == 'B')
        {
          break;
        }
        else if (board[row][i] == 'p')
        {
          capture++;
          break;
        }
      }

      for (int i = col; i >= 0; i--)
      {
        if (board[row][i] == 'B')
        {
          break;

        }
        else if (board[row][i] == 'p')
        {
          capture++;
          break;
        }
      }
      for (int i = row; i < board.Length; i++)
      {
        if (board[i][col] == 'B')
        {
          break;
        }
        else if (board[i][col] == 'p')
        {
          capture++;
          break;
        }
      }

      for (int i = row; i >= 0; i--)
      {
        if (board[i][col] == 'B')
        {
          break;

        }
        else if (board[i][col] == 'p')
        {
          capture++;
          break;
        }
      }
      return capture;
    }
  }
}
