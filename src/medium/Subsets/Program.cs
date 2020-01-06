using System;
using System.Collections.Generic;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            IList<IList<int>> res = new List<IList<int>>();
            res = program.SubsetsRecursive(new int[] { 1, 2, 3 });
            res = program.SubsetsBit(new int[] { 1, 2, 3 });
            res = program.SubsetsQueue(new int[] { 1, 2, 3 });
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> SubsetsQueue(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            Queue<IList<int>> queue = new Queue<IList<int>>();
            queue.Enqueue(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                int cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    IList<int> tmp = queue.Dequeue();
                    queue.Enqueue(new List<int>(tmp));
                    IList<int> wk = new List<int>(tmp);
                    wk.Add(nums[i]);
                    queue.Enqueue(wk);
                }

            }
            foreach (var item in queue)
            {
                res.Add(item);
            }
            return res;
        }
        public IList<IList<int>> SubsetsBit(int[] nums)
        {
            int n = nums.Length;
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < (Math.Pow(2, n)); i++)
            {
                IList<int> tmp = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        tmp.Add(nums[j]);
                    }
                }
                res.Add(tmp);
            }
            return res;
        }
        public IList<IList<int>> SubsetsRecursive(int[] nums)
        {
            recursiveIterable(nums, 0, new bool[nums.Length], new List<int>());
            // recursiveDFS(nums, 0, new List<int>());
            return res;
        }
        IList<IList<int>> res = new List<IList<int>>();
        private void recursiveDFS(int[] nums, int curr, IList<int> wk)
        {
            if (curr >= nums.Length)
            {
                res.Add(new List<int>(wk));
                return;
            }

            recursiveDFS(nums, curr + 1, wk);
            wk.Add(nums[curr]);
            recursiveDFS(nums, curr + 1, wk);
        }
        private void recursiveIterable(int[] nums, int curr, bool[] visited, IList<int> wk)
        {
            if (curr >= nums.Length)
            {
                res.Add(new List<int>(wk));
                return;
            }

            for (int i = curr; i < nums.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    recursiveIterable(nums, curr + 1, visited, wk);
                    wk.Add(nums[i]);
                    recursiveIterable(nums, curr + 1, visited, wk);
                    wk.RemoveAt(wk.Count - 1);
                    visited[i] = false;
                }
            }
        }
    }
}
