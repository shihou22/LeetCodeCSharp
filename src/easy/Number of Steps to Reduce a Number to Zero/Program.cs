using System;

namespace Number_of_Steps_to_Reduce_a_Number_to_Zero
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //   6
      Console.WriteLine(program.NumberOfSteps(14));
      // 4
      Console.WriteLine(program.NumberOfSteps(8));
      // 12
      Console.WriteLine(program.NumberOfSteps(123));

      Console.WriteLine("Hello World!");
    }
    public int NumberOfSteps(int num)
    {
      return num == 0 ? 0 : 1 + (((num % 2) == 0) ? NumberOfSteps(num >> 1) : NumberOfSteps(--num));
    }
    public int NumberOfStepsIteration(int num)
    {
      int cnt = 0;
      while (num > 0)
      {
        if (num % 2 == 0)
          num >>= 1;
        else
          num--;
        cnt++;
      }
      return cnt;
    }
  }
}
