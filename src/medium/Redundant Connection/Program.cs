using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Redundant_Connection
{
    class GridCreator
    {
        /*
        入力サンプル
        [[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]
        ↓
        [3,0,8,4]
        [2,4,5,7]
        [9,2,6,3]
        [0,3,1,0]
        */
        public static int[][] CreateGrid(string a)
        {
            string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
            int[][] grid = new int[wk.Length][];
            for (int i = 0; i < wk.Length; i++)
            {
                string[] tmp = wk[i].Split(",");
                grid[i] = tmp.Select(x => int.Parse(x)).ToArray();
            }
            return grid;
        }

        public static char[][] CreateCharGrid(string a)
        {
            string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
            char[][] grid = new char[wk.Length][];
            for (int i = 0; i < wk.Length; i++)
            {
                string[] tmp = wk[i].Split(",");
                grid[i] = tmp.Select(x => x[0]).ToArray();
            }
            return grid;
        }

        public static string GetResultStr(int[][] grid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            foreach (var item in grid)
            {
                builder.Append("[");
                for (int i = 0; i < item.Length; i++)
                {
                    if (i == item.Length - 1)
                        builder.Append(item[i]);
                    else
                        builder.Append(item[i]).Append(",");
                }
                builder.Append("]");
            }
            builder.Append("]");
            return builder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // [2,3]
            var arg1 = GridCreator.CreateGrid("[[1,2], [1,3], [2,3]]");
            var res1 = program.FindRedundantConnection(arg1);
            // [1,4]
            var arg2 = GridCreator.CreateGrid("[[1,2], [2,3], [3,4], [1,4], [1,5]]");
            var res2 = program.FindRedundantConnection(arg2);
            Console.WriteLine("Hello World!");
        }
        ISet<int> visited = new HashSet<int>();
        int MAX_EDGE_VAL = 1000;

        public int[] FindRedundantConnection(int[][] edges)
        {
            List<int>[] graph = new List<int>[MAX_EDGE_VAL + 1];
            for (int i = 0; i <= MAX_EDGE_VAL; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (int[] edge in edges)
            {
                visited.Clear();
                if (!graph[edge[0]].Any() && !graph[edge[1]].Any() && DFS(graph, edge[0], edge[1]))
                {
                    return edge;
                }
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            return new int[] { };
        }
        public bool DFS(List<int>[] graph, int source, int target)
        {
            if (!visited.Contains(source))
            {
                visited.Add(source);
                if (source == target)
                    return true;
                foreach (int nei in graph[source])
                {
                    if (DFS(graph, nei, target))
                        return true;
                }
            }
            return false;
        }
        public int[] FindRedundantConnectionUnionFind(int[][] edges)
        {
            ISet<int> nodes = new HashSet<int>();
            foreach (var item in edges)
            {
                nodes.Add(item[0]);
                nodes.Add(item[1]);
            }
            UnionFind unionFind = new UnionFind(nodes.Count);
            foreach (var item in edges)
            {
                if (!unionFind.IsSame(item[0], item[1]))
                    unionFind.Unite(item[0], item[1]);
                else
                    return item;
            }
            return new int[] { };
        }
    }
    class UnionFind
    {
        int[] par;
        public UnionFind(int n)
        {
            par = new int[n + 1];
            Array.Fill(par, -1);
        }
        public int GetParent(int n)
        {
            if (par[n] < 0)
                return n;
            else
                return par[n] = GetParent(par[n]);
        }
        public bool IsSame(int x, int y)
        {
            return GetParent(x) == GetParent(y);
        }
        public void Unite(int x, int y)
        {
            if (!IsSame(x, y))
            {
                int wkX = GetParent(x);
                int wkY = GetParent(y);
                if (par[wkX] < par[wkY])
                {
                    par[wkX] += par[wkY];
                    par[wkY] = wkX;
                }
                else
                {
                    par[wkY] += par[wkX];
                    par[wkX] = wkY;
                }
            }
        }
    }
}
