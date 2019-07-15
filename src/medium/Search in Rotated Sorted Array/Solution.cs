using System;

namespace Search_in_Rotated_Sorted_Array
{
  class Solution
  {
    static void Main(string[] args)
    {
      var res = 0;
      Solution solution = new Solution();
      //   res = solution.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
      //   Console.WriteLine(res);//4
      //   res = solution.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3);
      //   Console.WriteLine(res);//-1
      //   res = solution.Search(new int[] { }, 5);
      //   Console.WriteLine(res);//-1
      //   res = solution.Search(new int[] { 1 }, 5);
      //   Console.WriteLine(res);//-1
      //   res = solution.Search(new int[] { 5 }, 5);
      //   Console.WriteLine(res);//0
      // res = solution.Search(new int[] { 1, 3, 5 }, 5);
      // Console.WriteLine(res);//2
      //   res = solution.Search(new int[] { 1, 2, 3, 4, 5 }, 1);
      //   Console.WriteLine(res);//0
      res = solution.Search(new int[] { 3, 1 }, 1);
      Console.WriteLine(res);//1
                             //   res = solution.Search(new int[] { 1, 3 }, 2);
                             //   Console.WriteLine(res);//-1
      Console.WriteLine("Hello World!");
    }

    public int Search(int[] nums, int target)
    {
      if (nums == null || nums.Length == 0)
      {
        return -1;
      }
      var left = 0;
      var right = nums.Length - 1;
      while (left <= right)
      {
        var mid = left + (right - left) / 2;
        if (nums[mid] == target)
          return mid;
        //midの切り捨てなのでrightではなくleftと等価になる可能性がある
        if (nums[left] <= nums[mid])
        {
          /*
          nums[mid] == targetならreturn済み
          */
          if (nums[left] <= target && target < nums[mid])
            right = mid - 1;
          else
            left = mid + 1;
        }
        else
        {
          /*
          nums[mid] == targetならreturn済み
          */
          if (nums[mid] < target && target <= nums[right])
            left = mid + 1;
          else
            right = mid - 1;
        }

      }
      return -1;
    }
    /*
    use Library
     */
    public int SearchOld(int[] nums, int target)
    {
      var res = Array.IndexOf(nums, target);
      return res;
    }
  }
}
