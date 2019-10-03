using System;
using System.Linq;

namespace Sum_of_Even_Numbers_After_Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[] A = new int[] { 1, 2, 3, 4 };
            int[][] Q = new int[4][];
            Q[0] = new int[2] { 1, 0 };
            Q[1] = new int[2] { -3, 1 };
            Q[2] = new int[2] { -4, 0 };
            Q[3] = new int[2] { 2, 3 };
            Console.WriteLine(program.SumEvenAfterQueries(A, Q));
            Console.WriteLine("Hello World!");
        }
        public int[] SumEvenAfterQueries(int[] A, int[][] queries)
        {
            int n = queries.Length;
            int total = 0;
            foreach (var item in A)
            {
                if (item % 2 == 0)
                    total += item;
            }
            int[] res = new int[n];
            int index = 0;
            foreach (var item in queries)
            {
                int aI = item[1];
                int num = item[0];

                bool eveOdd1 = A[aI] % 2 == 0;
                bool eveOdd2 = (A[aI] + num) % 2 == 0;
                if (eveOdd1 && eveOdd2)
                {
                    A[aI] += num;
                    total += num;
                }
                else if (!eveOdd1 && eveOdd2)
                {
                    A[aI] += num;
                    total += A[aI];
                }
                else if (eveOdd1 && !eveOdd2)
                {
                    total -= A[aI];
                    A[aI] += num;

                }
                else if (!eveOdd1 && !eveOdd2)
                {
                    A[aI] += num;
                }

                res[index] = total;
                index++;
            }
            return res;
        }
    }
}
