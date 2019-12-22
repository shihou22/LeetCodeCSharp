using System;
using System.Collections.Generic;

namespace Fizz_Buzz
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public IList<string> FizzBuzz2(int n)
    {
      IList<string> res = new List<string>();
      for (int i = 1; i <= n; i++)
      {
        string s = "";
        if (i % 3 == 0)
        {
          s += "Fizz";
        }
        if (i % 5 == 0)
        {
          s += "Buzz";
        }
        res.Add(s != "" ? s : i.ToString());
      }
      return res;
    }
    public IList<string> FizzBuzz(int n)
    {
      IList<string> res = new List<string>();
      for (int i = 1; i <= n; i++)
      {
        if (i % 15 == 0)
        {
          res.Add("FizzBuzz");
        }
        else if (i % 5 == 0)
        {
          res.Add("Buzz");
        }
        else if (i % 3 == 0)
        {
          res.Add("Fizz");
        }
        else
        {
          res.Add(i.ToString());
        }
      }
      return res;
    }
  }
}
