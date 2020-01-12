using System.Linq;
using System;
using System.Collections.Generic;

namespace XOR_Queries_of_a_Subarray
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      int[][] queries = new int[4][];
      queries[0] = new int[] { 0, 1 };
      queries[1] = new int[] { 1, 2 };
      queries[2] = new int[] { 0, 3 };
      queries[3] = new int[] { 3, 3 };
      var res = program.XorQueries(new int[] { 1, 3, 4, 8 }, queries);
      Console.WriteLine("Hello World!");
    }
    public int[] XorQueries(int[] arr, int[][] queries)
    {
      int[] res = new int[arr.Length];
      for (int i = 0; i < arr.Length; i++)
      {
        if (i == 0)
        {
          res[0] = arr[0];
        }
        else
        {
          res[i] = arr[i] ^ res[i - 1];
        }
      }

      IList<int> listRes = new List<int>();
      for (int i = 0; i < queries.Length; i++)
      {
        int[] wk = queries[i];
        int start = wk[0];
        int end = wk[1];
        if (start == 0)
          listRes.Add(res[end]);
        else
          listRes.Add(res[start - 1] ^ res[end]);
      }
      return listRes.ToArray();
    }
    public int[] XorQueriesTLE(int[] arr, int[][] queries)
    {
      IList<int> res = new List<int>();

      for (int i = 0; i < queries.Length; i++)
      {
        int[] wk = queries[i];
        int start = wk[0];
        int end = wk[1];
        int tmp = 0;
        for (int j = start; j <= end; j++)
        {
          if (j == start)
            tmp = arr[j];
          else
            tmp ^= arr[j];
        }
        res.Add(tmp);
      }

      return res.ToArray();
    }
  }
}
