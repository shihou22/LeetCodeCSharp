using System;

namespace Diameter_of_Binary_Tree
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
    public int DiameterOfBinaryTree(TreeNode root)
    {
      DFS(root);
      return res;
    }
    //nullの時の距離は0
    private int res = 0;
    private int DFS(TreeNode root)
    {
      if (root == null)
        return 0;

      //左の深さ
      int val1 = DFS(root.left);
      //右の深さ
      int val2 = DFS(root.right);
      /*
      深さの深い方をresに退避：最終回答とする
      中心を数えてしまうと+1大きいため、回答の方は+1をしない
      */
      res = Math.Max(res, val1 + val2);
      //こちらは中央を含めて上位に返す
      return Math.Max(val1, val2) + 1;
    }
  }
}
