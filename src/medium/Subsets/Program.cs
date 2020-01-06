using System;
using System.Collections.Generic;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            var res = program.SubsetsRecursive(new int[] { 1, 2, 3 });
            Console.WriteLine("Hello World!");
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
