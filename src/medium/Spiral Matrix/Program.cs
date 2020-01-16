using System;
using System.Collections.Generic;

namespace Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program program = new Program();
            // int[][] matrix = new int[3][];
            // matrix[0] = new int[] { 1, 2, 3 };
            // matrix[1] = new int[] { 4, 5, 6 };
            // matrix[2] = new int[] { 7, 8, 9 };
            // var res = program.SpiralOrder(matrix);
            Program program = new Program();
            int[][] matrix = new int[0][];
            var res = program.SpiralOrder(matrix);
            Console.WriteLine("Hello World!");
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> res = new List<int>();
            if (matrix == null || (matrix.Length == 0 || matrix[0].Length == 0))
                return res;
            int h = matrix.Length;
            int w = matrix[0].Length;
            bool[][] visited = new bool[h][];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = new bool[w];

            int[] dh = { 0, 1, 0, -1 };
            int[] dw = { 1, 0, -1, 0 };
            int cH = 0;
            int cW = 0;
            int d = 0;
            for (int i = 0; i < h * w; i++)
            {
                res.Add(matrix[cH][cW]);
                visited[cH][cW] = true;
                int wkH = cH + dh[d];
                int wkW = cW + dw[d];
                if (0 <= wkH && wkH < h && 0 <= wkW && wkW < w && !visited[wkH][wkW])
                {
                    //進める
                    cH = wkH;
                    cW = wkW;
                }
                else
                {
                    //次は方向転換
                    d = (d + 1) % 4;
                    cH += dh[d];
                    cW += dw[d];
                }
            }
            return res;
        }

        public IList<int> SpiralOrderIteration(int[][] matrix)
        {
            IList<int> res = new List<int>();
            if (matrix == null || (matrix.Length == 0 || matrix[0].Length == 0))
                return res;
            int h = 0;
            int w = 0;
            int total = 0;
            int n = matrix.Length * matrix[0].Length;
            int minH = 0;
            int minW = 0;
            int maxH = matrix.Length - 1;
            int maxW = matrix[0].Length - 1;
            int d = 1;
            while (total < n)
            {

                if (d == 1 && h == minH && w == maxW)
                {
                    d = 2;
                    minH++;
                }
                else if (d == 2 && h == maxH && w == maxW)
                {
                    d = 3;
                    maxW--;
                }
                else if (d == 3 && h == maxH && w == minW)
                {
                    d = 4;
                    maxH--;
                }
                else if (d == 4 && h == minH && w == minW)
                {
                    d = 1;
                    minW++;
                }

                res.Add(matrix[h][w]);
                total++;

                switch (d)
                {
                    case 1:
                        w++;
                        break;
                    case 2:
                        h++;
                        break;
                    case 3:
                        w--;
                        break;
                    case 4:
                        h--;
                        break;
                }
            }
            return res;

        }
    }
}
