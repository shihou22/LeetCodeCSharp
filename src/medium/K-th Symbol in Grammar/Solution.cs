using System;

namespace K_th_Symbol_in_Grammar
{
  /*
  平行2分木
           0
      0           1
  0       1   1            0
0   1   1  0 1 0         0    1
https://leetcode.com/problems/k-th-symbol-in-grammar/discuss/311620/Interative-Java-solution
   */
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      var res = 0;
      res = solution.KthGrammar(4, 16);
      Console.WriteLine("Hello World!");
    }
    public int KthGrammar(int N, int K)
    {
      if (N == 1)
        return 0;
      if (N == 2)
      {
        if (K == 1)
          return 0;
        else
          return 1;
      }
      if (K % 2 == 0)
        return 1 - KthGrammar(N - 1, (K + 1) / 2);
      else
        return KthGrammar(N - 1, (K + 1) / 2);

      //   if (N == 1) return 0;
      //   if (KthGrammar(N - 1, (K + 1) / 2) == 0)
      //     return K % 2 == 0 ? 1 : 0;
      //   else
      //     return K % 2 == 0 ? 0 : 1;
    }
  }
}
