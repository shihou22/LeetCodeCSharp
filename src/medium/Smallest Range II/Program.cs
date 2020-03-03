using System;

namespace Smallest_Range_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int SmallestRangeII(int[] A, int K)
        {
            Array.Sort(A);
            int res = A[A.Length - 1] - A[0];
            for (int i = 0; i < A.Length - 1; i++)
            {
                int high = Math.Max(A[A.Length - 1] - K, A[i] + K);
                int low = Math.Min(A[0] + K, A[i + 1] - K);
                res = Math.Min(res, high - low);
            }
            return res;
        }
    }
}
