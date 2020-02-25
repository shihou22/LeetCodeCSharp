using System;

namespace Champagne_Tower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            double[,] glasses = new double[102, 102];
            glasses[0, 0] = poured;
            for (int i = 0; i < query_row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    double p = (glasses[i, j] - 1L) / 2L;
                    if (p > 0L)
                    {
                        glasses[i + 1, j] += p;
                        glasses[i + 1, j + 1] += p;
                    }
                }
            }
            return Math.Min(1, glasses[query_row, query_glass]);


        }

    }
}
