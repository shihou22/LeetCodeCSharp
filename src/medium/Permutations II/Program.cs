using System.Linq;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Permutations_II
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      var res = program.PermuteUnique(new int[] { 1, 1, 2 });
      Console.WriteLine("Hello World!");
    }
    public IList<IList<int>> PermuteUnique(int[] nums)
    {

      var result = new List<IList<int>>();
      if (nums.Length == 0)
        return result;

      Array.Sort(nums);

      dfs(nums, new bool[nums.Length], new List<int>(), result);

      return result;
    }

    private void dfs(int[] nums, bool[] visited, IList<int> list, IList<IList<int>> result)
    {

      if (list.Count >= nums.Length)
      {
        result.Add(new List<int>(list));
        return;
      }

      for (int i = 0; i < nums.Length; i++)
      {
        if (visited[i])
          continue;
        /*
        ソートしておくことで、後ろから見ることが可能になる
        1個前が既に使われている場合は飛ばしてしまう
        これにより、最後の判定までたどり着かない
        後ろから順に使うことになるので、1度しか使えなくなる
        */
        if (i > 0 && nums[i - 1] == nums[i] && visited[i - 1])
          continue;

        list.Add(nums[i]);
        visited[i] = true;
        dfs(nums, visited, list, result);
        visited[i] = false;
        list.RemoveAt(list.Count - 1);
      }
    }
    public IList<IList<int>> PermuteUniqueHelper(int[] nums)
    {
      IList<IList<int>> res = new List<IList<int>>();
      helper(nums, new bool[nums.Length], 0, new List<int>(), res, new HashSet<string>());
      return res;
    }
    private void helper(int[] nums, bool[] visited, int curr, IList<int> list, IList<IList<int>> res, HashSet<string> memo)
    {
      if (curr >= nums.Length)
      {
        var tmp = string.Join("-", list);
        if (!memo.Contains(tmp))
        {
          memo.Add(tmp);
          res.Add(new List<int>(list));
        }
        return;
      }
      for (int i = 0; i < nums.Length; i++)
      {
        if (visited[i])
          continue;
        visited[i] = true;
        list.Add(nums[i]);
        helper(nums, visited, curr + 1, list, res, memo);
        list.RemoveAt(list.Count - 1);
        visited[i] = false;
      }
    }
  }
}
