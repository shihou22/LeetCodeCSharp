using System;
using System.Collections.Generic;

namespace Word_Ladder
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.LadderLength("red", "tax", new List<string>() { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" });
            Console.WriteLine("Hello World!");
        }
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
        }
        public int LadderLengthTle(string beginWord, string endWord, IList<string> wordList)
        {
            if (beginWord == endWord || !wordList.Contains(endWord))
            {
                return 0;
            }
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            var cnt = 1;
            while (queue.Count > 0)
            {
                cnt++;
                var max = queue.Count;
                for (int i = 0; i < max; i++)
                {

                    var baseWord = queue.Dequeue();
                    IList<string> wk = GetNeighbors(baseWord, wordList);
                    foreach (var item in wk)
                    {
                        if (item == endWord)
                        {
                            return cnt;
                        }
                        queue.Enqueue(item);
                    }
                }

            }
            return 0;

        }

        private IList<string> GetNeighbors(string baseWord, IList<string> wordList)
        {
            IList<string> res = new List<string>();
            foreach (var item in wordList)
            {
                var distance = GetLevenshteinDistance(baseWord, item);
                if (distance == 1)
                    res.Add(item);
            }

            foreach (var item in res)
            {
                if (wordList.Contains(item))
                    wordList.Remove(item);
            }
            return res;

        }

        private int GetLevenshteinDistance(string w1, string w2)
        {
            if (w1 == null || w1.Length == 0)
                return w2.Length;
            if (w2 == null || w2.Length == 0)
                return w1.Length;

            if (w1[0] == w2[0])
                return GetLevenshteinDistance(w1.Substring(1), w2.Substring(1));

            var l1 = GetLevenshteinDistance(w1, w2.Substring(1));
            var l2 = GetLevenshteinDistance(w1.Substring(1), w2);
            var l3 = GetLevenshteinDistance(w1.Substring(1), w2.Substring(1));

            return 1 + Math.Min(l1, Math.Min(l2, l3));
        }
    }
}
