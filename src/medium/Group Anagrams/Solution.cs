using System;
using System.Collections.Generic;

namespace Group_Anagrams
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            IList<IList<string>> res;
            res = solution.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            // res = solution.GroupAnagrams(new string[] { "tao", "pit", "cam", "aid", "pro", "dog" });
            Console.WriteLine("Hello World!");
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> memo = new Dictionary<string, IList<string>>();
            foreach (var item in strs)
            {
                var tmp = item.ToCharArray();
                Array.Sort(tmp);

                var key = new String(tmp);
                if (memo.ContainsKey(key))
                    memo[key].Add(item);
                else
                    memo.Add(key, new List<string>() { item });
            }
            return new List<IList<string>>(memo.Values);
        }
    }
}
