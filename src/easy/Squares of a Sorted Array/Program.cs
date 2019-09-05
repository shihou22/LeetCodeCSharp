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
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = A[i] * A[i];
            }
            Array.Sort(A);
            return A;
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
