using System;
using System.Collections.Generic;

namespace Integer_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.IntegerBreakDP(6));
            // Console.WriteLine(program.IntegerBreakDP(10));
            // Console.WriteLine(program.IntegerBreakDP(5));
            Console.WriteLine(program.IntegerBreakIterable(6));
            Console.WriteLine(program.IntegerBreakIterable(10));
            Console.WriteLine(program.IntegerBreakIterable(5));
            Console.WriteLine("Hello World!");
        }
        public int IntegerBreakIterable(int n)
        {
            if (n <= 3)
                return n - 1;

            int res = 0;
            for (int i = 2; i < n; i++)
            {
                int cnt = 1;
                while (i * cnt < n)
                {
                    int p = i * cnt;
                    res = Math.Max((int)Math.Pow(i, cnt) * (n - p), res);
                    cnt++;
                }
            }
            return res;
        }

        public int IntegerBreakDP(int n)
        {
            if (n <= 3)
                return n - 1;

            int[] dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                /*
                1 * i の時の値が初期値
                1 * i = i　なので先に埋めておく
                */
                dp[i] = i;
                /*
                dp[i - j] * j
                dp[i - j] -> dp[i]からj個前の値
                例えば、
                dp[10 - 4] * 4 -> dp[6]の時の最大の値 * 4
                dp[6]の時の最大の値がどのような構成なのかは不明のように見えるが、
                3 + 3 = 6 -> 3 * 3 
                2 + 4 = 6 -> 2 * 4
                そもそもdp[6]の値自体が、二つ以上の正の整数値の集合なのでそこにかけたら「2個以上の正の整数」は維持可能
                2個以上の正の整数   ->  2種類以上の正の整数　ではない。
                */
                for (int j = 1; j <= i; j++)
                {
                    /*
                    dp[i] = i時点の最大値
                    最大値に不足の数を書けると最大となる

                    dp[3] = dp[3-1] * 1
                    dp[3] = dp[3-2] * 2
                    dp[3] = dp[3-3] * 3
                    */
                    dp[i] = Math.Max(dp[i], dp[i - j] * j);
                }
            }
            return dp[n];
        }
    }
}
