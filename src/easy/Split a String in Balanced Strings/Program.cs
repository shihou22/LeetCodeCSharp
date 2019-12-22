using System;

namespace Split_a_String_in_Balanced_Strings
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //4
      Console.WriteLine(program.BalancedStringSplit("RLRRLLRLRL"));
      //3
      Console.WriteLine(program.BalancedStringSplit("RLLLLRRRLR"));
      Console.WriteLine("Hello World!");
    }
    public int BalancedStringSplit(string s)
    {
      int cntR = 0;
      int cntL = 0;
      int max = 0;
      foreach (var item in s)
      {
        if (item == 'R')
          cntR++;
        else
          cntL++;

        if (cntR == cntL)
        {
          cntR = 0;
          cntL = 0;
          max++;
        }

      }
      if (cntR != 0 && cntL != 0)
        max++;
      return max;
    }
  }
}
