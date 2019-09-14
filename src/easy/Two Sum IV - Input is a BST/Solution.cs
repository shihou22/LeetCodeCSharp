using System.Linq;
using System.Collections.Generic;
using System;

namespace Two_Sum_IV___Input_is_a_BST
{
  class Solution
  {
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      //   TreeNode root = new TreeNode(1);
      //   Console.WriteLine(solution.FindTarget(root, 2));
      TreeNode root = new TreeNode(5);
      root.left = new TreeNode(3);
      root.right = new TreeNode(6);
      root.left.left = new TreeNode(2);
      root.left.right = new TreeNode(4);
      root.right.right = new TreeNode(7);
      Console.WriteLine(solution.FindTarget(root, 9));
      Console.WriteLine("Hello World!");
    }
    public bool FindTarget(TreeNode root, int k)
    {
      if (root == null)
        return false;
      Queue<TreeNode> que = new Queue<TreeNode>();
      Dictionary<int, int> memo = new Dictionary<int, int>();
      que.Enqueue(root);
      while (que.Count > 0)
      {
        TreeNode node = que.Dequeue();
        if (node == null)
          continue;
        if (memo.ContainsKey(node.val))
          memo[node.val]++;
        else
          memo.Add(node.val, 1);
        que.Enqueue(node.left);
        que.Enqueue(node.right);
      }
      foreach (var item in memo.Keys)
      {
        var wk = k - item;
        if (!memo.ContainsKey(wk))
          continue;
        if (wk == item && memo[wk] > 1)
          return true;
        if (wk != item && memo[wk] > 0)
          return true;
      }
      return false;
    }
  }
}
