using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Flip_String_to_Monotone_Increasing
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //1
      Console.WriteLine(program.MinFlipsMonoIncr("00110"));
      //2
      Console.WriteLine(program.MinFlipsMonoIncr("010110"));
      //2
      Console.WriteLine(program.MinFlipsMonoIncr("00011000"));
      //3
      Console.WriteLine(program.MinFlipsMonoIncr("0101100011"));
      /*
      5
      0 1 2 7 2 1 1 3 1 2
      */
      Console.WriteLine(program.MinFlipsMonoIncr("10011111110010111011"));
      Console.WriteLine("Hello World!");

    }
    public int MinFlipsMonoIncr(string S)
    {
      /*
      全てを1にした状態から
      全てを0に持っていく
      その都度、各段階でどれくらいFlipするのかを確認していく。
      */
      int tZeroCnt = S.Where(x => x == '0').Count();
      int tOneCnt = S.Length - tZeroCnt;
      int zeroCnt = 0;
      int oneCnt = 0;
      int minFlip = tZeroCnt;
      for (int i = 0; i < S.Length; i++)
      {
        if (S[i] == '0')
          zeroCnt++;
        else
          oneCnt++;
        int curFlip = oneCnt + (tZeroCnt - zeroCnt);
        minFlip = Math.Min(minFlip, curFlip);
      }
      return minFlip;
    }
    public int MinFlipsMonoIncrRui(string S)
    {
      if (S == null || S.Length <= 1)
        return 0;
      IList<int> rui = new List<int>();
      int cnt = 0;
      char prev = S[0];
      if (prev != '0')
        rui.Add(0);
      foreach (var item in S)
      {
        if (item == prev)
          cnt++;
        else
        {
          rui.Add(cnt);
          cnt = 1;
          prev = item;
        }
      }
      if (cnt != 0)
        rui.Add(cnt);
      if (rui.Count % 2 != 0)
        rui.Add(0);
      //全てを1にする累積
      int[] ruiOneF = new int[rui.Count];
      int[] ruiOneB = new int[rui.Count];
      //全てを0にする累積
      int[] ruiZeroF = new int[rui.Count];
      int[] ruiZeroB = new int[rui.Count];
      for (int i = 0; i < rui.Count; i++)
      {
        if (i == 0)
        {
          ruiOneF[i] = rui[i];
          ruiZeroF[i] = 0;
        }
        else
        {
          ruiOneF[i] = ruiOneF[i - 1] + ((i % 2 == 0) ? rui[i] : 0);
          ruiZeroF[i] = ruiZeroF[i - 1] + ((i % 2 != 0) ? rui[i] : 0);
        }
      }
      for (int i = rui.Count - 1; i >= 0; i--)
      {
        if (i == rui.Count - 1)
        {
          ruiOneB[i] = 0;
          ruiZeroB[i] = rui[i];
        }
        else
        {
          ruiOneB[i] = ruiOneB[i + 1] + ((i % 2 == 0) ? rui[i] : 0);
          ruiZeroB[i] = ruiZeroB[i + 1] + ((i % 2 != 0) ? rui[i] : 0);
        }
      }

      /*
      0 0 2 2 4 4 5 5 6 6
      6 6 6 4 4 2 2 1 1 0

      0 1 1 8 8 9 9 121214
      141413136 6 5 5 2 2
      */
      int res = int.MaxValue;
      for (int i = 0; i < rui.Count - 1; i++)
      {
        res = Math.Min(res, ruiZeroF[i] + ruiZeroB[i + 1]);
        res = Math.Min(res, ruiZeroF[i] + ruiOneB[i + 1]);
        res = Math.Min(res, ruiOneF[i] + ruiOneB[i + 1]);
      }
      return res;
    }
  }
}
