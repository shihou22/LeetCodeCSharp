using System;
using System.Linq;
using System.Collections.Generic;

namespace Ones_and_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // 4
            Console.WriteLine(program.FindMaxForm(new string[] { "10", "0001", "111001", "1", "0" }, 5, 3));
            // 2
            Console.WriteLine(program.FindMaxForm(new string[] { "10", "0", "1" }, 1, 1));
            // 3
            Console.WriteLine(program.FindMaxForm(new string[] { "10", "0001", "111001", "1", "0" }, 3, 4));
            // 45
            Console.WriteLine(program.FindMaxForm(new string[] { "011", "1", "11", "0", "010", "1", "10", "1", "1", "0", "0", "0", "01111", "011", "11", "00", "11", "10", "1", "0", "0", "0", "0", "101", "001110", "1", "0", "1", "0", "0", "10", "00100", "0", "10", "1", "1", "1", "011", "11", "11", "10", "10", "0000", "01", "1", "10", "0" }, 44, 39));
            // 35
            Console.WriteLine(program.FindMaxForm(new string[] { "0", "0", "0", "0", "0", "1", "1", "0", "1", "1", "1", "0", "1", "0", "1", "1", "0", "0", "1", "0", "1", "1", "0", "1", "1", "1", "1", "1", "0", "1", "1", "1", "1", "1", "1", "0", "1", "1", "0", "0", "0", "0", "1", "1", "0", "1" }, 52, 12));
            Console.WriteLine("Hello World!");
        }
        public int FindMaxForm(string[] strs, int m, int n)
        {
            if (strs == null || strs.Length == 0)
                return 0;
            int[][] comp = strs.Select(s =>
           {
               int zero = s.Where(x => x == '0').Count();
               int one = s.Where(x => x == '1').Count();
               return new int[] { zero, one };
           }).ToArray();

            int[,,] dp = new int[comp.Length + 1, m + 1, n + 1];
            for (int i = 1; i <= comp.Length; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    for (int k = 0; k <= n; k++)
                    {
                        int[] curr = comp[i - 1];
                        dp[i, j, k] = Math.Max(dp[i, j, k], dp[i - 1, j, k]);
                        if (j >= curr[0] && k >= curr[1])
                        {
                            dp[i, j, k] = Math.Max(dp[i, j, k], dp[i - 1, j - curr[0], k - curr[1]] + 1);
                        }
                    }
                }
            }
            return dp[comp.Length, m, n];
        }
        public int FindMaxFormTLE(string[] strs, int m, int n)
        {
            res = 0;
            Array.Sort(strs);
            List<Elm> elms = strs.Select(s => new Elm(s)).Where(e => (e.m <= m && e.n <= n)).ToList();
            int wkM = elms.Select(s => s.m).Sum();
            int wkN = elms.Select(s => s.n).Sum();
            if (wkM <= m && wkN <= n)
                return elms.Count;

            int num = elms.Count;
            zero = new int[num];
            zero[num - 1] = elms[num - 1].m;
            one = new int[num];
            one[num - 1] = elms[num - 1].n;
            for (int i = num - 2; i >= 0; i--)
            {
                int pre = i + 1;
                zero[i] = zero[pre] + elms[i].m;
                one[i] = one[pre] + elms[i].n;
            }
            DFS(elms, m, n, 0, 0);
            return res;
        }
        private int res = 0;
        int[] zero;
        int[] one;
        private void DFS(List<Elm> elms, int m, int n, int size, int curr)
        {
            if (m < 0 || n < 0)
                return;
            if (m >= 0 && n >= 0)
                res = Math.Max(res, size);

            if ((curr >= elms.Count)
            || (size + (elms.Count - curr) < res))
                return;

            Elm e = elms[curr];
            DFS(elms, m - e.m, n - e.n, size + 1, curr + 1);
            DFS(elms, m, n, size, curr + 1);
        }
    }
    class Elm
    {
        public string str { get; }
        public int m { get; }
        public int n { get; }
        public Elm(string str)
        {
            this.str = str;
            foreach (var item in str)
            {
                if (item - '0' == 0)
                    m++;
                else
                    n++;
            }
        }
    }
}
