using System;
using System.Collections.Generic;

namespace Sort_Colors
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      int[] nums = new int[] { };
      nums = new int[] { 2, 0, 2, 1, 1, 0 };
      solution.SortColorsUse(nums);
      nums = new int[] { 2, 2, 2, 1, 1, 0 };
      solution.SortColorsUse(nums);
      Console.WriteLine("Hello World!");
    }
    public void SortColorsUse(int[] nums)
    {
      for (int i = 0; i < nums.Length; i++)
      {
        /*
        入れ替え用のkey
        swapした際にnums[i]が変化するため、nums[i]を保持しておく
         */
        int key = nums[i];
        /*
        keyをひたすら前に送る
         */
        for (int j = i - 1; j >= 0 && nums[j] > key; j--)
          Swap(nums, j, j + 1);
      }

    }
    /*
    Heap Sort
    ヒープソートの実装
     */
    public void SortColorsUseHeap(int[] nums)
    {
      int n = nums.Length;
      for (int i = n / 2 - 1; i >= 0; i--)
      {
        Heap(nums, i, nums.Length);
      }
      for (int i = n - 1; i > 0; --i)
      {
        Swap(nums, 0, i); // ヒープの最大値を左詰め
        Heap(nums, 0, i); // ヒープサイズは i に
      }
    }
    private void Heap(int[] nums, int i, int n)
    {
      //childの位置
      var childL = i * 2 + 1;
      //childがnをはみ出すならreturn
      if (childL >= n)
        return;
      /*
      左右のchildを比較
      childの内、大きいほうをparentと比較するためにchildLを操作
       */
      if (childL + 1 < n && nums[childL] < nums[childL + 1])
        childL++;
      /*
      parentとchildの比較
      親と子が同じ値or子の方が小さいならreturn
       */
      if (nums[childL] <= nums[i])
        return;
      //親と子が逆転しているのでswap
      Swap(nums, childL, i);
      //逆転があった時は更に子をたどる
      Heap(nums, childL, n);
    }
    private void Swap(int[] nums, int a, int b)
    {
      var tmp = nums[a];
      nums[a] = nums[b];
      nums[b] = tmp;
    }
  }
}
