using System;
using System.Collections.Generic;

namespace Matrix_Cells_in_Distance_Order
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // var res = solution.AllCellsDistOrder(3, 3, 0, 2);
            var res = solution.AllCellsDistOrder(3, 4, 0, 1);
            Console.WriteLine("Hello World!");
        }
        private class Coordinate
        {
            public int r;
            public int c;
            public Coordinate(int r, int c)
            {
                this.r = r;
                this.c = c;
            }
        }
        public int[][] AllCellsDistOrder(int R, int C, int r0, int c0)
        {
            bool[,] visited = new bool[R, C];
            int[][] res = new int[R * C][];
            int wkR = r0;
            int wkC = c0;
            Queue<Coordinate> que = new Queue<Coordinate>();
            que.Enqueue(new Coordinate(0, 0));
            int cnt = 0;
            while (que.Count != 0)
            {
                var elm = que.Dequeue();
                // if (elm.r >= R || elm.c >= C)
                //     continue;
                res[cnt] = new int[] { Math.Abs(elm.r - wkR), Math.Abs(elm.c - wkC) };
                cnt++;
                visited[elm.r, elm.c] = true;

                if (elm.c + 1 < C && !visited[elm.r, elm.c + 1])
                {
                    visited[elm.r, elm.c + 1] = true;
                    que.Enqueue(new Coordinate(elm.r, elm.c + 1));
                }
                if (elm.r + 1 < R && !visited[elm.r + 1, elm.c])
                {
                    visited[elm.r + 1, elm.c] = true;
                    que.Enqueue(new Coordinate(elm.r + 1, elm.c));
                }
            }
            // for (int i = 0; i < C; i++)
            // {
            //     for (int j = 0; j < R; j++)
            //     {
            //         res[cnt] = new int[] { Math.Abs(j - wkR), Math.Abs(i - wkC) };
            //         cnt++;
            //     }
            // }
            return res;
        }
    }
}
