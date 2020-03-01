using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Minimum_Height_Trees
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
        public static int[][] CreateGridJag(string a)
        {
            string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
            int[][] grid = new int[wk.Length][];
            for (int i = 0; i < wk.Length; i++)
            {
                string[] tmp = wk[i].Split(",");
                if (tmp.Length > 0 && tmp[0].Length > 0)
                    grid[i] = tmp.Select(x => int.Parse(x)).ToArray();
            }
            return grid;
        }
        public static int[,] CreateGrid(string a)
        {
            string[] wk = a.Replace(" ", "").Replace("[[", "").Replace("]]", "").Split("],[");
            int[][] tmp = wk.Select(c => c.Split(",").Select(x => int.Parse(x)).ToArray()).ToArray();
            int[,] grid = new int[tmp.Length, tmp[0].Length];

            for (int i = 0; i < wk.Length; i++)
            {
                for (int j = 0; j < tmp[i].Length; j++)
                    grid[i, j] = tmp[i][j];
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
            // var edges1 = GridCreator.CreateGridJag("[[1,0],[1,2],[1,3]]");
            // var res1 = program.FindMinHeightTrees(4, edges1);//[1]
            // var edges2 = GridCreator.CreateGridJag("[[]]");
            // var res2 = program.FindMinHeightTrees(1, edges2);//[]
            // var edges3 = GridCreator.CreateGridJag("[[0,1],[1,2],[1,3],[2,4],[3,5],[4,6]]");
            // var res3 = program.FindMinHeightTrees(7, edges3);//[1,2]
            var edges4 = GridCreator.CreateGridJag("[[1,0],[1,2],[1,3]]");
            var res4 = program.FindMinHeightTrees(4, edges4);//[1,2]
            Console.WriteLine("Hello World!");
        }
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (n == 1)
                return new List<int> { 0 };
            if (n < 2 || edges == null || edges.Length == 0 || edges[0].Length == 0)
                return new List<int>();
            var dic = new Dictionary<int, List<int>>();
            foreach (var item in edges)
            {
                dic.TryAdd(item[0], new List<int>());
                dic[item[0]].Add(item[1]);
                dic.TryAdd(item[1], new List<int>());
                dic[item[1]].Add(item[0]);
            }

            var leaf = new Queue<int>(dic.Where(d => d.Value.Count == 1).Select(item => item.Key));
            while (dic.Count > 2)
            {
                var nl = new Queue<int>();
                while (leaf.Count > 0)
                {
                    int node = leaf.Dequeue();
                    int temp = dic[node][0];
                    dic.Remove(node);
                    dic[temp].Remove(node);
                    if (dic[temp].Count == 1)
                        nl.Enqueue(temp);
                }
                leaf = nl;
            }
            return leaf.ToList();
        }
        /*
        Leafをtrimしていく
        */
        public IList<int> FindMinHeightTreesAccepted(int n, int[][] edges)
        {
            if (edges == null || edges.Length == 0 || edges[0].Length == 0)
                return new List<int>() { 0 };
            Dictionary<int, Node> graph = new Dictionary<int, Node>();
            foreach (var item in edges)
            {
                graph.TryAdd(item[0], new Node(item[0]));
                graph[item[0]].AddEdges(item[1]);
                graph.TryAdd(item[1], new Node(item[1]));
                graph[item[1]].AddEdges(item[0]);
            }
            while (graph.Count > 0)
            {
                var wk = graph.Where(x => x.Value.Count() == 1).Select(x => x.Key).ToList();
                //全部1=1でつながっている
                if (wk.Count == graph.Count)
                    return wk;
                //何もselec出来なかった=1つの根がgrapの中にいる
                if (wk.Count == 0)
                    return graph.Keys.ToList();
                foreach (var item in wk)
                {
                    ISet<int> tmp = graph[item].GetEdges();
                    foreach (var inner in tmp)
                    {
                        graph[inner].RemoveEdges(item);
                    }
                    graph.Remove(item);
                }
            }
            return null;
        }
        public IList<int> FindMinHeightTreesSlow(int n, int[][] edges)
        {
            if (edges == null || edges.Length == 0 || edges[0].Length == 0)
                return new List<int>() { 0 };
            Dictionary<int, Node> graph = new Dictionary<int, Node>();
            foreach (var item in edges)
            {
                graph.TryAdd(item[0], new Node(item[0]));
                graph[item[0]].AddEdges(item[1]);
                graph.TryAdd(item[1], new Node(item[1]));
                graph[item[1]].AddEdges(item[0]);
            }
            var wk = graph.Where(x => x.Value.Count() == 1).Select(x => x.Key).ToList();
            if (wk.Count == graph.Count)
                return wk;
            foreach (var item in wk)
            {
                ISet<int> tmp = graph[item].GetEdges();
                foreach (var inner in tmp)
                {
                    graph[inner].RemoveEdges(item);
                }
                graph.Remove(item);
            }
            foreach (var item in graph.Keys)
            {
                HashSet<int> visited = new HashSet<int>();
                visited.Add(item);
                graph[item].SetNodeNum(DFS(graph, visited, item, 1));
                visited.Remove(item);
            }
            int max = graph.Values.Select(x => x.num).Min();
            IList<int> res = graph.Values.Where(x => x.num == max).Select(x => x.n).ToList();
            return res;
        }
        private int DFS(Dictionary<int, Node> graph, ISet<int> visited, int node, int cntNodes)
        {
            if (cntNodes > graph.Count || graph.Count == visited.Count)
                return cntNodes;
            int val = cntNodes;
            foreach (var item in graph[node].GetEdges())
            {
                if (visited.Contains(item))
                    continue;
                visited.Add(item);
                val = Math.Max(val, DFS(graph, visited, item, cntNodes + 1));
                visited.Remove(item);
            }
            return val;
        }
    }
    class Node
    {
        public int n { get; }
        ISet<int> edges = new HashSet<int>();
        public int num;
        public Node(int n)
        {
            this.n = n;
            this.num = int.MaxValue;
        }
        public void SetNodeNum(int num)
        {
            this.num = num;
        }
        public void AddEdges(int edge)
        {
            this.edges.Add(edge);
        }
        public ISet<int> GetEdges()
        {
            return this.edges;
        }
        public void RemoveEdges(int edge)
        {
            this.edges.Remove(edge);
        }
        public int Count()
        {
            return this.edges.Count;
        }
    }
}
