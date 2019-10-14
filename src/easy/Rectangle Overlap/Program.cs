using System.Collections.Generic;
using System;

namespace Rectangle_Overlap
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //true
      //   Console.WriteLine(program.IsRectangleOverlap(new int[] { 0, 0, 2, 2 }, new int[] { 1, 1, 3, 3 }));
      //false
      //   Console.WriteLine(program.IsRectangleOverlap(new int[] { 0, 0, 1, 1 }, new int[] { 1, 0, 2, 1 }));
      //true
      //   Console.WriteLine(program.IsRectangleOverlap(new int[] { 7, 8, 13, 15 }, new int[] { 10, 8, 12, 20 }));
      //true
      Console.WriteLine(program.IsRectangleOverlap(new int[] { 2, 17, 6, 20 }, new int[] { 3, 8, 6, 20 }));


      Console.WriteLine("Hello World!");
    }
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
      /*
      かぶっている判定ではなく、かぶっていない判定をして!でひっくり返す
      問題の読み替え
      */
      return !(rec1[2] <= rec2[0] || rec1[3] <= rec2[1]
      || rec1[0] >= rec2[2] || rec1[1] >= rec2[3]);
    }
  }
}
