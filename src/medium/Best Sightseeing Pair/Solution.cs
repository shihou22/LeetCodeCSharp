using System;

namespace Best_Sightseeing_Pair
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.MaxScoreSightseeingPair(new int[] { 8, 1, 5, 2, 6 }));//11
      Console.WriteLine("Hello World!");
    }
    public int MaxScoreSightseeingPair(int[] A)
    {
      int plusMax = 0;
      int res = 0;
      for (int i = 1; i < A.Length; i++)
      {
        plusMax = Math.Max(plusMax, A[i - 1] + (i - 1));
        res = Math.Max(plusMax + (A[i] - i), res);
      }
      return res;
    }
    /*
    累積和
     */
    public int MaxScoreSightseeingPairRui(int[] A)
    {
      int[] forward = new int[A.Length];
      for (int i = 0; i < A.Length; i++)
      {
        if (i == 0)
          forward[i] = A[i] + i;
        else
          forward[i] = Math.Max(A[i] + i, forward[i - 1]);
      }

      int[] backward = new int[A.Length];
      for (int i = A.Length - 1; i >= 0; i--)
      {
        if (i == A.Length - 1)
          backward[i] = A[i] - i;
        else
          backward[i] = Math.Max(A[i] - i, backward[i + 1]);
      }

      int max = 0;
      for (int i = 0; i < A.Length - 1; i++)
        max = Math.Max(forward[i] + backward[i + 1], max);

      return max;
      //   int max = 0;
      //   int j = 0;
      //   for (int i = 0; i < A.Length - 1; i++)
      //   {
      //     max = Math.Max((A[i] + A[j]) + (i - j), max);
      //     if (A[j] + (i - j) <= A[i])
      //       j = i;
      //   }
      //   return max;
    }
    public int MaxScoreSightseeingPairOld(int[] A)
    {
      int max = 0;
      for (int i = 0; i < A.Length - 1; i++)
      {
        for (int j = i + 1; j < A.Length; j++)
        {
          max = Math.Max((A[i] + A[j]) + (i - j), max);
        }
      }
      return max;
    }
  }
}
