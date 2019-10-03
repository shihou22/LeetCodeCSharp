using System;
using System.Collections.Generic;

namespace N_Repeated_Element_in_Size_2N_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.RepeatedNTimes(new int[]{2, 1, 2, 5, 3, 2 }));
            Console.WriteLine("Hello World!");
        }
        public int RepeatedNTimes(int[] A)
        {
            int n = A.Length / 2;
            Array.Sort(A);
            Dictionary<int, int> memo = new Dictionary<int, int>();
            for (int i = n - 2; i <= n + 1; i++)
            {
                if (memo.ContainsKey(A[i]))
                    memo[A[i]]++;
                else
                    memo.Add(A[i], 1);
                if (memo[A[i]] == 2)
                    return A[i];
            }
            return -1;
        }
    }
}
