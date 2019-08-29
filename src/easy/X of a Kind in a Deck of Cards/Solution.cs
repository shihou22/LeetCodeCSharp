using System;
using System.Collections.Generic;

namespace X_of_a_Kind_in_a_Deck_of_Cards
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.HasGroupsSizeX(new int[] { 1, 2, 3, 4, 4, 3, 2, 1 }));//true
            Console.WriteLine(solution.HasGroupsSizeX(new int[] { 1, 1, 1, 2, 2, 2, 3, 3 }));//false
            Console.WriteLine(solution.HasGroupsSizeX(new int[] { 1 }));//false
            Console.WriteLine(solution.HasGroupsSizeX(new int[] { 1, 1 }));//true
            Console.WriteLine(solution.HasGroupsSizeX(new int[] { 1, 1, 2, 2, 2, 2 }));//true
            Console.WriteLine("Hello World!");
        }
        public bool HasGroupsSizeX(int[] deck)
        {
            Array.Sort(deck);
            IList<int> wk = new List<int>();
            int cnt = 0;
            for (int i = 0; i < deck.Length; i++)
            {
                if (i < deck.Length - 1)
                {
                    if (deck[i + 1] != deck[i])
                    {
                        cnt++;
                        wk.Add(cnt);
                        cnt = 0;
                    }
                    else
                    {
                        cnt++;
                    }
                }
                else
                {
                    cnt++;
                    wk.Add(cnt);
                }

            }

            int gcd = wk[0];
            foreach (var item in wk)
            {
                gcd = GetGCD(gcd, item);
            }
            return gcd > 1;
        }

        private int GetGCD(int a, int b)
        {
            int max = Math.Max(a, b);
            int min = Math.Min(a, b);
            int mod = max % min;
            while (mod != 0)
            {
                max = min;
                min = mod;
                mod = max % min;
            }
            return min;
        }
    }
}
