using System;

namespace Repeated_String_Match
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // Console.WriteLine(solution.RepeatedStringMatch("abcdc", "cdcabcdcab"));//3
            // Console.WriteLine(solution.RepeatedStringMatch("aa", "a"));//1
            Console.WriteLine(solution.RepeatedStringMatch("aabaa", "aaab"));//2
            Console.WriteLine(solution.RepeatedStringMatch("aa", "a"));//1
            Console.WriteLine("Hello World!");
        }

        public int RepeatedStringMatch(string A, string B)
        {
            string cur = A;
            int index = 1;
            while (cur.Length < B.Length)
            {
                cur += A;
                index++;
            }
            if (cur.Contains(B))
                return index;
            cur += A;
            index++;
            if (cur.Contains(B))
                return index;
            else
                return -1;
        }
    }
}
