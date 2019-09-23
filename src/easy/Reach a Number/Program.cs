using System;

namespace Reach_a_Number
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.ReachNumber(3));//2
      Console.WriteLine(program.ReachNumber(2));//3
      Console.WriteLine("Hello World!");
    }
    public int ReachNumber(int target)
    {
      target = Math.Abs(target);
      int k = 0;
      while (target > 0)
        target -= ++k;
      return target % 2 == 0 ? k : k + 1 + k % 2;
    }
  }
}
