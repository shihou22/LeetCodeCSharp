using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Collections.Generic;
using System;

namespace Validate_Binary_Search_Tree
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      bool res = false;

      //[10,5,15,null,null,6,20]
      TreeNode root = new TreeNode(10);
      root.left = new TreeNode(5);
      root.right = new TreeNode(15);
      root.right.left = new TreeNode(6);
      root.right.right = new TreeNode(20);

      //   res = solution.IsValidBST(root);//false
      //   root = new TreeNode(1);
      //   root.left = new TreeNode(1);


      res = solution.IsValidBST(root);//false
      Console.WriteLine("Hello World!");
    }

    public bool IsValidBST(TreeNode root)
    {
      if (root == null) return true;
      List<int> list = new List<int>();
      Traverse(root, list);

      for (int i = 0; i < list.Count - 1; ++i)
      {
        if (list[i] >= list[i + 1])
          return false;
      }

      return true;
    }
    private void Traverse(TreeNode n, List<int> list)
    {
      if (n.left != null) Traverse(n.left, list);
      list.Add(n.val);
      if (n.right != null) Traverse(n.right, list);
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
