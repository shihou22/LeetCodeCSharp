using System.Xml.Linq;
using System.Linq;
using System;

namespace Reduce_Array_Size_to_The_Half
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //2
      Console.WriteLine(program.MinSetSize(new int[] { 3, 3, 3, 3, 5, 5, 5, 2, 2, 7 }));
      //   1
      Console.WriteLine(program.MinSetSize(new int[] { 7, 7, 7, 7, 7, 7 }));
      //   1
      Console.WriteLine(program.MinSetSize(new int[] { 1, 9 }));
      //   1
      Console.WriteLine(program.MinSetSize(new int[] { 1000, 1000, 3, 7 }));
      //5
      Console.WriteLine(program.MinSetSize(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
      Console.WriteLine("Hello World!");
    }
    public int MinSetSize(int[] arr)
    {
      int n = (arr.Length + 1) / 2;

      //   var res = arr.Select((x, i) => new { x, i }).GroupBy(x => x.x, x => x.i).OrderByDescending(x => x.Count()).Select((x, i) => new { i, x });

      //   foreach (var item in res)
      //   {
      //     n -= item.x.Count();
      //     if (n <= 0)
      //       return item.i + 1;
      //   }

      var wk = arr.GroupBy(x => x).Select(x => (Number: x.Key, Count: x.Count())).OrderByDescending(x => x.Count).ToList();

      int cnt = 0;
      foreach (var item in wk)
      {
        cnt++;
        n -= item.Count;
        if (n <= 0)
          return cnt;
      }
      return arr.Length;
    }
  }
}
