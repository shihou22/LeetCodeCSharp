using System;
using System.Linq;
using System.Collections.Generic;

namespace Verifying_an_Alien_Dictionary
{
    class Solution
    {
        static void Main(string[] args)
        {
            {
                Solution solution = new Solution();
                //true
                Console.WriteLine(solution.IsAlienSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz"));
                // //false
                Console.WriteLine(solution.IsAlienSorted(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz"));
                // //false
                Console.WriteLine(solution.IsAlienSorted(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz"));
                //true
                Console.WriteLine(solution.IsAlienSorted(new string[] { "kuvp", "q" }, "ngxlkthsjuoqcpavbfdermiywz"));
            }

            Console.WriteLine("Hello World!");
        }
        public bool IsAlienSorted(string[] words, string order)
        {
            Dictionary<char, char> ordered = new Dictionary<char, char>();
            for (int i = 0; i < order.Length; i++)
            {
                ordered.Add(order[i], (char)('a' + i));
            }
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!Compare(ordered, words[i], words[i + 1]))
                    return false;
            }
            return true;
        }
        private bool Compare(Dictionary<char, char> ordered, string a, string b)
        {
            int i = 0;
            int j = 0;
            while (i < a.Length && j < b.Length && a[i] == b[i])
            {
                i++;
                j++;
            }
            if (i == a.Length)
                return true;
            if (j == b.Length)
                return false;
            return ordered[a[i]] < ordered[b[i]];
        }
        public bool IsAlienSortedOrder(string[] words, string order)
        {
            Dictionary<char, char> ordered = new Dictionary<char, char>();
            for (int i = 0; i < order.Length; i++)
            {
                ordered.Add(order[i], (char)('a' + i));
            }
            var ord = words.OrderBy(x =>
            {
                string res = "";
                foreach (var item in x)
                    res = res + ordered[item];

                return res;
            });
            int cnt = 0;
            foreach (var item in ord)
            {
                if (item != words[cnt])
                    return false;
                cnt++;
            }
            return true;
        }
    }
}
