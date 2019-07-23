using System;
using System.Linq;

namespace Most_Common_Word
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string MostCommonWord(string paragraph, string[] banned)
        {
            char[] chars = new char[] { '!', '?', ',', '.', ';', ' ', '\'' };
            return paragraph.Split(chars).Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(x => x.ToLower()).Where(x => !banned.Contains(x)).
                GroupBy(x => x).Select(x => new { word = x.Key, Count = x.Count() }).
                OrderBy(x => x.Count).Last().word;
        }
    }
}
