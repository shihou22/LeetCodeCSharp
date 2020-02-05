using System;
using System.Collections.Generic;

namespace Unique_Paths_II
{

    class Pair
    {
        public int x { get; }
        public int y { get; }
        public Pair(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Pair GetMoveX()
        {
            Pair p = new Pair(this.x + 1, this.y);
            return p;
        }
        public Pair GetMoveY()
        {
            Pair p = new Pair(this.x, this.y + 1);
            return p;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[][] g = new int[6][];
            //2
            g[0] = new int[] { 0, 0, 1, 0 };
            g[1] = new int[] { 0, 0, 0, 0 };
            g[2] = new int[] { 1, 1, 1, 0 };
            g[3] = new int[] { 0, 0, 0, 0 };
            g[4] = new int[] { 0, 0, 0, 0 };
            g[5] = new int[] { 0, 0, 0, 0 };
            Console.WriteLine(program.UniquePathsWithObstacles(g));
            Console.WriteLine("Hello World!");
        }
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int x = obstacleGrid.Length;
            int y = obstacleGrid[0].Length;
            if (obstacleGrid[0][0] == 1)
                return 0;
            int[][] bfs = new int[x][];
            for (int i = 0; i < x; i++)
            {
                bfs[i] = new int[y];
            }
            bfs[0][0] = 1;
            for (int i = 1; i < x; i++)
            {
                if (obstacleGrid[i][0] != 1)
                    bfs[i][0] += (bfs[i - 1][0] != 0 ? bfs[i - 1][0] : 0);
            }
            for (int i = 1; i < y; i++)
            {
                if (obstacleGrid[0][i] != 1)
                    bfs[0][i] += (bfs[0][i - 1] != 0 ? bfs[0][i - 1] : 0);
            }
            for (int i = 1; i < x; i++)
            {
                for (int j = 1; j < y; j++)
                {
                    if (obstacleGrid[i][j] != 1)
                        bfs[i][j] = bfs[i - 1][j] + bfs[i][j - 1];
                }
            }
            return bfs[x - 1][y - 1];
        }
        public int UniquePathsWithObstaclesTLE(int[][] obstacleGrid)
        {
            int x = obstacleGrid.Length;
            int y = obstacleGrid[0].Length;
            if (obstacleGrid[0][0] == 1)
                return 0;
            int[][] bfs = new int[x][];
            for (int i = 0; i < x; i++)
            {
                bfs[i] = new int[y];
            }
            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(new Pair(0, 0));
            int res = 0;
            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    Pair p = queue.Dequeue();
                    if (p.x + 1 < x && obstacleGrid[p.x + 1][p.y] != 1)
                        queue.Enqueue(p.GetMoveX());
                    if (p.y + 1 < y && obstacleGrid[p.x][p.y + 1] != 1)
                        queue.Enqueue(p.GetMoveY());
                    if (p.x == x - 1 && p.y == y - 1)
                        res++;
                }
            }
            return res;
        }
    }
}
