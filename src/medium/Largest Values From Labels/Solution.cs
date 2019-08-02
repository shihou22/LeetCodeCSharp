using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_Values_From_Labels
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // var wk1 = solution.LargestValsFromLabels(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 1, 2, 2, 3 }, 3, 1);
            // Console.WriteLine(wk1);//9
            // var wk2 = solution.LargestValsFromLabels(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 3, 3, 3, 2 }, 3, 2);
            // Console.WriteLine(wk2);//12
            // var wk3 = solution.LargestValsFromLabels(new int[] { 9, 8, 8, 7, 6 }, new int[] { 0, 0, 0, 1, 1 }, 3, 1);
            // Console.WriteLine(wk3);//16
            // var wk4 = solution.LargestValsFromLabels(new int[] { 9, 8, 8, 7, 6 }, new int[] { 0, 0, 0, 1, 1 }, 3, 2);
            // Console.WriteLine(wk4);//24
            // var wk5 = solution.LargestValsFromLabels(new int[] { 2, 6, 1, 2, 6 }, new int[] { 2, 2, 2, 1, 1 }, 1, 1);
            // Console.WriteLine(wk5);//6
            // var wk6 = solution.LargestValsFromLabels(new int[] { 2, 1, 9, 3, 5 }, new int[] { 1, 2, 2, 2, 2 }, 1, 3);
            // Console.WriteLine(wk6);//9
            var wk7 = solution.LargestValsFromLabels(new int[] { 1, 5, 5, 8, 3 }, new int[] { 0, 2, 2, 0, 1 }, 2, 2);
            Console.WriteLine(wk7);//13
            Console.WriteLine("Hello World!");
        }
        public int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit)
        {
            List<KeyValuePair<int, int>> pairs = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < values.Length; i++)
            {
                var key = values[i];
                var val = labels[i];
                KeyValuePair<int, int> pair = new KeyValuePair<int, int>(key, val);
                pairs.Add(pair);
            }
            pairs.Sort((val1, val2) => { return -val1.Key.CompareTo(val2.Key); });
            Dictionary<int, int> res = new Dictionary<int, int>();
            int result = 0;
            foreach (var item in pairs)
            {
                if (num_wanted == 0)
                    break;
                if (res.ContainsKey(item.Value))
                {
                    if (res[item.Value] < use_limit)
                    {
                        res[item.Value]++;
                        result += item.Key;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    res.Add(item.Value, 1);
                    result += item.Key;
                }
                num_wanted--;
            }
            return result;

        }
    }
}
