using System;

namespace Valid_Palindrome_II
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.ValidPalindrome("aba"));//true
            Console.WriteLine(solution.ValidPalindrome("abca"));//true
            Console.WriteLine(solution.ValidPalindrome("abc"));//false
            Console.WriteLine(solution.ValidPalindrome("aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga"));//true
            //aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxj
            //jxqncffvmhvgsymdjgpfdhooxfuupuc-u-lmgmqfvnbgtapekouga
            //aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga
            Console.WriteLine("Hello World!");
        }
        public bool ValidPalindrome(string s)
        {
            int sI = 0;
            int eI = s.Length - 1;
            return ConfirmRec(s, sI, eI, 1);
        }
        private bool ConfirmRec(string s, int sI, int eI, int errCnt)
        {
            if (errCnt < 0)
                return false;
            if (sI >= eI)
                return true;

            if (s[sI] == s[eI])
            {
                return ConfirmRec(s, sI + 1, eI - 1, errCnt);
            }
            else if (s[sI] != s[eI])
            {
                return ConfirmRec(s, sI + 1, eI, errCnt - 1) || ConfirmRec(s, sI, eI - 1, errCnt - 1);
            }
            return false;
        }
        public bool ValidPalindromeIteFool(string s)
        {
            int sI = 0;
            int eI = s.Length - 1;
            int diffCnt = 0;
            int errCnt = 0;

            while (sI < eI)
            {
                if (s[sI] != s[eI])
                {
                    if (diffCnt == 0)
                    {
                        diffCnt++;
                        sI++;
                        continue;
                    }
                    else
                    {
                        errCnt++;
                        break;
                    }
                }
                sI++;
                eI--;
            }
            diffCnt = 0;
            sI = 0;
            eI = s.Length - 1;
            while (sI < eI)
            {
                if (s[sI] != s[eI])
                {
                    if (diffCnt == 0)
                    {
                        diffCnt++;
                        eI--;
                        continue;
                    }
                    else
                    {
                        errCnt++;
                        break;
                    }
                }
                sI++;
                eI--;
            }

            return errCnt < 2;
        }
    }
}
