using System.Linq;
using System;

namespace Sort_Integers_by_The_Number_of_1_Bits
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      var res1 = program.SortByBits(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });//[0,1,2,4,8,3,5,6,7]
      var res2 = program.SortByBits(new int[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 });//[1,2,4,8,16,32,64,128,256,512,1024]
      var res3 = program.SortByBits(new int[] { 10000, 10000 });//[10000,10000]
      var res4 = program.SortByBits(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });//2,3,5,17,7,11,13,19
      var res5 = program.SortByBits(new int[] { 10, 100, 1000, 10000 });//10,100,10000,1000
      Console.WriteLine("Hello World!");
    }
    public int[] SortByBits(int[] arr)
    {
      return arr.Select(x =>
     {
       int wkX = x;
       int cnt = 0;
       while (wkX != 0)
       {
         if ((wkX & 1) == 1)
           cnt++;
         wkX >>= 1;
       }
       return new { cnt, x };
     }).OrderBy(x => x.cnt).ThenBy(x => x.x).Select(x => x.x).ToArray();
    }
  }
}
