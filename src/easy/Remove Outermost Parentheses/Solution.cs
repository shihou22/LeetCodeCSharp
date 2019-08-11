using System.Collections.Generic;
using System;

namespace Remove_Outermost_Parentheses
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.RemoveOuterParentheses("(()())(())"));//"()()()"
      Console.WriteLine(solution.RemoveOuterParentheses("(()())(())(()(()))"));//"()()()()(())"
      Console.WriteLine(solution.RemoveOuterParentheses("()()"));//
      Console.WriteLine("Hello World!");
    }
    public string RemoveOuterParentheses(string S)
    {
      if (S.Length == 0)
        return "";
      Stack<char> stack = new Stack<char>();
      int start = 0;
      string res = "";
      stack.Push(S[0]);
      for (int i = 1; i < S.Length; i++)
      {
        switch (S[i])
        {
          case '(':
            stack.Push(S[i]);
            break;
          case ')':
            stack.Pop();
            break;
        }

        if (stack.Count == 0)
        {
          res += S.Substring(start + 1, i - (start + 1));
          start = i + 1;
        }

      }
      return res;

    }
  }
}
