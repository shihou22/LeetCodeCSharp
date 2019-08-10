using System;

namespace Long_Pressed_Name
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.IsLongPressedName("alex", "aaleex"));//true
      Console.WriteLine(solution.IsLongPressedName("saeed", "ssaaedd"));//false
      Console.WriteLine(solution.IsLongPressedName("leelee", "lleeelee"));//true
      Console.WriteLine(solution.IsLongPressedName("laiden", "laiden"));//true
      Console.WriteLine(solution.IsLongPressedName("pyplrz", "ppyypllr"));//false
      Console.WriteLine("Hello World!");
    }
    public bool IsLongPressedName(string name, string typed)
    {
      if (name.Length > typed.Length)
        return false;

      int nameCnt = 0;
      int typedCnt = 0;
      while (nameCnt < name.Length || typedCnt < typed.Length)
      {
        char nC = ' ';
        if (nameCnt < name.Length)
          nC = name[nameCnt];

        int nCnt = 1;
        while (nameCnt + 1 < name.Length && name[nameCnt] == name[nameCnt + 1])
        {
          nameCnt++;
          nCnt++;
        }

        char tC = ' ';
        if (typedCnt < typed.Length)
          tC = typed[typedCnt];

        int tCnt = 1;
        while (typedCnt + 1 < typed.Length && typed[typedCnt] == typed[typedCnt + 1])
        {
          typedCnt++;
          tCnt++;
        }

        if (nC != tC || nCnt > tCnt)
        {
          return false;
        }
        nameCnt++;
        typedCnt++;
      }
      return true;
    }
  }
}
