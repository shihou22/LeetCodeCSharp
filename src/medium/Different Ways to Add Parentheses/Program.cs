using System;
using System.Collections.Generic;

namespace Different_Ways_to_Add_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            var res1 = program.DiffWaysToCompute("2-1-1");
            Console.WriteLine("Hello World!");
        }
        public List<int> DiffWaysToCompute(String input)
        {
            List<int> operands = new List<int>();
            List<char> ops = new List<char>();
            int r = 0;
            while (r < input.Length)
            {
                int num = 0;
                while (r < input.Length && input[r] - '0' >= 0 && input[r] - '0' <= 9)
                {
                    num = num * 10 + (int)(input[r] - '0');
                    r++;
                }
                operands.Add(num);
                if (r < input.Length)
                {
                    ops.Add(input[r]);
                    r++;
                }
            }
            return helper(operands, ops, 0, operands.Count - 1);
        }
        public List<int> helper(List<int> operands, List<char> ops, int start, int end)
        {
            List<int> ans = new List<int>();
            if (start == end)
            {
                ans.Add(operands[start]);
                return ans;
            }
            for (int i = start; i < end; i++)
            {
                List<int> left = helper(operands, ops, start, i);
                List<int> right = helper(operands, ops, i + 1, end);
                for (int l = 0; l < left.Count; l++)
                {
                    for (int r = 0; r < right.Count; r++)
                        ans.Add(compute(left[l], right[r], ops[i]));
                }
            }
            return ans;
        }
        private int compute(int a, int b, char opcode)
        {
            switch (opcode)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
            }
            return 0;
        }
    }
}
