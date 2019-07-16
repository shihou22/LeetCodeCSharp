using System;

namespace Is_Subsequence
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            bool res = false;
            res = solution.IsSubsequence("abc", "ahbgdc");//true
            Console.WriteLine(res);
            res = solution.IsSubsequence("abc", "");//false
            Console.WriteLine(res);
            res = solution.IsSubsequence("b", "c");//false
            Console.WriteLine(res);
            res = solution.IsSubsequence("axc", "ahbgdc");//false
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }

        public bool IsSubsequence(string s, string t)
        {
            int j = 0;
            foreach (var item in t)
            {
                if (j < s.Length && s[j] == item)
                    j++;
            }
            return s.Length == j;
        }
        public bool IsSubsequence2(string s, string t)
        {
            var lenS = s.Length;
            var lenT = t.Length;
            // var dp = new int[lenS + 1, lenT + 1];
            var dp = new bool[lenS + 1, lenT + 1];

            for (int j = 0; j <= lenT; j++)
            {
                dp[0, j] = true;
            }

            // dp[0, 0] = 0;
            dp[0, 0] = true;

            for (int i = 1; i <= lenS; i++)
            {
                for (int j = 1; j <= lenT; j++)
                {
                    if (s[i - 1].Equals(t[j - 1]))
                        // dp[i, j] = dp[i - 1, j - 1]+1;
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        // dp[i, j] = Math.Max(dp[i - 1, j] , dp[i, j - 1]);
                        dp[i, j] = dp[i, j - 1];
                }
            }
            // return dp[lenS,lenT] == lenS;
            return dp[lenS, lenT];

        }

        public bool IsSubsequenceOld(string s, string t)
        {
            if (s == null || t == null || s.Length > t.Length)
                return false;

            int currentI = -1;
            foreach (var item in s)
            {

                var searchResult = t.IndexOf(item, currentI + 1);

                //searchResult < 0は初回対策
                if (currentI > searchResult || searchResult < 0)
                    return false;

                currentI = searchResult;
            }
            return true;

        }
    }
}
