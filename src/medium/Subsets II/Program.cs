using System;
using System.Collections.Generic;

namespace Subsets_II
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      // var rse1 = program.SubsetsWithDup(new int[] { 1, 2, 2 });
      var rse1 = program.SubsetsWithDup(new int[] { 1, 2, 3, 4 });
      Console.WriteLine("Hello World!");
    }
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
      IList<IList<int>> res = new List<IList<int>>();
      Array.Sort(nums);
      DFS(nums, 0, new List<int>(), res);
      return res;
    }
    private void DFS(int[] nums, int start, IList<int> currList, IList<IList<int>> res)
    {
      res.Add(new List<int>(currList));
      //1個ずつ進めている
      for (int i = start; i < nums.Length; i++)
      {
        //先頭が1,2,3という形を作る。（同じ値の開始位置は不要）
        if (i > start && nums[i] == nums[i - 1])
          continue;
        currList.Add(nums[i]);
        DFS(nums, i + 1, currList, res);
        currList.RemoveAt(currList.Count - 1);
      }
    }
  }
}
