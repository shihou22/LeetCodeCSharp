using System.Collections.Generic;
using System;

namespace Binary_Tree_Level_Order_Traversal
{
  class Solution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }

    public IList<IList<int>> LevelOrder(TreeNode root)
    {
      var res = new List<IList<int>>();
      Queue<TreeNode> queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      while (queue.Count > 0)
      {
        var tmpRes = new List<int>();
        var max = queue.Count;
        for (int i = 0; i < max; i++)
        {
          var tmp = queue.Dequeue();
          if (tmp == null)
            continue;

          tmpRes.Add(tmp.val);
          queue.Enqueue(tmp.left);
          queue.Enqueue(tmp.right);
        }
        if (tmpRes.Count > 0)
          res.Add(tmpRes);
      }
      return res;
    }

    public IList<IList<int>> LevelOrderRecursive(TreeNode root)
    {
      return recursive(root, new List<IList<int>>(), 1);
    }

    public IList<IList<int>> recursive(TreeNode root, IList<IList<int>> res, int depth)
    {
      if (root == null)
        return res;

      if (depth > res.Count)
        res.Add(new List<int>());

      var tmp = res[depth - 1];

      tmp.Add(root.val);

      recursive(root.left, res, depth + 1);
      recursive(root.right, res, depth + 1);
      return res;
    }
  }
  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
  }
}
