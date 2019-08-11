using System;

namespace Range_Sum_Query___Mutable
{
  class NumArray
  {
    static void Main(string[] args)
    {
      // NumArray array = new NumArray(new int[] { 9, -8 });
      // array.Update(0, 3);
      // Console.WriteLine(array.SumRange(1, 1));//-8
      // Console.WriteLine(array.SumRange(0, 1));//-5
      // array.Update(1, -3);
      // Console.WriteLine(array.SumRange(0, 1));//0
      NumArray array = new NumArray(new int[] { 1, 3, 5 });
      Console.WriteLine(array.SumRange(0, 2));//-8
      array.Update(1, 2);
      Console.WriteLine(array.SumRange(0, 2));//-5
      Console.WriteLine("Hello World!");
    }
    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * obj.Update(i,val);
     * int param_2 = obj.SumRange(i,j);
     */

    /*
    セグメントツリー segment tree ヴァージョン
     */
    public NumArray(int[] nums)
    {
      this.nums = nums;
      // this.n = this.nums.Length;

      int sz = nums.Length;
      this.n = 1;
      while (n < sz)
        n *= 2;
      this.segment = new int[n * 2 - 1];

      for (int i = 0; i < nums.Length; i++)
        segment[i + n - 1] = nums[i];

      for (int i = n - 2; i >= 0; i--)
        segment[i] = segment[i * 2 + 1] + segment[i * 2 + 2];
    }

    int n = 0;
    int[] nums;
    int[] segment;
    public void Update(int i, int val)
    {
      int baseNum = i + n - 1;
      segment[baseNum] = val;
      while (baseNum > 0)
      {
        baseNum = (baseNum - 1) / 2;
        segment[baseNum] = segment[2 * baseNum + 1] + segment[2 * baseNum + 2];
      }

    }

    public int SumRange(int i, int j)
    {
      return Sum(i, j + 1, 0, 0, -1);
    }
    private int Sum(int a, int b, int k, int l, int r)
    {
      if (r < 0)
        r = n;
      if (r <= a || b <= l)
        return 0;
      if (a <= l && r <= b)
        return segment[k];

      int val1 = Sum(a, b, 2 * k + 1, l, (l + r) / 2);
      int val2 = Sum(a, b, 2 * k + 2, (l + r) / 2, r);
      return val1 + val2;
    }
    /*
    Slow-version
     */

    // private int[] nums;
    // private int[] rui;
    // public NumArray(int[] nums)
    // {
    //   if (nums == null || nums.Length == 0)
    //     return;
    //   this.nums = nums;
    //   rui = new int[nums.Length];
    //   rui[0] = nums[0];
    //   for (int i = 1; i < nums.Length; i++)
    //   {
    //     rui[i] = rui[i - 1] + nums[i];
    //   }
    // }

    // public void Update(int i, int val)
    // {
    //   if (nums == null || nums.Length == 0)
    //     return;
    //   int diff = (nums[i] - val);
    //   nums[i] = val;
    //   for (int j = i; j < nums.Length; j++)
    //   {
    //     rui[j] -= diff;
    //   }
    // }

    // public int SumRange(int i, int j)
    // {
    //   if (nums == null || nums.Length == 0)
    //     return 0;
    //   if (i > 0)
    //     return rui[j] - rui[i - 1];
    //   else
    //     return rui[j];
    // }
  }
}
