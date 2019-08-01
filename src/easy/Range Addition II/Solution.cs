using System;
using System.Linq;

namespace Range_Addition_II
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxCount(int m, int n, int[][] ops)
        {
            int mMax = m;
            int nMax = n;

            foreach (var item in ops)
            {
                mMax = Math.Min(mMax, item[0]);
                nMax = Math.Min(nMax, item[1]);
            }
            return mMax * nMax;
        }
        public int MaxCountOOM(int m, int n, int[][] ops)
        {
            int[,] map = new int[m, n];
            for (int i = 0; i < ops.Length; i++)
            {
                int[] wk = ops[i];
                for (int j = 0; j < wk[0]; j++)
                {
                    for (int k = 0; k < wk[1]; k++)
                    {
                        map[j, k]++;
                    }
                }
            }
            int max = 0;
            foreach (var item in map)
            {
                max = Math.Max(max, item);
            }
            int res = 0;
            foreach (var item in map)
            {
                if (item == max)
                    res++;
            }
            return res;
        }
    }
}
