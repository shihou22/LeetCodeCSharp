using System;
using System.Collections.Generic;

namespace Range_Sum_of_BST
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
    public int RangeSumBST(TreeNode root, int L, int R)
    {
      int sum = 0;
      if (root == null)
        return sum;
      int wk = root.val;
      sum += (L <= wk && wk <= R) ? wk : 0;
      sum += RangeSumBST(root.left, L, R);
      sum += RangeSumBST(root.right, L, R);
      return sum;
    }
    public int RangeSumBSTBFS(TreeNode root, int L, int R)
    {
      Stack<TreeNode> stack = new Stack<TreeNode>();
      stack.Push(root);
      int sum = 0;
      while (stack.Count > 0)
      {
        TreeNode wkNode = stack.Pop();
        if (wkNode == null)
          continue;
        if (L <= wkNode.val && wkNode.val <= R)
        {
          sum += wkNode.val;
        }
        stack.Push(wkNode.left);
        stack.Push(wkNode.right);
      }
      return sum;
    }
  }
}
