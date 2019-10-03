using System.Collections.Generic;
using System;

namespace Maximum_Number_of_Balloons
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int MaxNumberOfBalloons(string text)
    {
      char[] wk = new char[26];
      foreach (var item in text)
      {
        wk[item - 'a']++;
      }
      int minNum = int.MaxValue;
      minNum = Math.Min(wk['b' - 'a'], minNum);
      minNum = Math.Min(wk['a' - 'a'], minNum);
      minNum = Math.Min(wk['l' - 'a'] / 2, minNum);
      minNum = Math.Min(wk['o' - 'a'] / 2, minNum);
      minNum = Math.Min(wk['n' - 'a'], minNum);
      return minNum;
    }
  }
}
