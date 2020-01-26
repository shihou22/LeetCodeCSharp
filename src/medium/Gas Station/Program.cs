using System;

namespace Gas_Station
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //   Console.WriteLine(program.CanCompleteCircuit(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }));//3
      //   Console.WriteLine(program.CanCompleteCircuit(new int[] { 2, 3, 4 }, new int[] { 3, 4, 3 }));//-1
      Console.WriteLine(program.CanCompleteCircuit(new int[] { 6, 1, 4, 3, 5 }, new int[] { 3, 8, 2, 4, 2 }));//2
      Console.WriteLine("Hello World!");
    }
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
      int total = 0;
      int index = 0;
      int curr = 0;
      int diff = 0;
      for (int i = 0; i < gas.Length; i++)
      {
        diff = gas[i] - cost[i];
        total += diff;
        curr += diff;
        if (curr < 0)
        {
          curr = 0;
          index = i + 1;
          continue;
        }
      }
      if (total < 0)
        return -1;
      return index;
    }
  }
}
