using System.Numerics;
using System;

namespace Prime_Arrangements
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      // Console.WriteLine(program.NumPrimeArrangements(5));//12
      Console.WriteLine(program.NumPrimeArrangements(100));//682289015
      // var modInv = BigInteger.ModPow(2, 13 - 2, 13);//7
      // Console.WriteLine(modInv);
      Console.WriteLine("Hello World!");
    }
    public int NumPrimeArrangements(int n)
    {
      int permu = 0;
      for (int i = 2; i <= n; i++)
      {
        if (isPrime(i))
        {
          permu++;
        }
      }
      //素数の数　×　素数ではない数
      long val = factorial(permu) * factorial(n - permu) % mod;
      // var wk = BigInteger.ModPow(factorial(n - permu), mod - 2, mod);
      // long val = factorial(n) * (long)wk % mod;
      return (int)val;
    }

    const long mod = 1000000007;

    private bool isPrime(int x)
    {
      if (x <= 1)
        return false;

      for (int i = 2; i * i <= x; i++)
      {
        if (x % i == 0)
          return false;
      }
      return true;
    }

    private long factorial(int x)
    {
      long res = 1;
      for (long i = 1; i <= x; i++)
      {
        res = (res * i) % mod;
      }
      return res % mod;
    }


  }
}
