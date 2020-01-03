using System.Collections.Generic;
using System;

namespace Subarray_Sum_Equals_K
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //2
      Console.WriteLine(program.SubarraySum(new int[] { 1, 1, 1 }, 2));
      //2
      Console.WriteLine(program.SubarraySum(new int[] { 1, 2, 3 }, 3));
      Console.WriteLine("Hello World!");
    }
    public int SubarraySum(int[] nums, int k)
    {

      int res = 0;
      int sum = 0;
      Dictionary<int, int> exist = new Dictionary<int, int>();
      //自分のみのパターン
      exist.Add(0, 1);
      /*nums[i]     0   1   2   3   4   5   6   7   8
      *             0   1   2   3   4   5   6
      *             0
      *             6 - 0 を行えば、1 -6の累積和になる
      *             6迄累積和を全て確保しておいて、tmpの値が今までに出現したかを観てみる
      */
      foreach (var item in nums)
      {
        //現在の総合計（累積）
        sum += item;
        //過去の累積にtmpが出てきたことがあるのかチェック
        int tmp = sum - k;
        if (exist.ContainsKey(tmp))
        {
          //既に出現している=出現回数をそのまま答えに足せる
          res += exist[tmp];
        }
        exist.TryAdd(sum, 0);
        exist[sum]++;
      }
      return res;
    }
    public int SubarraySumNotMinus(int[] nums, int k)
    {
      int left = 0;
      int right = 0;
      int total = 0;
      int res = 0;
      total += nums[left];
      int max = nums.Length;

      while (left < max)
      {
        while (total < k && right + 1 < max)
        {
          right++;
          total += nums[right];
        }
        if (total == k)
          res++;

        total -= nums[left];
        left++;
      }
      return res;
    }
  }
}
