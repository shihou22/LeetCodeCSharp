using System;

namespace Binary_Tree_Tilt
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
    public int FindTilt(TreeNode root)
    {
      sum(root);
      return sumNum;
    }
    int sumNum = 0;
    private int sum(TreeNode root)
    {
        int res = 0;
        if (root == null)
            return res;

        int leftVal = sum(root.left);
        int rightVal = sum(root.right);
        //左右の差分
        sumNum += Math.Abs(leftVal - rightVal);
        //次の差分は自分を含めた全ての値で差分をとる
        res += root.val + leftVal + rightVal;
        return res;
    }
  }
}
