using System.Linq;
using System.Collections.Generic;
using System;

namespace Bulls_and_Cows
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      //   Console.WriteLine(solution.GetHint("1807", "7810"));//1A3B
      //   Console.WriteLine(solution.GetHint("1123", "0111"));//1A1B
      Console.WriteLine(solution.GetHint("1122", "2211"));//0A4B
      Console.WriteLine("Hello World!");
    }
    public string GetHint(string secret, string guess)
    {
      int bulls = 0;
      int cows = 0;
      HashSet<int> secMemo = new HashSet<int>();
      Dictionary<int, int> gueMemo = new Dictionary<int, int>();
      for (int i = 0; i < secret.Length; i++)
      {
        if (gueMemo.ContainsKey(guess[i] - '0'))
          gueMemo[guess[i] - '0']++;
        else
          gueMemo.Add(guess[i] - '0', 1);

        if (secret[i] == guess[i])
        {
          secMemo.Add(i);
          gueMemo[guess[i] - '0']--;
          bulls++;
        }
      }
      for (int i = 0; i < secret.Length; i++)
      {
        if (secMemo.Contains(i))
          continue;
        if (gueMemo.ContainsKey(secret[i] - '0') && gueMemo[secret[i] - '0'] > 0)
        {
          cows++;
          gueMemo[secret[i] - '0']--;
        }
      }

      return bulls + "A" + cows + "B";
    }
  }
}
