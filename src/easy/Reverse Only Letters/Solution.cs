using System.Collections.Generic;
using System;

namespace Reverse_Only_Letters
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.ReverseOnlyLetters("ab-cd"));//"dc-ba"
      Console.WriteLine(solution.ReverseOnlyLetters("a-bC-dEf-ghIj"));//"j-Ih-gfE-dCba"
      Console.WriteLine(solution.ReverseOnlyLetters("Test1ng-Leet=code-Q!"));//"Qedo1ct-eeLg=ntse-T!"
      Console.WriteLine("Hello World!");
    }
    public string ReverseOnlyLetters(string S)
    {
      HashSet<char> vals = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

      int size = S.Length;
      int left = 0;
      int right = S.Length - 1;
      char[] res = S.ToCharArray();
      while (left < right)
      {
        while (left < size && !vals.Contains(S[left]))
          left++;
        while (right >= 0 && !vals.Contains(S[right]))
          right--;

        if (left < right)
        {
          char wk = res[left];
          res[left] = res[right];
          res[right] = wk;
          left++;
          right--;
        }
      }
      return new string(res);
    }
  }
}
