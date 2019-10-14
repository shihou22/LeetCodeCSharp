using System;

namespace Maximum_Average_Subarray_I
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //12.75
      //   Console.WriteLine(program.FindMaxAverage(new int[] { 1, 12, -5, -6, 50, 3 }, 4));
      //5
      //   Console.WriteLine(program.FindMaxAverage(new int[] { 5 }, 1));
      //-594.58065
      Console.WriteLine(program.FindMaxAverage(new int[] { 8860, -853, 6534, 4477, -4589, 8646, -6155, -5577, -1656, -5779, -2619, -8604, -1358, -8009, 4983, 7063, 3104, -1560, 4080, 2763, 5616, -2375, 2848, 1394, -7173, -5225, -8244, -809, 8025, -4072, -4391, -9579, 1407, 6700, 2421, -6685, 5481, -1732, -8892, -6645, 3077, 3287, -4149, 8701, -4393, -9070, -1777, 2237, -3253, -506, -4931, -7366, -8132, 5406, -6300, -275, -1908, 67, 3569, 1433, -7262, -437, 8303, 4498, -379, 3054, -6285, 4203, 6908, 4433, 3077, 2288, 9733, -8067, 3007, 9725, 9669, 1362, -2561, -4225, 5442, -9006, -429, 160, -9234, -4444, 3586, -5711, -9506, -79, -4418, -4348, -5891 }, 93));
      Console.WriteLine("Hello World!");
    }
    public double FindMaxAverage(int[] nums, int k)
    {
      if (nums.Length == 0)
        return 0;
      if (nums.Length == 1)
        return nums[0];
      int left = 0;
      int right = 1;
      double res = int.MinValue;
      double sum = nums[0];
      int n = nums.Length;
      while (right < n)
      {
        while (right < n && right - left < k)
        {
          sum += nums[right];
          right++;
        }
        res = Math.Max(res, sum / (double)k);
        sum -= nums[left];
        left++;
      }
      return res;
    }
  }
}
