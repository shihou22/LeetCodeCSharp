using System;
using System.Linq;
using System.Collections.Generic;

namespace Uncommon_Words_from_Two_Sentences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        private Dictionary<string, int> CreateDict(string[] memo)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var item in memo)
            {
                if (dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict.Add(item, 1);
            }
            return dict;
        }
        private IList<string> ExceptDict(Dictionary<string, int> dictA, Dictionary<string, int> dictB)
        {

            List<string> res = new List<string>();
            foreach (var item in dictA)
            {
                if (item.Value > 1)
                    continue;
                if (!dictB.ContainsKey(item.Key))
                    res.Add(item.Key);
            }
            return res;
        }
        public string[] UncommonFromSentencesMap(string A, string B)
        {
            string[] memoA = A.Split(" ");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var item in memoA)
            {
                if (dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict.Add(item, 1);
            }
            string[] memoB = B.Split(" ");
            foreach (var item in memoB)
            {
                if (dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict.Add(item, 1);
            }

            List<string> res = new List<string>();
            foreach (var item in dict)
            {
                if (item.Value == 1)
                    res.Add(item.Key);
            }
            return res.ToArray();
        }
        public string[] UncommonFromSentences(string A, string B)
        {
            string[] memoA = A.Split(" ");
            Dictionary<string, int> dictA = CreateDict(memoA);

            string[] memoB = B.Split(" ");
            Dictionary<string, int> dictB = CreateDict(memoB);

            List<string> res = new List<string>();
            res.AddRange(ExceptDict(dictA, dictB));
            res.AddRange(ExceptDict(dictB, dictA));

            return res.ToArray();
        }
    }
}
