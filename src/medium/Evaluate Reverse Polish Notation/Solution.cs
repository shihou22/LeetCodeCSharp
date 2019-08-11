using System.Collections.Generic;
using System;

namespace Evaluate_Reverse_Polish_Notation
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      // Console.WriteLine(solution.EvalRPN(new string[] { "2", "1", "+", "3", "*" }));//9
      Console.WriteLine(solution.EvalRPN(new string[] { "4", "13", "5", "/", "+" }));//6
      Console.WriteLine("Hello World!");
    }
    public int EvalRPN(string[] tokens)
    {
      Stack<int> stack = new Stack<int>();
      foreach (var item in tokens)
      {
        int a = 0;
        int b = 0;
        switch (item)
        {
          case "+":
            b = stack.Pop();
            a = stack.Pop();
            stack.Push(a + b);
            break;
          case "-":
            b = stack.Pop();
            a = stack.Pop();
            stack.Push(a - b);
            break;
          case "/":
            b = stack.Pop();
            a = stack.Pop();
            stack.Push(a / b);
            break;
          case "*":
            b = stack.Pop();
            a = stack.Pop();
            stack.Push(a * b);
            break;
          default:
            stack.Push(int.Parse(item));
            break;
        }
      }
      return stack.Pop();
    }
  }
}
