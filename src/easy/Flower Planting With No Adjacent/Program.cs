using System;
using System.Linq;
using System.Collections.Generic;

namespace Flower_Planting_With_No_Adjacent
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            {
                // int[][] paths = new int[2][];
                // paths[0] = new int[] { 1, 2 };
                // paths[1] = new int[] { 3, 4 };
                // solution.GardenNoAdj(4, paths);
            }
            {
                // int[][] paths = new int[3][];
                // paths[0] = new int[] { 2, 3 };
                // paths[1] = new int[] { 1, 3 };
                // paths[2] = new int[] { 2, 1 };
                // solution.GardenNoAdj(3, paths);
            }
            {
                // int[][] paths = new int[6][];
                // paths[0] = new int[] { 4, 1 };
                // paths[1] = new int[] { 4, 2 };
                // paths[2] = new int[] { 4, 3 };
                // paths[3] = new int[] { 2, 5 };
                // paths[4] = new int[] { 1, 2 };
                // paths[5] = new int[] { 1, 5 };
                // solution.GardenNoAdj(5, paths);
            }
            {
                // int[][] paths = new int[5][];
                // paths[0] = new int[] { 4, 5 };
                // paths[1] = new int[] { 4, 3 };
                // paths[2] = new int[] { 2, 3 };
                // paths[3] = new int[] { 3, 5 };
                // paths[4] = new int[] { 2, 4 };
                // solution.GardenNoAdj(5, paths);
            }
            {
                int[][] paths = new int[3][];
                paths[0] = new int[] { 1, 2 };
                paths[1] = new int[] { 2, 3 };
                paths[2] = new int[] { 3, 1 };
                solution.GardenNoAdj(3, paths);
            }
            Console.WriteLine("Hello World!");
        }
        public int[] GardenNoAdj(int N, int[][] paths)
        {
            int[] res = new int[N];
            Array.Fill(res, 1);
            IList<List<int>> tree = new List<List<int>>();
            for (int i = 0; i < N; i++)
            {
                tree.Add(new List<int>());
            }
            foreach (var item in paths)
            {
                tree[item[0]].Add(item[1]);
                tree[item[1]].Add(item[0]);
            }
            for (int i = 0; i < tree.Count; i++)
            {
                int node = i;
                // if (res[node] == 0)
                //     res[node] = 1;
                List<int> wk = tree[node];
                wk.Sort();
                foreach (var item in wk)
                {
                    // if (res[item] != 0)
                    //     continue;
                    res[item] = GetMax(res[item], res[node]);
                }

            }
            return res;
        }

    }
}
