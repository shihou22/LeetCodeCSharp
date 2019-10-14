using System;

namespace Complement_of_Base_10_Integer
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //2
      Console.WriteLine(program.BitwiseComplement(5));
      //0
      Console.WriteLine(program.BitwiseComplement(7));
      //5
      Console.WriteLine(program.BitwiseComplement(10));
      //1
      Console.WriteLine(program.BitwiseComplement(0));
      //0
      Console.WriteLine(program.BitwiseComplement(1));
      Console.WriteLine("Hello World!");
    }
    public int BitwiseComplement(int N)
    {
      if (N == 0)
        return 1;
      string res = "";
      while (N > 0)
      {
        int wk = (N & 1) == 0 ? 1 : 0;
        res = wk + res;
        N >>= 1;
      }
      int ret = Convert.ToInt32(res, 2);
      return ret > 2 ? ret : ret;
    }
  }
}
