using System.Collections.Generic;
using System;

namespace Second_Minimum_Node_In_a_Binary_Tree
{
  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    public int FindSecondMinimumValue(TreeNode root)
    {
      SortedDictionary<int, int> memo = new SortedDictionary<int, int>();
      Queue<TreeNode> que = new Queue<TreeNode>();
      que.Enqueue(root);
      while (que.Count > 0)
      {
        var wk = que.Dequeue();
        if (wk == null)
          continue;
        memo.TryAdd(wk.val, 0);
        memo[wk.val]++;
        que.Enqueue(wk.left);
        que.Enqueue(wk.right);
      }
      int cnt = 1;
      foreach (var item in memo)
      {
        if (cnt == 2)
          return item.Key;
        cnt++;
      }
      return -1;
    }
  }
}
