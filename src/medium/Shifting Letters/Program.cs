using System;
using System.Linq;

namespace Shifting_Letters
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.ShiftingLetters("abc", new int[] { 3, 5, 9 }));
      Console.WriteLine(program.ShiftingLetters("abc", new int[] { 3, 5, 9 }));
      Console.WriteLine("Hello World!");
    }
    public string ShiftingLetters(string S, int[] shifts)
    {
      for (int i = shifts.Length - 2; i >= 0; i--)
        shifts[i] = (shifts[i] + shifts[i + 1]) % 26;

      return new string(S.Zip(shifts, (c, shift) => (char)((c - 'a' + shift) % 26 + 'a')).ToArray());
    }
    public string ShiftingLettersLong(string S, int[] shifts)
    {
      long[] rui = new long[S.Length];
      for (int i = 0; i < shifts.Length; i++)
      {
        rui[0] += shifts[i] % 26;
        if (i + 1 < S.Length)
          rui[i + 1] -= shifts[i] % 26;
      }
      for (int i = 1; i < rui.Length; i++)
      {
        rui[i] = rui[i] + rui[i - 1];
      }
      char[] resArray = S.ToCharArray();
      for (int i = 0; i < resArray.Length; i++)
      {
        char tmp = resArray[i];
        char res = (char)(((tmp - 'a') + rui[i]) % 26 + 'a');
        resArray[i] = res;
      }
      return new string(resArray);
    }
  }
}
