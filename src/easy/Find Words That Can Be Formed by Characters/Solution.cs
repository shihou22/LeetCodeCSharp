using System;
using System.Collections.Generic;

namespace Find_Words_That_Can_Be_Formed_by_Characters
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.CountCharacters(new string[] { "cat", "bt", "hat", "tree" }, "atach")); ;
            Console.WriteLine("Hello World!");
        }
        public int CountCharacters(string[] words, string chars)
        {
            int[] charsNum = new int[26];
            foreach (var item in chars)
            {
                charsNum[item - 'a']++;
            }
            int res = 0;
            foreach (var item in words)
            {
                int[] wkNums = new int[26];
                bool resB = true;
                foreach (var c in item)
                {
                    int index = c - 'a';
                    wkNums[index]++;
                    if (wkNums[index] > charsNum[index])
                    {
                        resB = false;
                        break;
                    }
                }
                if (resB)
                    res += item.Length;
            }
            return res;
        }

    }
}
