using System;

namespace Out_of_Boundary_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindPaths(int m, int n, int N, int i, int j)
        {
            int[][][] memo = new int[m][][];
            for (int d1 = 0; d1 < m; d1++)
            {
                memo[d1] = new int[n][];
                for (int d2 = 0; d2 < n; d2++)
                {
                    memo[d1][d2] = new int[N + 1];
                    Array.Fill(memo[d1][d2], -1);
                }
            }
            int MOD = 1000000007;
            return DFS(m, n, N, i, j, memo, MOD);
        }
        public int DFS(int m, int n, int N, int i, int j, int[][][] memo, int MOD)
        {
            if (i >= m || j >= n || i < 0 || j < 0)
                return 1;
            if (N == 0)
                return 0;
            if (memo[i][j][N] >= 0)
                return memo[i][j][N];
            var d1 = DFS(m, n, N - 1, i + 1, j, memo, MOD);
            var d2 = DFS(m, n, N - 1, i - 1, j, memo, MOD);
            var d3 = DFS(m, n, N - 1, i, j + 1, memo, MOD);
            var d4 = DFS(m, n, N - 1, i, j - 1, memo, MOD);
            memo[i][j][N] = ((d1 + d2) % MOD + (d3 + d4) % MOD) % MOD;
            return memo[i][j][N];
        }
    }
}
