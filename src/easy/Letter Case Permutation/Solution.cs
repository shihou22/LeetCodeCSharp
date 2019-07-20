using System;
using System.Text;
using System.Collections.Generic;

namespace Letter_Case_Permutation
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            IList<string> res = null;
            res = solution.LetterCasePermutation("a1b2");
            Console.WriteLine("Hello World!");
        }

        public IList<string> LetterCasePermutation(string S)
        {
            var res = new List<string>();
            dfs(S, res, 0, "");
            return res;
        }

        private void dfs(string S, IList<string> res, int currentI, string elm)
        {
            if (currentI >= S.Length)
            {
                res.Add(elm);
                return;
            }

            if (0 <= S[currentI] - '0' && S[currentI] - '0' <= 9)
                dfs(S, res, currentI + 1, elm + S[currentI]);
            else
            {
                dfs(S, res, currentI + 1, elm + Char.ToLower(S[currentI]));
                dfs(S, res, currentI + 1, elm + Char.ToUpper(S[currentI]));
            }

        }

        /*
         bitマスク2
         */
        public IList<string> LetterCasePermutationBitMask2(string S)
        {
            var wkString = S.ToLower();
            var res = new List<string>();
            for (int i = 0; i < Math.Pow(2, wkString.Length); i++)
            {
                StringBuilder builder = new StringBuilder();
                bool isNum = false;
                for (int j = 0; j < wkString.Length; j++)
                {
                    int bitPos = (int)Math.Pow(2,j);
                    if ((i & bitPos) > 0 && wkString[j] - '0' >= 0 && wkString[j] - '0' <= 9)
                    {
                        isNum = true;
                        break;
                    }

                    if ((i & bitPos) > 0)
                        builder.Append(Char.ToUpper(wkString[j]));
                    else
                        builder.Append(wkString[j]);
                }
                if (!isNum)
                    res.Add(builder.ToString());
            }
            return res;
        }

        /*
        bitマスク
         */
        public IList<string> LetterCasePermutationBitMask(string S)
        {
            var wkString = S.ToLower();
            var res = new List<string>();
            for (int i = 0; i < Math.Pow(2, wkString.Length); i++)
            {
                StringBuilder builder = new StringBuilder();
                int bitPos = 1;
                bool isNum = false;
                for (int j = 0; j < wkString.Length; j++)
                {
                    if ((i & bitPos) > 0 && wkString[j] - '0' >= 0 && wkString[j] - '0' <= 9)
                    {
                        isNum = true;
                        break;
                    }

                    if ((i & bitPos) > 0)
                        builder.Append(Char.ToUpper(wkString[j]));
                    else
                        builder.Append(wkString[j]);

                    bitPos <<= 1;
                }
                if (!isNum)
                    res.Add(builder.ToString());
            }
            return res;
        }
    }
}
