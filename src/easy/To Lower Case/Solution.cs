using System;

namespace To_Lower_Case
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.ToLowerCase("LOVELY"));
      Console.WriteLine("Hello World!");
    }
    public string ToLowerCase(string str)
    {
      return str.ToLower();
    }
  }
}
