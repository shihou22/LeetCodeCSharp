using System;

namespace Moving_Stones_Until_Consecutive
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int[] NumMovesStones(int a, int b, int c)
    {
      int[] wk = new int[3];
      wk[0] = a;
      wk[1] = b;
      wk[2] = c;
      Array.Sort(wk);
      int front = wk[1] - wk[0];
      int back = wk[2] - wk[1];
      if (front == 1 && back == 1)
        return new int[] { 0, 0 };
      int min = Math.Min(front, back) - 1 == 0 ? 1 : Math.Min(front, back) - 1 > 2 ? 2 : Math.Min(front, back) - 1;
      int max = Math.Min(front, back) - 1 + Math.Max(front, back) - 1;
      return new int[] { min, max };
    }
  }
}
