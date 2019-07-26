using System;
using System.Collections.Generic;

namespace Clumsy_Factorial
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // Console.WriteLine(solution.Clumsy(4)); //7
            Console.WriteLine(solution.Clumsy(10)); //12
            Console.WriteLine("Hello World!");
        }
        public int Clumsy(int N)
        {
            IList<int> stack = new List<int>();

            int cnt = 1;
            while (N != 0)
            {
                if (cnt > 4)
                    cnt = 1;
                var tmp = N;
                N -= 1;
                if (stack.Count == 0)
                {
                    stack.Add(tmp);
                    continue;
                }
                var pre = 0;
                var tmpRes = 0;
                switch (cnt)
                {
                    case 1:
                        pre = stack[stack.Count - 1];
                        stack.RemoveAt(stack.Count - 1);
                        tmpRes = pre * tmp;
                        stack.Add(tmpRes);
                        break;
                    case 2:
                        pre = stack[stack.Count - 1];
                        stack.RemoveAt(stack.Count - 1);
                        tmpRes = pre / tmp;
                        stack.Add(tmpRes);
                        break;
                    case 3:
                    case 4:
                        stack.Add(tmp);
                        break;
                    default:
                        break;
                }
                cnt++;
            }
            cnt = 1;
            while (stack.Count > 1)
            {
                var first = stack[0];
                var second = stack[1];
                if (cnt == 1)
                    stack[0] = first + second;
                else
                    stack[0] = first - second;
                stack.RemoveAt(1);
                cnt = 1 - cnt; ;
            }
            return stack[0];
        }
    }
}
