using System;
using System.Collections.Generic;

namespace Permutations
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            IList<IList<int>> res = null;
            res = solution.Permute(new int[] { 1, 2, 3 });
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> Permute(int[] nums)
        {
            var res = new List<IList<int>>();
            permutation(nums, res, new int[nums.Length], 0, new bool[nums.Length]);
            return res;
        }

        private void permutation(int[] nums, IList<IList<int>> res, int[] memo, int currentI, bool[] visited)
        {
            if (currentI == nums.Length)
            {
                res.Add(new List<int>(memo));
                return;
            }
            /*
            全列挙なので、前後の値も参照する必要がある。
            forを利用しないと+1/-1して動かさないといけないため、for文を利用する。
             */
            for (int i = 0; i < nums.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    memo[currentI] = nums[i];
                    permutation(nums, res, memo, currentI + 1, visited);
                    memo[currentI] = 0;//この戻しstatementは本来不要。気持ち悪いので記述。
                    visited[i] = false;
                }
            }

        }
    }
}
