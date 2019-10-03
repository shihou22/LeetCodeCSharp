using System;
using System.Collections.Generic;

namespace Count_Binary_Substrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountBinarySubstrings(string s)
        {
            IList<int> wk = new List<int>();
            char tmp = s[0];
            int cnt = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (tmp == s[i])
                {
                    cnt++;
                }
                else
                {
                    wk.Add(cnt);
                    cnt = 1;
                    tmp = s[i];
                }
            }
            wk.Add(cnt);
            int res = 0;
            for (int i = 1; i < wk.Count; i++)
            {
                res += Math.Min(wk[i - 1], wk[i]);
            }
            return res;

        }
    }
}
