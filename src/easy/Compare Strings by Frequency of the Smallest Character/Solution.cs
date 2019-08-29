using System;
using System.Collections.Generic;
using System.Linq;

namespace Compare_Strings_by_Frequency_of_the_Smallest_Character
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] res = null;
            res = solution.NumSmallerByFrequency(new string[] { "cbd" }, new string[] { "zaaaz" });//[1]
            string[] var1 = new string[] { "bba", "abaaaaaa", "aaaaaa", "bbabbabaab", "aba", "aa", "baab", "bbbbbb", "aab", "bbabbaabb" };
            string[] var2 = new string[] { "aaabbb", "aab", "babbab", "babbbb", "b", "bbbbbbbbab", "a", "bbbbbbbbbb", "baaabbaab", "aa" };
            res = solution.NumSmallerByFrequency(var1, var2);//[6,1,1,2,3,3,3,1,3,2]
            Console.WriteLine("Hello World!");
        }
        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            List<int> que = new List<int>();
            foreach (var item in queries)
            {
                que.Add(CntWords(item));
            }
            List<int> wor = new List<int>();
            foreach (var item in words)
            {
                wor.Add(CntWords(item));
            }
            wor.Sort();
            int[] res = new int[queries.Count()];
            for (int i = 0; i < que.Count(); i++)
            {
                int wk =GetIndex(wor, que[i]);
                res[i] = wk <0 ? 0: wk;
            }
            return res;
        }
        private int GetIndex(List<int> wor, int size)
        {
            for (int i = 0; i < wor.Count; i++)
            {
                if (wor[i] > size)
                {
                    return wor.Count() - i;
                }
            }
            return -1;
        }
        private int CntWords(string words)
        {
            int[] wk = new int[26];
            foreach (var item in words)
            {
                wk[item - 'a']++;
            }
            // return wk.Max();
            for (int i = 0; i < 26; i++)
            {
                if (wk[i] != 0)
                    return wk[i];
            }
            return 0;
        }
    }
}
