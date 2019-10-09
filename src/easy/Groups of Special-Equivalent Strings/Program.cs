using System;
using System.Collections.Generic;
using System.Text;

namespace Groups_of_Special_Equivalent_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //3
            // Console.WriteLine(program.NumSpecialEquivGroups(new string[] { "a", "b", "c", "a", "c", "c" }));
            //4
            // Console.WriteLine(program.NumSpecialEquivGroups(new string[] { "aa", "bb", "ab", "ba" }));
            //3
            Console.WriteLine(program.NumSpecialEquivGroups(new string[] { "abc", "acb", "bac", "bca", "cab", "cba" }));
            Console.WriteLine("Hello World!");
        }
        public int NumSpecialEquivGroups(string[] A)
        {
            var seen = new HashSet<string>();
            var evens = new List<char>();
            var odds = new List<char>();
            foreach (var s in A)
            {
                evens.Clear();
                odds.Clear();
                /*
                内容は、
                -偶数の順番の文字列を入れ替える
                -奇数の順番の文字列を入れ替える
                上記操作をした結果、同じ文字になる組み合わせを選べ。
                なので、「偶数だけ集めてsort、奇数だけ集めてsort」「結果を結合して文字列を作成」することによって、
                グルーピングができる。
                1グループの中に何個含まれるのかは問われていないのでhashで問題ない。
                 */
                for (int i = 0; i < s.Length; i++)
                {
                    if (i % 2 == 0)
                        evens.Add(s[i]);
                    else
                        odds.Add(s[i]);
                }
                evens.Sort();
                odds.Sort();
                seen.Add(new string(evens.ToArray()) + new string(odds.ToArray()));
            }
            return seen.Count;
        }
    }
}
