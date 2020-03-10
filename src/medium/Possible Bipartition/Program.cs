using System;
using System.Linq;
using System.Collections.Generic;


namespace Possible_Bipartition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            if (dislikes.Length == 0 || dislikes[0].Length == 0)
                return true;
            Dictionary<int, ISet<int>> dislikeGraph = new Dictionary<int, ISet<int>>();

            foreach (var item in dislikes)
            {
                int a = item[0];
                int b = item[1];
                dislikeGraph.TryAdd(a, new HashSet<int>());
                dislikeGraph[a].Add(b);
                dislikeGraph.TryAdd(b, new HashSet<int>());
                dislikeGraph[b].Add(a);
            }
            ISet<int> p = new HashSet<int>();
            ISet<int> m = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= N; i++)
            {
                if (p.Contains(i) || m.Contains(i))
                    continue;
                queue.Enqueue(i);
                bool pm = true;
                p.Add(i);
                while (queue.Count > 0)
                {
                    pm = !pm;
                    int cnt = queue.Count;
                    ISet<int> addTmp = null;
                    ISet<int> chkTmp = null;
                    if (pm)
                    {
                        addTmp = p;
                        chkTmp = m;
                    }
                    else
                    {
                        addTmp = m;
                        chkTmp = p;
                    }
                    for (int j = 0; j < cnt; j++)
                    {
                        int idx = queue.Dequeue();
                        if (!dislikeGraph.ContainsKey(idx))
                            continue;
                        ISet<int> nexts = dislikeGraph[idx];
                        foreach (var item in nexts)
                        {
                            if (chkTmp.Contains(item))
                                return false;
                            if (addTmp.Contains(item))
                                continue;
                            addTmp.Add(item);
                            queue.Enqueue(item);
                        }

                    }
                }
            }

            return true;
        }
    }
}
