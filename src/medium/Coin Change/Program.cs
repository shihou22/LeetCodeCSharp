using System;
using System.Collections.Generic;

namespace Coin_Change
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.CoinChange(new int[] { 1, 2, 5 }, 11));//3
            // Console.WriteLine(program.CoinChange(new int[] { 2 }, 3));//-1
            Console.WriteLine(program.CoinChange(new int[] { 2147483647 }, 2));//-1
            Console.WriteLine("Hello World!");
        }
        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            Array.Sort(coins);
            dp[0] = 0;
            // dp[coins[0]] = 1;
            for (int i = 0; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if ((long)i + (long)coins[j] <= (long)amount)
                        dp[i + coins[j]] = Math.Min(dp[i] + 1, dp[i + coins[j]]);
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }
        public int CoinChangeMorau(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i - coins[j] >= 0)
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

    }
}
