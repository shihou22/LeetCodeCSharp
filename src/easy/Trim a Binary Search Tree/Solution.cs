using System;

namespace Trim_a_Binary_Search_Tree
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
      Console.WriteLine("Hello World!");
    }
    /*
    Treeはleftはrootより小さく、rightはrootより大きい
     */
    public TreeNode TrimBST(TreeNode root, int L, int R)
    {
      if (root == null)
        return null;
      if (root.val < L)
        return TrimBST(root.right, L, R);
      if (root.val > R)
        return TrimBST(root.left, L, R);
      root.left = TrimBST(root.left, L, R);
      root.right = TrimBST(root.right, L, R);
      return root;
    }

  }
}
