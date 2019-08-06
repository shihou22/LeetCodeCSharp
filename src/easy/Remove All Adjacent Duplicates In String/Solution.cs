using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remove_All_Adjacent_Duplicates_In_String
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.RemoveDuplicates("abbaca"));//ca
            Console.WriteLine("Hello World!");
        }
        public string RemoveDuplicates(string S)
        {
            Stack<char> memo = new Stack<char>();
            foreach (var item in S)
            {
                if (memo.Count == 0)
                {
                    memo.Push(item);
                    continue;
                }
                var temp = memo.Peek();
                if (temp != item)
                    memo.Push(item);
                else
                    memo.Pop();
            }
            StringBuilder res = new StringBuilder();
            foreach (var item in memo.ToArray().Reverse())
            {
                res.Append(item);
            }
            return res.ToString();
        }
    }
}
