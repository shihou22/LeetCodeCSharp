using System.Collections.Generic;
using System;

namespace Pancake_Sorting
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      var res1 = solution.PancakeSort(new int[] { 3, 2, 4, 1 });//4,2,4,3
      var res2 = solution.PancakeSort(new int[] { 1, 2, 3 });//
      Console.WriteLine("Hello World!");
    }
    /*
    Steps to solve this problem:
    Initially unsortedIndex = A.length - 1
    1. Find the max from 0 to unsortedIndex. Say ith index
    2. Reverse the elements from 0 to i. - Now max element from 0 - unsortedIndex is at A[0]
    3. Reverse the elements from 0 to unsortedIndex, unsortedIndex--.  - Now max element is at A[unsortedIndex]
    By these two reverse, we placed the largest element in the end of the array that hasn't been sorted yet.
    4. Repeat 1-3

    Input: [3,2,4,1]
    4,2,3,1
    1,3,2,4
    3,1,2,4
    2,1,3,4
    2,1,3,4
    1,2,3,4

    [5,2,1,4,3]
    5,2,1,4,3
    3,4,1,2,5
    4,3,1,2,5
    2,1,3,4,5
    3,1,2,4,5
    2,1,3,4,5
    2,1,3,4,5
    1,2,3,4,5
    Output: [4,2,4,3]

    パンケーキソート(Pancake sorting)
     */
    public IList<int> PancakeSort(int[] A)
    {
      IList<int> res = new List<int>();
      for (int i = A.Length - 1; i > 0; i--)
      {
        int maxIndex = FindMaxIndex(A, i);
        Flip(A, 0, maxIndex);
        Flip(A, 0, i);
        res.Add(maxIndex + 1);
        res.Add(i + 1);
      }
      return res;
    }
    private void Flip(int[] A, int start, int end)
    {
      while (start < end)
      {
        var tmp = A[start];
        A[start] = A[end];
        A[end] = tmp;
        start++;
        end--;
      }
    }

    /*
    範囲内最大値
    閉区間で扱う
     */
    private int FindMaxIndex(int[] A, int end)
    {
      int max = 0;
      int maxI = 0;
      for (int i = 0; i <= end; i++)
      {
        if (max < A[i])
        {
          max = A[i];
          maxI = i;
        }
      }
      return maxI;
    }
  }
}
