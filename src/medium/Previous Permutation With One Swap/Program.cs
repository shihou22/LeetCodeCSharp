using System;

namespace Previous_Permutation_With_One_Swap
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
    //   var res1 = program.PrevPermOpt1(new int[] { 3, 2, 1 });//3,1,2
    //   var res2 = program.PrevPermOpt1(new int[] { 1, 1, 5 });//1,1,5
    //   var res3 = program.PrevPermOpt1(new int[] { 1, 9, 4, 6, 7 });//1,7,4,6,9
    //   var res4 = program.PrevPermOpt1(new int[] { 3, 1, 1, 3 });//1,3,1,3
      var res5 = program.PrevPermOpt1(new int[] { 3, 1, 1, 3 });//1,3,1,3
      Console.WriteLine("Hello World!");
    }
    public int[] PrevPermOpt1(int[] A)
    {
      if (A.Length == 0)
        return A;

      int index = GetDownIndex(A);
      if (index == -1)
        return A;

      int maxIdx = 0;
      int maxNum = 0;
      for (int i = A.Length - 1; i > index; i--)
      {
        if (maxNum <= A[i] && A[i] < A[index])
        {
          maxNum = A[i];
          maxIdx = i;
        }
      }
      Swap(A, index, maxIdx);
      return A;
    }
    private void Swap(int[] A, int i, int j)
    {
      int temp = A[i];
      A[i] = A[j];
      A[j] = temp;
    }
    private int GetDownIndex(int[] A)
    {
      for (int i = A.Length - 1; i > 0; i--)
      {
        if (A[i - 1] > A[i])
          return i - 1;
      }
      return -1;
    }
  }
}
