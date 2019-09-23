using System;

namespace DI_String_Match
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int[] DiStringMatch(string S)
    {
      int[] res = new int[S.Length + 1];
      int lo = 0;
      int hi = S.Length;
      for (int i = 0; i < S.Length; i++)
      {
        if (S[i] == 'I')
        {
          res[i] = lo;
          lo++;
        }
        else if (S[i] == 'D')
        {
          res[i] = hi;
          hi--;
        }
      }
      res[S.Length] = hi;
      return res;
    }
  }
}
