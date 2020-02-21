using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Basic_Calculator_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine(program.Calculate("3+2*2"));// 7
            Console.WriteLine(program.Calculate(" 3/2 "));// 1
            Console.WriteLine(program.Calculate(" 3+5 / 2 "));// 5
            Console.WriteLine(program.Calculate("0-2147483647"));// -2147483647
            Console.WriteLine(program.Calculate("1+1+1"));// 3
            Console.WriteLine(program.Calculate("1-1+1"));// 1
            Console.WriteLine(program.Calculate("1*2-3/4+5*6-7*8+9/10"));
            Console.WriteLine(program.Calculate("1*2*3*4*5"));
            Console.WriteLine("Hello World!");
        }
        public int Calculate(string s)
        {
            string wk = s.Replace(" ", "");
            Queue<string> queue = new Queue<string>();
            int len = 0;
            while (len < wk.Length)
            {
                int max = 0;
                while (len + max < wk.Length && IsNum(wk[len + max]))
                    max++;

                queue.Enqueue(wk.Substring(len, max));
                len += max;
                if (len < wk.Length)
                    queue.Enqueue(wk.Substring(len, 1));
                len++;
            }
            Stack<string> stack = new Stack<string>();
            while (queue.Count > 0)
            {
                string item = queue.Dequeue();
                switch (item)
                {
                    case "/":
                    case "*":
                        var am = long.Parse(stack.Pop());
                        var bm = long.Parse(queue.Dequeue());
                        var cm = calc(am, bm, item);
                        stack.Push(cm.ToString());
                        break;
                    default:
                        stack.Push(item);
                        break;
                }
            }
            return AllCalc(stack);
        }
        private bool IsNum(char type)
        {
            return (type - '0' >= 0 && type - '0' <= 9);
        }
        private int AllCalc(Stack<string> stack)
        {
            Queue<string> queue = new Queue<string>(stack.Reverse());
            long cnt = long.Parse(queue.Dequeue());
            while (queue.Count > 0)
            {
                char type = queue.Dequeue()[0];
                long a = long.Parse(queue.Dequeue());
                cnt = calc(cnt, a, type);
            }
            return (int)cnt;
        }
        private long calc(long a, long b, string type)
        {
            return calc(a, b, type[0]);
        }
        private long calc(long a, long b, char type)
        {
            switch (type)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '/':
                    return a / b;
                case '*':
                    return a * b;
            }
            return -1;
        }
    }
}
