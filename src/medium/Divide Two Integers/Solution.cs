using System;

namespace Divide_Two_Integers
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.Divide(10, 3));//3
      Console.WriteLine(solution.Divide(7, -3));//-2
      Console.WriteLine("Hello World!");
    }
    public int Divide(int dividend, int divisor)
    {
      if (divisor == 0)
        return 0;
      int original_b = divisor;
      int c = 1;
      int q = 0;
      while (gte(dividend, divisor))
      {
        divisor <<= 1;
        if (gte(dividend, divisor)) c <<= 1;
        else
        {
          q = add(q, c);
          c = 1;
          divisor >>= 1;
          dividend = sub(dividend, divisor);
          divisor = original_b;
        }
      }
      return q;
    }
    /*
    https://qiita.com/ruuuuuuuty/items/a8edf4c22f56b5456994#%E5%8A%A0%E7%AE%97ab
     */
    private int add(int a, int b)
    {
      int t;
      while (b != 0)
      {
        t = (a & b) << 1;
        a ^= b;
        b = t;
      }
      return a;
    }
    /*
    https://qiita.com/ruuuuuuuty/items/a8edf4c22f56b5456994#%E6%B8%9B%E7%AE%97a-b
     */
    private int sub(int a, int b)
    {
      int comp = add(~b, 1);
      return add(a, comp);
    }
    private bool gte(int a, int b)
    {
      int c = sub(a, b);
      c >>= 31;
      return (c & 1) == 0;
    }

  }
}
