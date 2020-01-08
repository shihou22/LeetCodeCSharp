using System;

namespace Find_N_Unique_Integers_Sum_up_to_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] SumZero(int n)
        {
            int[] res = new int[n];
            if (n % 2 == 0)
                res[n / 2] = 0;
            for (int i = 0; i < n / 2; i++)
            {
                res[i] = n - i;
                res[n - 1 - i] = -(n - i);
            }
            return res;
        }

        public int[] SumZero2(int n)
        {
            int[] res = new int[n];
            for (int i = 0; i <= n - 2; i += 2)
            {
                res[i] = n - i;
                res[i + 1] = -(n - i);
            }
            return res;
        }
    }
}
