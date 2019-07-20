using System;
using System.Collections.Generic;
using System.Text;

namespace Generate_Parentheses
{
    class Solution
    {
        static void Main(string[] args)
        {
            IList<string> res = null;
            Solution solution = new Solution();
            res = solution.GenerateParenthesis(3);
            Console.WriteLine("Hello World!");
        }

        public IList<string> GenerateParenthesis(int n)
        {
            var res = new List<string>();
            dfs(n, res, 0, "");
            return res;
        }
        private void dfs(int n, IList<string> res, int balance, string builder)
        {
            if (builder.Length == 2 * n && balance == 0)
            {
                res.Add(builder);
                return;
            }

            if (builder.Length > 2 * n || balance > 2 * n || balance < 0)
                return;

            dfs(n, res, balance + 1, builder + "(");
            dfs(n, res, balance - 1, builder + ")");
        }
        /*
        use DFS
         */
        public IList<string> GenerateParenthesisDFS(int n)
        {
            var res = new List<string>();
            dfs(n, res, 0, 0, "");
            return res;
        }

        private void dfs(int n, IList<string> res, int leftN, int rightN, string builder)
        {
            if (leftN > n || rightN > n || rightN > leftN)
                return;

            if (leftN == n && rightN == n)
            {
                res.Add(builder);
                return;
            }

            dfs(n, res, leftN + 1, rightN, builder + "(");
            dfs(n, res, leftN, rightN + 1, builder + ")");
        }
    }
}
