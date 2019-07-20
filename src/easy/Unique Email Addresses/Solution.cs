using System;
using System.Collections.Generic;

namespace Unique_Email_Addresses
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int res = 0;
            res = solution.NumUniqueEmails(new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" });
            Console.WriteLine(res);
            res = solution.NumUniqueEmails(new string[] { "testemail@leetcode.com", "testemail1@leetcode.com", "testemail+david@lee.tcode.com" });
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }

        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> res = new HashSet<string>();
            foreach (var item in emails)
            {
                string[] wk = item.Split("@");
                int ind = wk[0].IndexOf("+");
                if (ind > 0)
                {
                    wk[0] = wk[0].Substring(0, ind);
                }
                res.Add(wk[0].Replace(".","") + "@" + wk[1]);
            }
            return res.Count;
        }
        public int NumUniqueEmailsOld(string[] emails)
        {
            IDictionary<string, HashSet<string>> map = new Dictionary<string, HashSet<string>>();
            foreach (var item in emails)
            {
                string[] wk = item.Split("@");
                string tmp = wk[0].Replace(".", "");
                int ind = tmp.IndexOf("+");
                if (ind > 0)
                {
                    tmp = tmp.Substring(0, ind);
                }
                HashSet<string> res = null;
                map.TryGetValue(wk[1], out res);
                if (res == null)
                {
                    res = new HashSet<string>();
                }
                res.Add(tmp);
                map[wk[1]] = res;
            }
            int cnt = 0;
            foreach (HashSet<string> item in map.Values)
            {
                cnt += item.Count;
            }
            return cnt;
        }
    }
}
