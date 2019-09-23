using System;

namespace Distance_Between_Bus_Stops
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.DistanceBetweenBusStops(new int[] { 1, 2, 3, 4 }, 0, 1));//1
      Console.WriteLine(program.DistanceBetweenBusStops(new int[] { 1, 2, 3, 4 }, 0, 2));//3
      Console.WriteLine(program.DistanceBetweenBusStops(new int[] { 1, 2, 3, 4 }, 0, 3));//4
      Console.WriteLine("Hello World!");
    }
    public int DistanceBetweenBusStops(int[] distance, int start, int destination)
    {
      int n = distance.Length;
      int min = Math.Min(start, destination);
      int max = Math.Max(start, destination);
      int val1 = 0;
      int val2 = 0;
      for (int i = 0; i < n; i++)
      {
        if (min <= i && i < max)
          val1 += distance[i];
        else
          val2 += distance[i];
      }
      return Math.Min(val1, val2);
    }
  }
}
