using System;

namespace Find_Peak_Element
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int FindPeakElement(int[] nums)
    {
      int peak = nums[0];
      int cnt = 0;
      for (int i = 0; i < nums.Length; i++)
      {
        cnt = i;
        if (peak > nums[i])
          return i - 1;

        if (peak < nums[i])
        {
          peak = nums[i];
        }
      }
      return cnt;
    }
  }
}
