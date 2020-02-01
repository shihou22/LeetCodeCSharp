using System;
using System.Linq;
using System.Collections.Generic;

namespace Counting_Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //[0,1,1]
            var res1 = program.CountBits(2);
            //[0,1,1,2,1,2]
            var res2 = program.CountBits(5);
            var res3 = program.CountBits(4);
            Console.WriteLine("Hello World!");
        }
        public int[] CountBits(int num)
        {
            int[] dp = new int[num + 1];
            dp[0] = 0;
            for (int i = 1; i <= num; i++)
            {
                dp[i] = dp[i & (i - 1)] + 1;
            }
            return dp;
        }
        public int[] CountBitsSpecial(int num)
        {
            IList<int> res = new List<int>();
            for (int i = 0; i <= num; i++)
            {
                int bits = i;
                bits = (bits & 0x55555555) + (bits >> 1 & 0x55555555);
                bits = (bits & 0x33333333) + (bits >> 2 & 0x33333333);
                bits = (bits & 0x0f0f0f0f) + (bits >> 4 & 0x0f0f0f0f);
                bits = (bits & 0x00ff00ff) + (bits >> 8 & 0x00ff00ff);
                res.Add((bits & 0x0000ffff) + (bits >> 16 & 0x0000ffff));
            }
            return res.ToArray();
        }
        public int[] CountBitsSlow(int num)
        {
            IList<int> res = new List<int>();
            for (int i = 0; i <= num; i++)
            {
                int cnt = 0;
                int wk = i;
                while (wk != 0)
                {
                    cnt++;
                    wk = wk & (wk - 1);
                }
                res.Add(cnt);
            }
            return res.ToArray();
        }
    }
}
