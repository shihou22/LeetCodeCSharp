using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[][] wk = new int[4][];
            wk[0] = new int[] { 0, 1, 0 };
            wk[1] = new int[] { 0, 0, 1 };
            wk[2] = new int[] { 1, 1, 1 };
            wk[3] = new int[] { 0, 0, 0 };
            /*
              [0,0,0],
            [1,0,1],
            [0,1,1],
            [0,1,0]
            */
            program.GameOfLife(wk);
            Console.WriteLine("Hello World!");
        }
        public void GameOfLife(int[][] board)
        {
            int[] dx = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dy = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };
            int x = board.Length;
            int y = board[0].Length;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int cnt = 0;
                    for (int k = 0; k < 8; k++)
                    {
                        int wkX = i + dx[k];
                        int wkY = j + dy[k];
                        if (wkX < 0 || wkX >= x || wkY < 0 || wkY >= y)
                            continue;
                        cnt += ConvLive(board[wkX][wkY]);
                    }
                    if (cnt < 2 || cnt > 3)
                    {
                        board[i][j] = ConvLive2(board[i][j], 0);
                    }
                    else if (cnt == 2)
                    {
                        board[i][j] = ConvLive2(board[i][j], board[i][j]);
                    }
                    else if (cnt == 3)
                    {
                        board[i][j] = ConvLive2(board[i][j], 1);
                    }
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    board[i][j] = ConvLive3(board[i][j]);
                }
            }
        }
        private int ConvLive3(int n)
        {
            int res = 0;
            switch (n)
            {
                //死んでる
                case 0:
                    res = 0;
                    break;
                //生きてる
                case 1:
                    res = 1;
                    break;
                //生きてる→生きてる
                case 2:
                    res = 1;
                    break;
                //生きてる→死んでる
                case 3:
                    res = 0;
                    break;
                //死んでる→生きてる
                case -1:
                    res = 1;
                    break;
                //死んでる→死んでる
                case -2:
                    res = 0;
                    break;
            }
            return res;
        }
        private int ConvLive2(int n, int live)
        {
            int res = 0;
            switch (n)
            {
                //死んでる
                case 0:
                    res = live == 0 ? -2 : -1;
                    break;
                //生きてる
                case 1:
                    res = live == 1 ? 2 : 3;
                    break;
            }
            return res;
        }
        private int ConvLive(int n)
        {
            int res = 0;
            switch (n)
            {
                //死んでる
                case 0:
                    res = 0;
                    break;
                //生きてる
                case 1:
                    res = 1;
                    break;
                //生きてる→生きてる
                case 2:
                    res = 1;
                    break;
                //生きてる→死んでる
                case 3:
                    res = 1;
                    break;
                //死んでる→生きてる
                case -1:
                    res = 0;
                    break;
                //死んでる→死んでる
                case -2:
                    res = 0;
                    break;
            }
            return res;
        }
    }
}
