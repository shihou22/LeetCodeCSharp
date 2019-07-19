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
            if (beginWord == endWord || !wordList.Contains(endWord))
                return 0;

            HashSet<string> wkList = new HashSet<string>(wordList);
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            var cnt = 1;
            while (queue.Count > 0)
            {
                cnt++;
                var max = queue.Count;
                /*
                現時点でQueueに詰まっているものだけ実行
                動的に取得するとqueueを入れるたびに実行してしまうため。
                こうすることで段階を把握することができる。
                 */
                for (int i = 0; i < max; i++)
                {
                    var baseWord = queue.Dequeue();
                    IList<string> wk = GetNeighborsFromChar(baseWord, wkList);
                    foreach (var item in wk)
                    {
                        if (item == endWord)
                            return cnt;

                        queue.Enqueue(item);
                    }
                }

            }
            return 0;
        }

        private IList<string> GetNeighborsFromChar(string baseWord, HashSet<string> wkList)
        {
            IList<string> res = new List<string>();
            char[] sample = baseWord.ToCharArray();
            for (int i = 0; i < baseWord.Length; i++)
            {
                char c = sample[i];
                for (int j = 0; j < 26; j++)
                {
                    sample[i] = Convert.ToChar('a' + j);
                    string tmp = new String(sample);
                    if (wkList.Contains(tmp))
                    {
                        res.Add(tmp);
                        wkList.Remove(tmp);
                    }
                }
                sample[i] = c;
            }
            return res;

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
