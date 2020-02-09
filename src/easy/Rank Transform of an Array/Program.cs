using System.Linq;
using System;
using System.Collections.Generic;

namespace Rank_Transform_of_an_Array
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //[4,1,2,3]
      var res1 = program.ArrayRankTransform(new int[] { 40, 10, 20, 30 });
      //[1,1,1]
      var res2 = program.ArrayRankTransform(new int[] { 100, 100, 100 });
      //[5,3,4,2,8,6,7,1,3]
      var res3 = program.ArrayRankTransform(new int[] { 37, 12, 28, 9, 100, 56, 80, 5, 12 });
      Console.WriteLine("Hello World!");
    }
    public int[] ArrayRankTransform(int[] arr)
    {
      var wk = arr.OrderBy(x => x).ToHashSet().ToList();
      return arr.Select(i => wk.BinarySearch(i) + 1).ToArray();
    }
  }
}
