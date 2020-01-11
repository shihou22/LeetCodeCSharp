using System;

namespace Find_Winner_on_a_Tic_Tac_Toe_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[][] arg = new int[5][];
            arg[0] = new int[] { 0, 0 };
            arg[1] = new int[] { 2, 0 };
            arg[2] = new int[] { 1, 1 };
            arg[3] = new int[] { 2, 1 };
            arg[4] = new int[] { 2, 2 };

            // Console.WriteLine(program.Tictactoe(arg));
            arg = new int[6][];
            arg[0] = new int[] { 0, 0 };
            arg[1] = new int[] { 1, 1 };
            arg[2] = new int[] { 0, 1 };
            arg[3] = new int[] { 0, 2 };
            arg[4] = new int[] { 1, 0 };
            arg[5] = new int[] { 2, 0 };
            Console.WriteLine(program.Tictactoe(arg));
            Console.WriteLine("Hello World!");
        }
        public string Tictactoe(int[][] moves)
        {
            int[][] map = new int[3][];
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = new int[3];
                Array.Fill(map[i], -1);
            }
            int cnt = 1;
            foreach (var item in moves)
            {
                map[item[0]][item[1]] = (cnt % 2);
                cnt++;
            }
            int winC = -1;
            bool win = false;
            for (int i = 0; i < 3; i++)
            {
                win = true;
                int c = map[i][0];
                if (c == -1)
                    continue;
                winC = c;
                for (int j = 1; j < 3; j++)
                {
                    if (map[i][j] != c)
                        win = false;
                }
                if (win)
                    return c == 1 ? "A" : "B";
            }
            for (int i = 0; i < 3; i++)
            {
                win = true;
                int c = map[0][i];
                if (c == -1)
                    continue;
                winC = c;
                for (int j = 1; j < 3; j++)
                {
                    if (map[j][i] != c)
                        win = false;
                }
                if (win)
                    return c == 1 ? "A" : "B";
            }
            win = map[0][0] != -1 && map[0][0] == map[1][1] && map[1][1] == map[2][2];
            if (win)
                return map[0][0] == 1 ? "A" : "B";
            win = map[0][2] != -1 && map[0][2] == map[1][1] && map[1][1] == map[2][0];
            if (win)
                return map[0][2] == 1 ? "A" : "B";

            return moves.Length < 9 ? "Pending" : "Draw";
        }
    }
}
