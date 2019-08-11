using System;

namespace Divisor_Game
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.DivisorGame(2));//true
      Console.WriteLine(solution.DivisorGame(3));//false
      Console.WriteLine("Hello World!");
    }
    public bool DivisorGame(int N)
    {
      return N % 2 == 0;
    }
  }
}
