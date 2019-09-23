using System;

namespace Sum_of_Root_To_Leaf_Binary_Numbers
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
    public int SumRootToLeaf(TreeNode root)
    {
      if (root == null)
        return 0;
      SumTotal(root, "");
      return (int)total;
    }
    long total = 0;
    private void SumTotal(TreeNode root, string sum)
    {
      if (root == null)
        return;

      if (root.left == null && root.right == null)
      {
        long wk = Convert.ToInt64(sum + root.val, 2);
        total += wk;
        // Console.WriteLine(sum + " : " + wk + " : " + total);
      }
      else
      {
        SumTotal(root.left, sum + root.val);
        SumTotal(root.right, sum + root.val);
      }
    }
  }
}
