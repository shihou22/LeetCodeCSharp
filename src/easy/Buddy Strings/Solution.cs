using System;
using System.Linq;
using System.Collections.Generic;

namespace Buddy_Strings
{
    public class Solution
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var res = solution.BuddyStrings("ab", "ba");
            Console.WriteLine(res);
        }

        public bool BuddyStrings(string A, string B)
        {
            if (A == null || B == null || A.Length != B.Length)
            {
                return false;
            }
            var cnt = 0;
            List<int> index = new List<int>();
            var letterCount = new int[26];
            for (int i = 0; i < A.Length; i++)
            {
                letterCount[A[i] - 'a']++;
                if (A[i] != B[i])
                {
                    index.Add(i);
                    cnt++;
                }
                if (cnt > 2)
                {
                    /*
                    cnt >= 3はirregular
                     */
                    return false;
                }
            }
            if (cnt == 2)
            {
                //cnt == 2の場合は、交換対象が==かどうかの比較でよい
                return A[index[0]] == B[index[1]] && A[index[1]] == B[index[0]];
            }
            else if (cnt == 1)
            {
                //cnt==1の場合はNG(１つ:abcd/zbcd or aabaa/aadaaとかは交換してもNG,abcdee/zbcdeeもNG)
                //例えば、aabaaのindex0-1を好感してもindex2が違うので文字列として同じにはならない
                return false;
            }
            else if (cnt == 0)
            {
                //cnt==0の場合は同じ文字が2つ以上出現しているはず(１つだとabcd/abcdとかは交換してもNG,abcdee/abcdeeは0でもeを交換できる)
                return letterCount.Max() >= 2;
            }
            return false;
        }
    }
}
