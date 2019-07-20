using System;
using System.Collections.Generic;

namespace Combination_Sum_II
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // solution.CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            solution.CombinationSum2(new int[] { 2, 5, 2, 1, 2 }, 5);
            Console.WriteLine("Hello World!");
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> res = new List<IList<int>>();
            dfs(candidates, target, res, new List<int>(), new HashSet<string>(), 0, 0);
            return res;
        }

        private void dfs(int[] candidates, int target, IList<IList<int>> res, IList<int> memo, HashSet<string> dupMemo, int currentI, int sum)
        {
            //一番最初に含めるべきか含めないべきかを判定
            if (sum == target)
            {
                var key = string.Join("", memo);
                if (dupMemo.Contains(key))
                    return;

                res.Add(new List<int>(memo));
                dupMemo.Add(key);
                return;
            }

            //含めないなら抜けるべきかを判定
            if (sum > target || currentI >= candidates.Length)
                return;


            //足さずに進める
            dfs(candidates, target, res, memo, dupMemo, currentI + 1, sum);

            //足して進める
            if (sum + candidates[currentI] <= target)
            {
                memo.Add(candidates[currentI]);
                dfs(candidates, target, res, memo, dupMemo, currentI + 1, sum + candidates[currentI]);
                memo.RemoveAt(memo.Count - 1);
            }

        }
    }
}
