using System;
using System.Collections.Generic;

namespace Baseball_Game
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.CalPoints(new string[] { "5", "2", "C", "D", "+" }));//30
            Console.WriteLine(solution.CalPoints(new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" }));//27
            Console.WriteLine("Hello World!");
        }
        public int CalPoints(string[] ops)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var item in ops)
            {
                var wk1 = 0;
                var wk2 = 0;
                switch (item)
                {
                    case "+":
                        wk1 = stack.Pop();
                        wk2 = stack.Pop();
                        stack.Push(wk2);
                        stack.Push(wk1);
                        stack.Push(wk1 + wk2);
                        break;
                    case "C":
                        if (stack.Count != 0)
                            stack.Pop();
                        break;
                    case "D":
                        if (stack.Count != 0)
                        {
                            wk1 = stack.Pop();
                            stack.Push(wk1);
                            stack.Push(wk1 * 2);
                        }
                        break;
                    default:
                        stack.Push(int.Parse(item));
                        break;
                }

            }
            int res = 0;
            foreach (var item in stack)
            {
                res += item;
            }
            return res;
        }
    }
}
