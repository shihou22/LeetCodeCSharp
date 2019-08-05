using System;
using System.Collections.Generic;
using System.Linq;

namespace Number_of_Equivalent_Domino_Pairs
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // int[,] varl = { { 1, 2 }, { 2, 1 }, { 3, 4 }, { 5, 6 } };
            int[][] varl = new int[][]
            {
                new[]{ 1, 2 },
                new[]{ 2, 1 },
                new[]{ 3, 4 },
                new[]{ 5, 6 }
            };
            Console.WriteLine(solution.NumEquivDominoPairs(varl));
            Console.WriteLine("Hello World!");
        }
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            // Dictionary<string, int> set = new Dictionary<string, int>();
            Dictionary<int, int> set = new Dictionary<int, int>();
            foreach (var item in dominoes)
            {
                // Array.Sort(item);
                // var key = string.Join("-", item);
                // var key = item[0] < item[1] ? item[0] + "-" + item[1] : item[1] + "-" + item[0];

                /*
                1 <= dominoes[i][j] <= 9
                We can use [0]*10+[1]
                if this range is 1 <= dominoes[i][j] <= 99
                We can't use [0]*10+[1]
                 */
                var key = item[0] < item[1] ? item[0] * 10 + item[1] : item[1] * 10 + item[0];
                if (set.ContainsKey(key))
                    set[key]++;
                else
                    set.Add(key, 0);
            }
            int res = 0;
            foreach (var item in set.Values)
            {
                if (item > 0)
                    res += combination(item + 1);
            }
            return res;
        }
        private int combination(int x)
        {
            return (x * (x - 1)) / 2;
        }
    }
}
