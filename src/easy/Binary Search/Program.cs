using System;

namespace Binary_Search
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //   Console.WriteLine(program.Search(new int[] { -1, 0, 3, 5, 9, 12 }, 9));//4
      //   Console.WriteLine(program.Search(new int[] { -1, 0, 3, 5, 9, 12 }, 2));//-1
      //   Console.WriteLine(program.Search(new int[] { 5 }, 5));//0
      Console.WriteLine(program.Search(new int[] { -1, 0, 3, 5, 9, 12 }, 2));//-1
      Console.WriteLine("Hello World!");
    }
    public int Search(int[] nums, int target)
    {
      if (nums.Length == 0)
        return -1;
      if (nums.Length == 1 && nums[0] == target)
        return 0;
      int l = 0;
      int r = nums.Length - 1;
      while (l <= r)
      {
        int mid = l + (r - l) / 2;
        if (nums[mid] == target)
        {
          return mid;
        }
        else if (nums[mid] < target)
        {
          l = mid + 1;
        }
        else if (nums[mid] > target)
        {
          r = mid - 1;
        }
      }
      return -1;
    }
  }
}
