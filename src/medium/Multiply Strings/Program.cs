using System.Text;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Multiply_Strings
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //6
      Console.WriteLine(program.Multiply("2", "3"));
      //56088
      Console.WriteLine(program.Multiply("123", "456"));
      Console.WriteLine("Hello World!");
    }
    public string Multiply(string num1, string num2)
    {
      if (num1.Max() == '0' || num2.Max() == '0')
        return "0";
      int max = Math.Max(num1.Length, num2.Length);
      int min = Math.Min(num1.Length, num2.Length);
      string maxS = "", minS = "";
      if (num1.Length >= num2.Length)
      {
        maxS = num1;
        minS = num2;
      }
      else
      {
        maxS = num2;
        minS = num1;
      }
      string res = "";
      for (int i = 0; i < min; i++)
      {
        int wkIn = minS[min - 1 - i] - '0';
        int carry = 0;
        string wkRes = "";
        for (int j = 0; j < max; j++)
        {
          int wkMax = maxS[max - 1 - j] - '0';
          int wk = wkMax * wkIn + carry;
          carry = wk / 10;
          wk %= 10;
          wkRes = wk + wkRes;
        }
        if (carry != 0)
          wkRes = carry + "" + wkRes;

        if (res.Length == 0)
        {
          res = wkRes;
          continue;
        }

        int addMax = Math.Max(res.Length - i, wkRes.Length);
        carry = 0;
        String wkRes2 = res.Substring(res.Length - i);
        for (int j = 0; j < addMax; j++)
        {
          int wkMax = 0;
          if (res.Length - 1 - i - j >= 0)
            wkMax = res[res.Length - 1 - i - j] - '0';
          int wk = 0;
          if (wkRes.Length - 1 - j >= 0)
            wk = wkRes[wkRes.Length - 1 - j] - '0';

          wk = wk + wkMax + carry;
          carry = wk / 10;
          wk %= 10;
          wkRes2 = wk + wkRes2;
        }
        if (carry != 0)
          wkRes2 = carry + wkRes2;
        res = wkRes2;
      }
      return res;
    }
  }
}
