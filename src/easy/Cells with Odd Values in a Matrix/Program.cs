using System;

namespace Cells_with_Odd_Values_in_a_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[][] wk = new int[2][];
            wk[0] = new int[] { 0, 1 };
            wk[1] = new int[] { 1, 1 };
            Console.WriteLine(program.OddCells(2, 3, wk));
            Console.WriteLine("Hello World!");
        }
        public int OddCells(int n, int m, int[][] indices)
        {
            int[,] wk = new int[n, m];
            foreach (var item in indices)
            {
                int r = item[0];
                int c = item[1];
                for (int i = 0; i < m; i++)
                {
                    wk[r, i]++;
                }
                for (int i = 0; i < n; i++)
                {
                    wk[i, c]++;
                }
            }
            int total = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    total += wk[i, j] % 2 != 0 ? 1 : 0;
                }
            }
            return total;
        }
    }
}
