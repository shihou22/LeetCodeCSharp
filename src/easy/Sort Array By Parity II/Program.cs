using System;

namespace Sort_Array_By_Parity_II
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //   Console.WriteLine(program.SortArrayByParityII(new int[] { 4, 2, 5, 7 }));//[4,5,2,7]
      Console.WriteLine(program.SortArrayByParityII(new int[] { 3, 1, 4, 2 }));//[4,5,2,7]
      Console.WriteLine("Hello World!");
    }

    public int[] SortArrayByParityII(int[] A)
    {
      int[] res = new int[A.Length];
      int o = 1;
      int e = 0;
      foreach (var item in A)
      {
        if (item % 2 == 0)
        {
          res[e] = item;
          e += 2;
        }
        else
        {
          res[o] = item;
          o += 2;
        }
      }
      return res;
    }
  }
}
