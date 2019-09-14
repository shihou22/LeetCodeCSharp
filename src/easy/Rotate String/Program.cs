using System;

namespace Rotate_String
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.RotateString("abcde", "cdeab"));//true
      Console.WriteLine(program.RotateString("abcde", "abced"));//false
      Console.WriteLine(program.RotateString("", ""));//true
      Console.WriteLine("Hello World!");
    }
    public bool RotateString(string A, string B)
    {
      if (A.Length != B.Length)
        return false;
      if (A.Length == 0)
        return true;

      return (A.Length == B.Length) && (B + B).IndexOf(A) > 0;
    }
  }
}
