using System;
using System.Collections.Generic;

namespace Maximum_Swap
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.MaximumSwap(2736));//7236
            Console.WriteLine(solution.MaximumSwap(9973));//9973
            Console.WriteLine(solution.MaximumSwap(98368));//98863
            Console.WriteLine(solution.MaximumSwap(1993));//9913
            Console.WriteLine("Hello World!");
        }
        public int MaximumSwap(int num)
        {
            IList<int> memo = new List<int>();
            var min = 10;
            var minI = 0;
            var max = 0;
            var maxI = 0;
            var cnt = 0;
            while (num != 0)
            {
                var tmp = num % 10;
                if (min > tmp)
                {
                    minI = cnt;
                    min = tmp;
                }
                if (max < tmp)
                {
                    maxI = cnt;
                    max = tmp;
                }
                memo.Add(tmp);
                cnt++;
                num /= 10;
            }
            for (int i = memo.Count - 1; i >= 0; i--)
            {
                var exist = false;
                var wk = memo[i];
                for (int j = 0; j < i; j++)
                {
                    if (wk < memo[j])
                    {
                        wk = memo[j];
                        minI = i;
                        maxI = j;
                        exist = true;
                    }
                }
                if (exist)
                {
                    var tmp = memo[minI];
                    memo[minI] = memo[maxI];
                    memo[maxI] = tmp;
                    break;
                }
            }
            var resWk = 0;
            for (int i = memo.Count - 1; i >= 0; i--)
            {
                resWk *= 10;
                resWk += memo[i];
            }
            return resWk;
        }

    }
}
