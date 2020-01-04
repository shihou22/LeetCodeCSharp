using System;

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
          int wkMax = maxS[max - 1 - i] - '0';
          int wk = wkMax * wkIn + carry;
          carry = (wk % 10);
          wk %= 10;
          wkRes = wk + wkRes;
        }
        if (carry != 0)
          wkRes = carry + "" + wkRes;

        carry = 0;
        for (int j = 0; j < wkRes.Length; j++)
        {
          int wkP1 = wkRes[wkRes.Length - 1 - j] - '0';
          int wkP2 = res[res.Length - 1 - j - i] - '0';
          int wk = wkP1 + wkP2 + carry;
          carry = (wk % 10);
          wk %= 10;
          res[res.Length - 1 - j - i] = wk;
        }
        if (carry != 0)

      }
      return res;
    }
  }
}
