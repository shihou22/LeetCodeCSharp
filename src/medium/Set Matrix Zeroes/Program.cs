using System;
using System.Collections.Generic;

namespace Set_Matrix_Zeroes
{
    public class Pair<K, V>
    {
        public K key;
        public V val;
        public Pair(K key, V val)
        {
            this.key = key;
            this.val = val;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public void SetZeroes(int[][] matrix)
        {
            int x = matrix.Length;
            int y = matrix[0].Length;
            int[] wk = new int[x + y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        wk[i] = 1;
                        wk[x + j] = 1;
                    }
                }
            }

            for (int i = 0; i < wk.Length; i++)
            {
                if (wk[i] == 1)
                {
                    if (i < x)
                    {
                        for (int k = 0; k < y; k++)
                            matrix[i][k] = 0;
                    }
                    else
                    {
                        for (int k = 0; k < x; k++)
                            matrix[k][i - x] = 0;
                    }

                }
            }

        }
        public void SetZeroes_1(int[][] matrix)
        {
            int x = matrix.Length;
            int y = matrix[0].Length;
            int[] wk = new int[x + y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        wk[i] = 1;
                        wk[x + j] = 1;
                    }
                }
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (wk[i] == 1 && wk[x + j] == 1)
                    {
                        for (int k = 0; k < x; k++)
                        {
                            matrix[k][j] = 0;
                        }
                        for (int k = 0; k < y; k++)
                        {
                            matrix[i][k] = 0;
                        }
                    }
                }
            }

        }
        public void SetZeroesOM(int[][] matrix)
        {
            int x = matrix.Length;
            int y = matrix[0].Length;
            IList<Pair<int, int>> list = new List<Pair<int, int>>();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        list.Add(new Pair<int, int>(i, j));
                    }
                }
            }
            foreach (var item in list)
            {
                if (matrix[item.key][item.val] == 0)
                {
                    for (int k = 0; k < x; k++)
                    {
                        matrix[k][item.val] = 0;
                    }
                    for (int k = 0; k < y; k++)
                    {
                        matrix[item.key][k] = 0;
                    }
                }
            }

        }
    }
}
