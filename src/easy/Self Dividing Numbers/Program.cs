using System.Collections.Generic;
using System;

namespace Self_Dividing_Numbers
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      IList<int> res = program.SelfDividingNumbers(1, 22);
      Console.WriteLine("Hello World!");
    }
    public IList<int> SelfDividingNumbers(int left, int right)
    {
      IList<int> res = new List<int>();
      for (int i = left; i <= right; i++)
      {
        bool isOk = true;
        int num = i;
        while (num > 0)
        {
          int div = num % 10;
          if (div == 0 || i % div != 0)
          {
            isOk = false;
            break;
          }
          num /= 10;
        }
        if (isOk)
          res.Add(i);
      }
      return res;
    }
    public IList<int> SelfDividingNumbersSloq(int left, int right)
    {
      IList<int> res = new List<int>();
      for (int i = left; i <= right; i++)
      {
        HashSet<int> set = Divide(i);
        if (set.Contains(0))
          continue;
        bool isOk = true;
        foreach (var item in set)
        {
          if (i % item != 0)
          {
            isOk = false;
            break;
          }
        }
        if (isOk)
          res.Add(i);
      }
      return res;
    }

    private HashSet<int> Divide(int num)
    {
      HashSet<int> set = new HashSet<int>();
      while (num > 0)
      {
        int div = num % 10;
        set.Add(div);
        num /= 10;
      }
      return set;
    }
  }
}
