using System.Collections.Generic;
using System;

namespace Prime_Number_of_Set_Bits_in_Binary_Representation
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      //   Console.WriteLine(solution.CountPrimeSetBits(6, 10));//4
      //   Console.WriteLine(solution.CountPrimeSetBits(10, 15));//5
      Console.WriteLine(solution.CountPrimeSetBits(990, 1048));//28
      Console.WriteLine("Hello World!");
    }
    public int CountPrimeSetBits(int L, int R)
    {
      int res = 0;
      HashSet<int> set = GetPrimeList();
      for (int i = L; i <= R; i++)
      {
        int cnt = GetBitCount(i);
        if (set.Contains(cnt))
          res++;
      }
      return res;
    }
    /*
    bitカウント
     */
    private int GetBitCount(int x)
    {
      int res = 0;
      while (x > 0)
      {
        x = x & (x - 1);
        res++;
      }
      //   while (x > 0)
      //   {
      //     if ((x & 1) == 1)
      //       res++;
      //     x >>= 1;
      //   }
      return res;
    }
    /*
    素数マップの作製
    素数判定
    ちょい重い
     */
    private HashSet<int> GetPrimeList()
    {
      HashSet<int> set = new HashSet<int>();
      set.Add(2);
      set.Add(3);
      set.Add(5);
      set.Add(7);
      set.Add(11);
      set.Add(13);
      set.Add(17);
      set.Add(19);
    //   set.Add(2);
    //   for (int i = 3; i <= (int)Math.Pow(10, 6); i += 2)
    //   {
    //     int max = (int)Math.Sqrt(i);
    //     bool prime = true;
    //     for (int j = 2; j <= max; j++)
    //     {
    //       if (i % j == 0)
    //       {
    //         prime = false;
    //         break;
    //       }
    //     }
    //     if (prime)
    //       set.Add(i);
    //   }
      return set;
    }
  }
}
