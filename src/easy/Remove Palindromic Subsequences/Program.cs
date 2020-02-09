using System;

namespace Remove_Palindromic_Subsequences
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      //1
      Console.WriteLine(program.RemovePalindromeSub("ababa"));
      //2
      Console.WriteLine(program.RemovePalindromeSub("abb"));
      //2
      Console.WriteLine(program.RemovePalindromeSub("baabb"));
      //0
      Console.WriteLine(program.RemovePalindromeSub(""));
      Console.WriteLine("Hello World!");
    }
    /*
    Input: s = "baabb"
    Output: 2
    Explanation: "baabb" -> "b" -> "".
    0,1,2,4(b,a,a,b)で3を取得しなくてよい？
    これって、途中を超えて値をとれるなら必ず0,1,2のどれかになるのでは？
    Sampleをよく読む
    */
    public int RemovePalindromeSub(string s)
    {
      int n = s.Length;
      if (n == 0)
        return 0;
      if (IsPalindrome(s))
        return 1;
      else
        return 2;

    }
    private bool IsPalindrome(string s)
    {
      int left = 0;
      int right = s.Length - 1;
      while (left < right)
      {
        if (s[left] != s[right])
          return false;
        left++;
        right--;
      }
      return true;
    }
  }
}
