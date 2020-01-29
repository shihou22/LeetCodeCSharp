using System;
using System.Collections.Generic;

namespace Find_All_Anagrams_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // 0,6
            var res1 = program.FindAnagrams("cbaebabacd", "abc");
            //0,1,2
            var res2 = program.FindAnagrams("abab", "ab");
            var res3 = program.FindAnagrams("eklpyqrbgjdwtcaxzsnifvhmoueklpyqrbgjdwtcaxzsnifvhmoueklpyqrbgjdwtcaxzsnifv", "yqrbgjdwtcaxzsnifvhmou");
            Console.WriteLine("Hello World!");
        }

        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> res = new List<int>(); ;
            if (s.Length < p.Length)
                return res;
            int len = p.Length;
            int[] b = new int[26];
            foreach (var item in p)
            {
                b[item - 'a']++;
            }
            int[] t = new int[26];
            for (int i = 0; i < len - 1; i++)
            {
                t[s[i] - 'a']++;
            }
            for (int i = 0; i <= s.Length - len; i++)
            {
                t[s[i + len - 1] - 'a']++;
                if (iChek(b, t))
                    res.Add(i);
                t[s[i] - 'a']--;
            }
            return res;
        }
        private bool iChek(int[] b, int[] t)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != t[i])
                    return false;
            }
            return true;
        }
        public IList<int> FindAnagramsTLE2(string s, string p)
        {
            if (s.Length < p.Length)
                return new List<int>();
            IDictionary<char, int> mainMemo = new Dictionary<char, int>();
            foreach (var item in p)
            {
                mainMemo.TryAdd(item, 0);
                mainMemo[item]++;
            }
            IList<int> res = new List<int>();
            char pre = ' ';
            for (int i = 0; i <= s.Length - p.Length; i++)
            {

                bool isChk = chk(s, p, i, mainMemo);
                if (isChk)
                {
                    res.Add(i);
                    pre = s[i];
                }
                int index = i + p.Length;
                while (isChk && index < s.Length && pre != s[index])
                {
                    index++;
                }
                i = index - p.Length;
            }

            return res;
        }
        private bool chk(string s, string p, int i, IDictionary<char, int> mainMemo)
        {
            IDictionary<char, int> keyMemo = new Dictionary<char, int>(mainMemo);
            for (int j = 0; j < p.Length; j++)
            {
                if (!mainMemo.ContainsKey(s[i + j]))
                {
                    return false;
                }
                keyMemo[s[i + j]]--;
                if (keyMemo[s[i + j]] < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public IList<int> FindAnagramsTLE(string s, string p)
        {
            if (s.Length < p.Length)
                return new List<int>();
            IDictionary<char, int> mainMemo = new Dictionary<char, int>();
            foreach (var item in p)
            {
                mainMemo.TryAdd(item, 0);
                mainMemo[item]++;
            }
            IList<int> res = new List<int>();
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                IDictionary<char, int> keyMemo = new Dictionary<char, int>(mainMemo);
                bool isExist = true;
                for (int j = 0; j < p.Length; j++)
                {
                    if (!mainMemo.ContainsKey(s[i + j]))
                    {
                        i += j;
                        isExist = false;
                        break;
                    }
                    keyMemo[s[i + j]]--;
                    if (keyMemo[s[i + j]] < 0)
                    {
                        isExist = false;
                        break;
                    }
                }
                if (isExist)
                {
                    res.Add(i);
                }
            }
            return res;
        }
    }
}
