using System;
using System.Collections.Generic;

namespace Valid_Parentheses
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var res = false;
            res = solution.IsValid("([)]");
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }
        public bool IsValid(string s)
        {
            Stack<char> queue = new Stack<char>();
            foreach (var item in s)
            {
                switch (item)
                {
                    case '(':
                    case '[':
                    case '{':
                        queue.Push(item);
                        break;
                    case ')':
                    case ']':
                    case '}':
                        if (queue.Count <= 0)
                            return false;
                        var inQueue = queue.Peek();
                        if (item == ')' && inQueue != '('
                        || item == ']' && inQueue != '['
                        || item == '}' && inQueue != '{')
                            return false;

                        queue.Pop();
                        break;
                    default:
                        break;
                }
            }
            return queue.Count == 0;
        }
    }
}
