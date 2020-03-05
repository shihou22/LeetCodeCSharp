using System;
using System.Linq;
using System.Collections.Generic;

namespace Numbers_With_Same_Consecutive_Differences
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // [181,292,707,818,929]
            System.Console.WriteLine(program.NumsSameConsecDiff(3, 7));
            // [10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]
            System.Console.WriteLine(program.NumsSameConsecDiff(2, 1));
            // [0,1,2,3,4,5,6,7,8,9]
            System.Console.WriteLine(program.NumsSameConsecDiff(1, 0));
            Console.WriteLine("Hello World!");
        }
        public int[] NumsSameConsecDiff(int N, int K)
        {
            res = new HashSet<int>();
            for (int i = 0; i < 10; i++)
            {
                NumsSameConsecDiff(N, N - 1, K, i);
            }
            return res.ToArray();
        }
        ISet<int> res = new HashSet<int>();
        private void NumsSameConsecDiff(int N, int currN, int K, int curr)
        {
            if (currN == 0)
            {
                if (N == 1 && curr == 0)
                {
                    res.Add(curr);
                }
                else
                {
                    int d = 0;
                    int wk = curr;
                    while (wk != 0)
                    {
                        wk /= 10;
                        d++;
                    }
                    if (N == d)
                        res.Add(curr);
                }
            }
            else
            {
                int b = curr % 10;
                if (b + K < 10)
                    NumsSameConsecDiff(N, currN - 1, K, curr * 10 + (b + K));
                if (b - K >= 0)
                    NumsSameConsecDiff(N, currN - 1, K, curr * 10 + (b - K));
            }
        }
    }
}
