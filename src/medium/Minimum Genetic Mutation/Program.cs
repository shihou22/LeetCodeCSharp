using System;
using System.Collections.Generic;

namespace Minimum_Genetic_Mutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinMutation(string start, string end, string[] bank)
        {
            if (bank == null || bank.Length == 0 && (start != end))
                return -1;
            bool[] isVisited = new bool[bank.Length];

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);
            int res = 0;
            while (queue.Count > 0)
            {
                int max = queue.Count;
                for (int i = 0; i < max; i++)
                {
                    string wk = queue.Dequeue();
                    if (wk == end)
                        return res;
                    for (int j = 0; j < bank.Length; j++)
                    {
                        if (isDiff(wk, bank[j]) && !isVisited[j])
                        {
                            queue.Enqueue(bank[j]);
                            isVisited[j] = true;
                        }
                    }
                }
                res++;
            }
            return -1;
        }
        private bool isDiff(string baseC, string targetC)
        {
            int cnt = 0;
            for (int i = 0; i < baseC.Length; i++)
            {
                if (baseC[i] != targetC[i])
                    cnt++;
            }
            return cnt == 1;
        }
    }
}
