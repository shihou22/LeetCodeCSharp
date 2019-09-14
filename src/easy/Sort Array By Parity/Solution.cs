using System;

namespace Sort_Array_By_Parity
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      int[] A = null;
      A = new int[] { 3, 1, 2, 4 };
      Console.WriteLine(solution.SortArrayByParity(A));
      A = new int[] { 0, 2 };
      Console.WriteLine(solution.SortArrayByParity(A));
      A = new int[] { 0, 1 };
      Console.WriteLine(solution.SortArrayByParity(A));
      A = new int[] { 1, 0 };
      Console.WriteLine(solution.SortArrayByParity(A));
      Console.WriteLine("Hello World!");
    }
    public int[] SortArrayByParity(int[] A)
    {
      int left = 0;
      int right = A.Length - 1;
      while (left < right)
      {
        while (left < A.Length - 1 && A[left] % 2 == 0)
          left++;
        while (right > 0 && A[right] % 2 != 0)
          right--;
        if (left < right)
          swap(A, left, right);
        left++;
        right--;
      }
      return A;
    }
    private void swap(int[] A, int left, int right)
    {
      int tmp = A[left];
      A[left] = A[right];
      A[right] = tmp;
    }
  }
}
