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
            // Console.WriteLine(program.MaxLength(new List<string>() { "un", "iq", "ue" }));
            // 6
            // Console.WriteLine(program.MaxLength(new List<string>() { "cha", "r", "act", "ers" }));
            //26
            // Console.WriteLine(program.MaxLength(new List<string>() { "abcdefghijklmnopqrstuvwxyz" }));
            //16
            // Console.WriteLine(program.MaxLength(new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" }));
            //16
            // Console.WriteLine(program.MaxLength(new List<string>() { "ab", "ba", "cd", "dc", "ef", "fe", "gh", "hg", "ij", "ji", "kl", "lk", "mn", "nm", "op", "po" }));
            //6
            // Console.WriteLine(program.MaxLength(new List<string>() { "cha", "r", "act", "ers" }));
            //0
            // Console.WriteLine(program.MaxLength(new List<string>() { "yy", "bkhwmpbiisbldzknpm" }));
            //21
            Console.WriteLine(program.MaxLength(new List<string>() { "mcjglvqeotdnzuak", "jcxilwsfkq", "qsbrwmgozcekpvatijdx", "pkwtsqzuxm", "nlpdsybfmgewh", "cdaftgxhins", "lrzmjsquypna", "mxcntrephqfwalb", "bjrzgmykelqi", "aumy", "qkglzptfbmsyjracohdi", "vtnrmlgkexpqf", "gzwcqvo", "tmudcfkhjsvryzeqwinao", "rv", "bedjlfgwthyomizrs" }));
            Console.WriteLine("Hello World!");
        }
        public int MaxLength(IList<string> arr)
        {
            int max = Int32.MinValue;

            for (int i = 0; i < arr.Count; i++)
            {
                int tmpMax = GetMax(arr[i], arr, i);
                max = Math.Max(max, tmpMax);
            }

            return max;
        }

        private int GetMax(string word, IList<string> arr, int currentIndex)
        {
            HashSet<char> letters = new HashSet<char>();

            for (int i = 0; i < word.Length; i++)
            {
                if (letters.Contains(word[i]))
                {
                    return 0;
                }

                letters.Add(word[i]);
            }

            int max = letters.Count;

            for (int i = currentIndex + 1; i < arr.Count; i++)
            {
                int tempMax = GetMax(word + arr[i], arr, i);
                max = Math.Max(max, tempMax);
            }

            return max;
        }

        public int MaxLengthFirstBitCounting(IList<string> arr)
        {
            int localRes = 0;
            List<ISet<char>> wk = new List<ISet<char>>();
            foreach (var item in arr.OrderByDescending(x => x.Length))
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
                wk.Add(memo);
                localRes = Math.Max(localRes, item.Length);
            }

            for (int i = 1; i < (1 << wk.Count); i++)
            {
                int idx = 0;
                int num = i;
                var currUse = new HashSet<char>();
                int currSum = 0;
                while (num != 0)
                {
                    if ((num & 1) == 1)
                    {
                        bool isOk = true;
                        ISet<char> tmpHash = wk[idx];
                        foreach (var item in currUse)
                        {
                            if (tmpHash.Contains(item))
                            {
                                isOk = false;
                                break;
                            }
                        }
                        if (isOk)
                        {
                            currUse.UnionWith(tmpHash);
                            currSum += wk[idx].Count;
                        }
                    }
                    num >>= 1;
                    idx++;
                }
                localRes = Math.Max(localRes, currSum);
            }
            return localRes;
        }
        public int MaxLengthBit2(IList<string> arr)
        {
            int localRes = 0;
            List<ISet<char>> wk = new List<ISet<char>>();
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
                wk.Add(memo);
                localRes = Math.Max(localRes, item.Length);
            }

            for (int i = 1; i < (1 << wk.Count); i++)
            {
                int idx = 0;
                int num = i;
                int currSum = 0;
                List<int> indexes = new List<int>();
                while (num != 0)
                {
                    if ((num & 1) == 1)
                    {
                        currSum += wk[idx].Count;
                        indexes.Add(idx);
                    }
                    num >>= 1;
                    idx++;
                }
                if (currSum <= localRes)
                    continue;
                currSum = 0;
                var currUse = new HashSet<char>();
                foreach (var tIdx in indexes)
                {
                    bool isOk = true;
                    ISet<char> tmpHash = wk[tIdx];
                    foreach (var item in currUse)
                    {
                        if (tmpHash.Contains(item))
                        {
                            isOk = false;
                            break;
                        }
                    }
                    if (isOk)
                    {
                        currUse.UnionWith(tmpHash);
                        currSum += wk[tIdx].Count;
                    }
                }
                localRes = Math.Max(localRes, currSum);
            }
            return localRes;
        }
        public int MaxLengthDFS(IList<string> arr)
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
