using System;
using System.Collections.Generic;

namespace Maximum_69_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //9969
            Console.WriteLine(program.Maximum69Number(9669));
            //9999
            Console.WriteLine(program.Maximum69Number(9996));
            Console.WriteLine("Hello World!");
        }
        public int Maximum69Number(int num)
        {
            Stack<int> stack = new Stack<int>();
            while (num != 0)
            {
                stack.Push(num % 10);
                num /= 10;
            }
            bool isFirst = true;
            while (stack.Count > 0)
            {
                int wk = stack.Pop();
                if (wk == 6 && isFirst)
                {
                    isFirst = false;
                    wk += 3;
                }
                num *= 10;
                num += wk;
            }
            return num;
        }
        public int Maximum69NumberStr(int num)
        {
            string wk = num.ToString();
            int index = -1;
            for (int i = 0; i < wk.Length; i++)
            {
                if ((wk[i] - '0') == 6)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                num += 3 * (int)Math.Pow(10, wk.Length - 1 - index);
            }
            return num;
        }
    }
}
