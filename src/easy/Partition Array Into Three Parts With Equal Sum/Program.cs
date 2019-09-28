using System;

namespace Partition_Array_Into_Three_Parts_With_Equal_Sum
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //true
      Console.WriteLine(program.CanThreePartsEqualSum(new int[] { 0, 2, 1, -6, 6, -7, 9, 1, 2, 0, 1 }));
      //false
      Console.WriteLine(program.CanThreePartsEqualSum(new int[] { 0, 2, 1, -6, 6, 7, 9, -1, 2, 0, 1 }));
      //true
      Console.WriteLine(program.CanThreePartsEqualSum(new int[] { 0, 2, 1, -6, 6, -7, 9, 1, 2, 0, 1 }));
      //true
      Console.WriteLine(program.CanThreePartsEqualSum(new int[] { 3, 3, 6, 5, -2, 2, 5, 1, -9, 4 }));
      Console.WriteLine("Hello World!");
    }

    public bool CanThreePartsEqualSum(int[] A)
    {
      int[] fwd = new int[A.Length];
      fwd[0] = A[0];
      int[] bwd = new int[A.Length];
      bwd[A.Length - 1] = A[A.Length - 1];
      for (int i = 1; i < A.Length; i++)
      {
        fwd[i] = fwd[i - 1] + A[i];
        bwd[A.Length - 1 - i] = bwd[A.Length - 1 - i + 1] + A[A.Length - 1 - i];
      }
      //3で割り切れない場合、3等分はできない
      if (bwd[0] % 3 != 0)
        return false;
      // 1/3になる合計値を探す
      int target = bwd[0] / 3;
      for (int i = 0; i < A.Length - 2; i++)
      {
        // 1/3にならないなら残り二つを探す意味はない（TLE対策）
        if (fwd[i] != target)
          continue;
        for (int j = i + 1; j < A.Length - 1; j++)
        {
          if (fwd[i] == (bwd[i + 1] - bwd[j + 1]) && fwd[i] == bwd[j + 1])
            return true;
        }

      }
      return false;
    }
  }
}
