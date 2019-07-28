using System;

namespace Number_Complement
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.FindComplement(5));//2
      Console.WriteLine(solution.FindComplement(1));//0
      Console.WriteLine(solution.FindComplement(2));//1
      Console.WriteLine(solution.FindComplement(2147483647));//0
      Console.WriteLine("Hello World!");
    }
    public int FindComplement(int num)
    {
      long res = 0;
      long CONST_BASE = 1;
      for (int i = 0; i <= 32 && num >= (CONST_BASE << i); i++)
      {
        if ((num & (CONST_BASE << i)) == 0)
        {
          res = res | (CONST_BASE << i);
        }
      }
      return (int)res;
    }
  }
}
