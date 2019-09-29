using System;

namespace Longest_Univalue_Path
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
    public int LongestUnivaluePath(TreeNode root)
    {
      DFS(root);
      return res;
    }
    int res = 0;
    private int DFS(TreeNode root)
    {
      if (root == null)
        return 0;
      int left = DFS(root.left);
      int right = DFS(root.right);

      int wkLeft = 0;
      int wkRight = 0;

      //同じ値の時のみ対象とする
      if (root.left != null && root.val == root.left.val)
        wkLeft = left + 1;
      //同じ値の時のみ対象とする
      if (root.right != null && root.val == root.right.val)
        wkRight = right + 1;

      res = Math.Max(res, wkLeft + wkRight);
      return Math.Max(wkLeft, wkRight);
    }
  }
}
