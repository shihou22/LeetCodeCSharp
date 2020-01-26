using System;

namespace Product_of_Array_Except_Self
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.ProductExceptSelf(new int[] { 4, 5, 1, 8, 2 }));
      Console.WriteLine("Hello World!");
    }
    /*
    4   5   1   8   2
    1   4   20  20  160
    80  16  16  2   1
    [4]は[0]-[3]を全てかけたものが対になる
    [0]は[4]-[1]を全てかけたものが対になる
    */
    public int[] ProductExceptSelf(int[] nums)
    {
      int[] left = new int[nums.Length];
      int[] right = new int[nums.Length];
      for (int i = 0; i < nums.Length; i++)
      {
        if (i == 0)
        {
          left[0] = 1;
          right[nums.Length - 1] = 1;
        }
        else
        {
          left[i] = nums[i - 1] * left[i - 1];
          right[nums.Length - 1 - i] = nums[nums.Length - 1 - i + 1] * right[nums.Length - 1 - i + 1];
        }
      }
      for (int i = 0; i < nums.Length; i++)
      {
        left[i] = left[i] * right[i];
      }
      return left;
    }
  }
}
