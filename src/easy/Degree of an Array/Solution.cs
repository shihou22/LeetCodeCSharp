using System;
using System.Collections.Generic;
using System.Linq;

namespace Degree_of_an_Array
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.FindShortestSubArray(new int[] { 1, 2, 2, 3, 1 }));//2
            Console.WriteLine(solution.FindShortestSubArray(new int[] { 1, 1, 2, 2, 2, 1 }));//3
            Console.WriteLine("Hello World!");
        }
        public int FindShortestSubArray(int[] nums)
        {
            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
            //次数カウント
            for (int i = 0; i < nums.Length; i++)
            {
                if (dictionary.ContainsKey(nums[i]))
                    dictionary[nums[i]].Add(i);
                else
                {
                    var wk = new List<int>() { i };
                    dictionary.Add(nums[i], wk);
                }
            }
            var max = dictionary.Max(elm => elm.Value.Count());
            return dictionary.Where(elm => elm.Value.Count == max).Min(elm => elm.Value[elm.Value.Count - 1] - elm.Value[0] + 1);
        }
        /*
        DictionaryとKeyValuePairでのソート
         */
        public int FindShortestSubArrayOld(int[] nums)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            //次数カウント
            foreach (var item in nums)
            {
                if (dictionary.ContainsKey(item))
                    dictionary[item]++;
                else
                    dictionary.Add(item, 1);
            }
            //Dictionaryをpairに変換
            List<KeyValuePair<int, int>> pairs = new List<KeyValuePair<int, int>>(dictionary);
            //List.sortを利用
            pairs.Sort(
              delegate (KeyValuePair<int, int> kvp1, KeyValuePair<int, int> kvp2)
              {
                  return -kvp1.Value.CompareTo(kvp2.Value);
              });

            //次数の高い数値の抜出
            IList<int> target = new List<int>();
            target.Add(pairs[0].Key);
            var baseElm = pairs[0];
            for (int i = 1; i < pairs.Count; i++)
            {
                var elm = pairs[i];
                if (baseElm.Value > elm.Value)
                    break;
                target.Add(elm.Key);
            }
            //BinarySearchで比較していく
            int minLength = int.MaxValue;
            foreach (var item in target)
            {
                var start = Array.IndexOf(nums, item);
                var last = Array.LastIndexOf(nums, item);
                minLength = Math.Min(minLength, last - (start - 1));
            }
            return minLength;
        }
    }
}
