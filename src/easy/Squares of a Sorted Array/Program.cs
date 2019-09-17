using System;

namespace Squares_of_a_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[] res = null;
            // [0,1,9,16,100]
            res = program.SortedSquares(new int[] { -4, -1, 0, 3, 10 });
            // [4,9,9,49,121]
            res = program.SortedSquares(new int[] { -7, -3, 2, 3, 11 });
            Console.WriteLine("Hello World!");
        }
        public int[] SortedSquares(int[] A)
        {
            int[] ret = new int[A.Length];
            int i = 0;
            int j = A.Length - 1;
            int insI = A.Length - 1;
            while (i <= j)
            {
                int left = Math.Abs(A[i]);
                int right = Math.Abs(A[j]);
                if (left > right)
                {
                    ret[insI] = A[i] * A[i];
                    i++;
                }
                else
                {
                    ret[insI] = A[j] * A[j];
                    j--;
                }
                insI--;
            }
            return ret;
        }
        public int[] SortedSquaresOld(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = A[i] * A[i];
            }
            Array.Sort(A);
            return A;
        }
    }
}
