using System;

namespace Longest_Uncommon_Subsequence_II
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.FindLUSlength(new string[] { "aba", "cdc", "eae" }));//3
            Console.WriteLine("Hello World!");
        }
        public int FindLUSlength(string[] strs)
        {
            if (strs.Length == 1)
                return strs.Length;

            string baseStr = strs[0];
            foreach (var item in strs)
            {
                string wk1 = "";
                string wk2 = "";
                if (baseStr.Length > item.Length)
                {
                    wk1 = item;
                    wk2 = baseStr;
                }
                else
                {
                    wk1 = baseStr;
                    wk2 = item;
                }
                baseStr = GetCheck(wk1, wk2);
                if (baseStr.Length <= 0)
                    return 0;
            }
            return baseStr.Length;
        }
        private string GetCheck(string wk1, string wk2)
        {
            if (wk1.Length <= 0)
                return wk1;

            int index = wk2.IndexOf(wk1);
            if (index < 0)
            {
                if (wk1.Length >= 2)
                {
                    string val1 = GetCheck(wk1.Substring(1, wk1.Length - 1), wk2);
                    string val2 = GetCheck(wk1.Substring(0, wk1.Length - 2), wk2);
                    return val1.Length > val2.Length ? val1 : val2;
                }
                else
                {
                    return "";
                }

            }
            else
            {
                return wk1;
            }

        }
    }
}