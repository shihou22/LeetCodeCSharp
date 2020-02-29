using System;
using System.Linq;
using System.Collections.Generic;

namespace Maximum_Length_of_a_Concatenated_String_with_Unique_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //4
            Console.WriteLine(program.MaxLength(new List<string>() { "un", "iq", "ue" }));
            //6
            Console.WriteLine(program.MaxLength(new List<string>() { "cha", "r", "act", "ers" }));
            //26
            Console.WriteLine(program.MaxLength(new List<string>() { "abcdefghijklmnopqrstuvwxyz" }));
            //16
            Console.WriteLine(program.MaxLength(new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" }));
            //16
            Console.WriteLine(program.MaxLength(new List<string>() { "ab", "ba", "cd", "dc", "ef", "fe", "gh", "hg", "ij", "ji", "kl", "lk", "mn", "nm", "op", "po" }));
            //6
            Console.WriteLine(program.MaxLength(new List<string>() { "cha", "r", "act", "ers" }));
            //0
            Console.WriteLine(program.MaxLength(new List<string>() { "yy", "bkhwmpbiisbldzknpm" }));
            Console.WriteLine("Hello World!");
        }
        public int MaxLength(IList<string> arr)
        {
            res = 0;
            wk = new List<Tuple<int, ISet<char>>>();
            foreach (var item in arr)
            {
                ISet<char> memo = new HashSet<char>();
                bool isUse = true;
                foreach (var c in item)
                {
                    if (memo.Contains(c))
                    {
                        isUse = false;
                        break;
                    }
                    memo.Add(c);
                }
                if (!isUse)
                    continue;
                wk.Add(new Tuple<int, ISet<char>>(item.Length, memo));
                res = Math.Max(res, item.Length);
            }
            DFS(new HashSet<char>(), 0, 0);
            return res;
        }
        List<Tuple<int, ISet<char>>> wk;
        int res = 0;
        private void DFS(ISet<char> currUse, int currIdx, int currSum)
        {
            res = Math.Max(res, currSum);
            if (currIdx >= wk.Count)
                return;

            DFS(new HashSet<char>(currUse), currIdx + 1, currSum);
            // DFS(new HashSet<char>(wk[currIdx].Item2), currIdx + 1, wk[currIdx].Item1);
            ISet<char> s1 = new HashSet<char>(currUse);
            ISet<char> s2 = wk[currIdx].Item2;
            s1.IntersectWith(s2);
            if (s1.Count == 0)
            {
                s1 = new HashSet<char>(currUse);
                s1.UnionWith(s2);
                DFS(s1, currIdx + 1, currSum + wk[currIdx].Item1);
            }

        }
    }
}
