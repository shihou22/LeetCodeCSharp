using System;

namespace Find_Minimum_in_Rotated_Sorted_Array
{
  class Solution
  {
    static void Main(string[] args)
    {
      var res = 0;
      Solution solution = new Solution();
      //   res = solution.FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 });
      //   Console.WriteLine(res);//0
      //   res = solution.FindMin(new int[] { 3, 4, 5, 1, 2 });
      //   Console.WriteLine(res);//1
      res = solution.FindMin(new int[] { 2, 1 });
      Console.WriteLine(res);//1
      res = solution.FindMin(new int[] { 1, 2 });
      Console.WriteLine(res);//1
      Console.WriteLine("Hello World!");
    }

    /*
    binary search
     */
    public int FindMin(int[] nums)
    {
      var left = 0;
      var right = nums.Length - 1;
      while (left < right)
      {
        var mid = left + (right - left) / 2;
        if (nums[mid] > nums[right])
          left = mid + 1;
        else
          right = mid;
      }
      return nums[left];
    }

    /*
    Loop
     */
    public int FindMinLoop(int[] nums)
    {
      var min = nums[0];
      for (int i = 0; i < nums.Length - 1; i++)
      {
        if (nums[i] > nums[i + 1])
        {
          min = nums[i + 1];
          break;
        }
      }
      return min;
    }
  }
}
