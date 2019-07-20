using System;
using System.Collections.Generic;

namespace Combination_Sum
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
            Console.WriteLine("Hello World!");
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(candidates);
            dfs1(target, 0, candidates, res, new List<int>(), 0);
            return res;
        }
        private void dfs1(int target, int sum, int[] candidates, IList<IList<int>> res, IList<int> wkRes, int currentI)
        {
            if (sum > target || currentI >= candidates.Length)
                return;

            if (target == sum)
            {
                res.Add(new List<int>(wkRes));
                return;
            }
            if (candidates[currentI] == 0)
                return;

            /*
            DFS版
             */
            //自分を足す
            if (sum + candidates[currentI] <= target)
            {
                wkRes.Add(candidates[currentI]);
                dfs1(target, sum + candidates[currentI], candidates, res, wkRes, currentI);
                wkRes.RemoveAt(wkRes.Count - 1);
            }
            //移動する
            dfs1(target, sum, candidates, res, wkRes, currentI + 1);
        }

        private void dfs2(int target, int sum, int[] candidates, IList<IList<int>> res, IList<int> wkRes, int currentI)
        {
            if (sum > target || currentI >= candidates.Length)
                return;

            if (target == sum)
            {
                res.Add(new List<int>(wkRes));
                return;
            }
            if (candidates[currentI] == 0)
                return;

            /*
            loop版
             */
            for (int i = currentI; i < candidates.Length && sum + candidates[i] <= target; i++)
            {
                wkRes.Add(candidates[i]);
                dfs2(target, sum + candidates[i], candidates, res, wkRes, i);
                wkRes.RemoveAt(wkRes.Count - 1);
            }
        }
    }
}
