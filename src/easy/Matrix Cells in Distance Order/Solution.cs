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
            List<int[]> res = new List<int[]>();
            Queue<Coordinate> que = new Queue<Coordinate>();
            bool[,] visited = new bool[R, C];

            que.Enqueue(new Coordinate(r0, c0));
            visited[r0, c0] = true;
            int[] d = new int[] { 0, 1, 0, -1 };
            while (que.Count > 0)
            {
                Coordinate current = que.Dequeue();
                res.Add(new int[] { current.r, current.c });
                for (int i = 0; i < d.Length; i++)
                {
                    int wkR = current.r + d[i];
                    int wkC = current.c + d[i ^ 1];
                    if (wkR >= 0 && wkR < R && wkC >= 0 && wkC < C && !visited[wkR, wkC])
                    {
                        que.Enqueue(new Coordinate(wkR, wkC));
                        visited[wkR, wkC] = true;
                    }
                    // AddQueue(R, C, current.r - 1, current.c, visited, que);
                    // AddQueue(R, C, current.r + 1, current.c, visited, que);
                    // AddQueue(R, C, current.r, current.c - 1, visited, que);
                    // AddQueue(R, C, current.r, current.c + 1, visited, que);
                }
            }
            return res.ToArray();
        }

    }
}
